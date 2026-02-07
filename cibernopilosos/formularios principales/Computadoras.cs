using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using cibernopilosos.formularios;

namespace cibernopilosos.formularios_principales
{
    public partial class Computadoras : Form
    {
        private sqlConexion conexionsql = new sqlConexion();
        private int puertoServidor = 12345;
        private int puertoCliente = 12346;
        private Timer actualizacionTimer;
        private bool escuchando = true;
        private Dictionary<string, PictureBox> imagenesPorIp = new Dictionary<string, PictureBox>();
        private readonly object estadoLock = new object();
        private Timer cuentaRegresivaTimer;
        private DateTime tiempoLimite;

        public Computadoras()
        {
            InitializeComponent();
            actualizacionTimer = new System.Windows.Forms.Timer();
            actualizacionTimer.Interval = 5000;
            actualizacionTimer.Tick += ActualizacionTimer_Tick;

            cuentaRegresivaTimer = new System.Windows.Forms.Timer();
            cuentaRegresivaTimer.Interval = 1000; // 1 segundo
            cuentaRegresivaTimer.Tick += CuentaRegresivaTimer_Tick;
        }

        private void Computadoras_Load(object sender, EventArgs e)
        {
            mostrarComputadorasEnPanel();
            actualizacionTimer.Start();
            _ = IniciarEscuchaAsync();
            ActualizarEstadoComputadorasAsync();
        }

        private PictureBox computadoraSeleccionada = null;

        private List<Computadora> cargarListaConLasComputadoras()
        {
            List<Computadora> computadoras = new List<Computadora>();
            string consulta = "SELECT * FROM Computers";
            DataTable dt = conexionsql.retornaRegistros(consulta);

            foreach (DataRow row in dt.Rows)
            {
                Computadora comp = new Computadora
                {
                    Ip = row["PcIp"].ToString(),
                    Numero = row["PcNumber"].ToString(),
                    Descripcion = row["PcInfo"].ToString(),
                    Estado = row["PcStatus"].ToString()
                };
                computadoras.Add(comp);
            }
            return computadoras;
        }

        public void mostrarComputadorasEnPanel()
        {
            fpnlComputadoras.Controls.Clear();
            imagenesPorIp.Clear();

            List<Computadora> computadoras = cargarListaConLasComputadoras();
            foreach (Computadora comp in computadoras)
            {
                Panel panel = new Panel
                {
                    Size = new Size(200, 200),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.FromArgb(36, 69, 69)
                };

                Label lblNumero = new Label
                {
                    Text = comp.Numero,
                    Location = new Point(90, 10),
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("MS Reference Sans Serif", 13, FontStyle.Bold)
                };

                Label lblDescripcion = new Label
                {
                    Text = comp.Descripcion,
                    Location = new Point(10, 30),
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular)
                };

                PictureBox pb = new PictureBox
                {
                    Tag = comp,
                    Size = new Size(150, 150),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(25, 50)
                };
                pb.Click += Imagen_Clicito;

                pb.Image = imglestadoscomputadora.Images[obtenerIndiceImagenPorEstado(comp.Estado)];

                panel.Controls.Add(lblNumero);
                panel.Controls.Add(lblDescripcion);
                panel.Controls.Add(pb);

                fpnlComputadoras.Controls.Add(panel);
                imagenesPorIp[comp.Ip] = pb;
            }
        }

        private void Imagen_Clicito(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                if (computadoraSeleccionada != null)
                {
                    computadoraSeleccionada.Parent.BackColor = Color.FromArgb(36, 69, 69);
                }

                if (computadoraSeleccionada == pb)
                {
                    deshabilitarTodo();
                    computadoraSeleccionada = null;
                    cuentaRegresivaTimer.Stop();
                    lblTiempoRestante.Text = string.Empty;
                }
                else
                {
                    computadoraSeleccionada = pb;
                    pb.Parent.BackColor = Color.LightBlue;
                    estadoBonotesPorComputadora();

                    Computadora pc = computadoraSeleccionada.Tag as Computadora;
                    if (pc.Estado.ToLower() == "en uso")
                    {
                        SolicitarTiempoRestante(pc.Ip);
                    }
                }
            }
        }

        private async void SolicitarTiempoRestante(string ip)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(IPAddress.Parse(ip), puertoCliente);
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] mensajeBytes = Encoding.UTF8.GetBytes("SOLICITAR_TIEMPO");
                        await stream.WriteAsync(mensajeBytes, 0, mensajeBytes.Length);

                        byte[] buffer = new byte[client.ReceiveBufferSize];
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                        if (respuesta.StartsWith("TIEMPO_RESTANTE:"))
                        {
                            int minutosRestantes = int.Parse(respuesta.Split(':')[1]);
                            tiempoLimite = DateTime.Now.AddMinutes(minutosRestantes);
                            cuentaRegresivaTimer.Start();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al solicitar tiempo restante: {ex.Message}");
            }
        }

        private void CuentaRegresivaTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan tiempoRestante = tiempoLimite - DateTime.Now;
            if (tiempoRestante.TotalSeconds > 0)
            {
                lblTiempoRestante.Text = $"{tiempoRestante.Hours:D2}:{tiempoRestante.Minutes:D2}:{tiempoRestante.Seconds:D2}";
            }
            else
            {
                cuentaRegresivaTimer.Stop();
                lblTiempoRestante.Text = "00:00:00";
            }
        }

        private void Computadoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            escuchando = false;
            actualizacionTimer.Stop();
            cuentaRegresivaTimer.Stop();
        }

        private void ActualizacionTimer_Tick(object sender, EventArgs e)
        {
            ActualizarEstadoComputadorasAsync();
        }

        private async Task ActualizarEstadoComputadorasAsync()
        {
            string consulta = "SELECT PcIp, PcStatus FROM Computers";
            DataTable dt = conexionsql.retornaRegistros(consulta);

            foreach (DataRow row in dt.Rows)
            {
                string ip = row["PcIp"].ToString();
                string estadoActual = row["PcStatus"].ToString().Trim().ToLower();

                if (estadoActual != "en uso")
                {
                    if (IPAddress.TryParse(ip, out IPAddress ipAddress))
                    {
                        bool disponible = await ProbarConexionAsync(ipAddress);
                        string nuevoEstado;
                        if (disponible)
                        {
                            nuevoEstado = "Disponible";
                        }
                        else
                        {
                            nuevoEstado = "Desconectado";
                        }

                        if (!nuevoEstado.ToLower().Equals(estadoActual))
                        {
                            conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = '{nuevoEstado}' WHERE PcIp = '{ip}'");
                        }
                    }
                }
            }
            actualizarImagenesSegunEstado();
        }

        private void actualizarImagenesSegunEstado()
        {
            string consulta = "SELECT PcIp, PcStatus FROM Computers";
            DataTable dt = conexionsql.retornaRegistros(consulta);

            foreach (DataRow row in dt.Rows)
            {
                string ip = row["PcIp"].ToString();
                string estado = row["PcStatus"].ToString();

                if (imagenesPorIp.TryGetValue(ip, out PictureBox pb))
                {
                    int indiceImagen = obtenerIndiceImagenPorEstado(estado);
                    if (pb.Image != imglestadoscomputadora.Images[indiceImagen])
                    {
                        pb.Image = imglestadoscomputadora.Images[indiceImagen];
                    }
                }
            }
        }

        private int obtenerIndiceImagenPorEstado(string estado)
        {
            switch (estado.ToLower())
            {
                case "disponible": return 0;
                case "en uso": return 1;
                case "desconectado": return 2;
                default: return 2;
            }
        }

        private async Task<bool> ProbarConexionAsync(IPAddress ipAddress)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    Task connectTask = client.ConnectAsync(ipAddress, puertoCliente);
                    Task timeoutTask = Task.Delay(1000);
                    Task completedTask = await Task.WhenAny(connectTask, timeoutTask);

                    if (completedTask == timeoutTask) return false;
                    await connectTask;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task EnviarComandoAsync(string comando, string ipString, int horas = 0, int minutos = 0, string mensajeAdicional = "")
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ipString);
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(ipAddress, puertoCliente);
                    using (NetworkStream stream = client.GetStream())
                    {
                        string mensaje = string.IsNullOrEmpty(mensajeAdicional) ? $"{comando}:{horas}:{minutos}" : $"{comando}:{mensajeAdicional}";
                        byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensaje);
                        await stream.WriteAsync(mensajeBytes, 0, mensajeBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar comando a {ipString}: {ex.Message}");
            }
        }

        private async Task IniciarEscuchaAsync()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, puertoServidor);
            listener.Start();
            try
            {
                while (escuchando)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    await ProcesarCliente(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la escucha: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }

        private async Task ProcesarCliente(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    if (mensaje == "TIEMPO_ACABADO")
                    {
                        string ipString = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                        lock (estadoLock)
                        {
                            string consulta = $"SELECT PcStatus FROM Computers WHERE PcIp = '{ipString}'";
                            string estadoActual = conexionsql.DevuelveString(consulta);
                            if (estadoActual == "En uso")
                            {
                                conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'");
                            }
                        }
                        actualizarImagenesSegunEstado();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar cliente: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        private void estadoBonotesPorComputadora()
        {
            if (computadoraSeleccionada == null)
            {
                deshabilitarTodo();
                return;
            }

            Computadora pc = computadoraSeleccionada.Tag as Computadora;
            string ipString = pc.Ip;
            string consulta = $"SELECT PcStatus FROM Computers WHERE PcIp='{ipString}'";
            string estadopc = conexionsql.DevuelveString(consulta);

            if (estadopc == "En uso")
            {
                habilitarTodo();
                btnIniciar.Text = "Detener";
            }
            else if (estadopc == "MANTENIMIENTO" || estadopc == "DESCONECTADO")
            {
                deshabilitarTodo();
            }
            else
            {
                btnIniciar.Text = "Iniciar";
                deshabilitarTodo();
                btnIniciar.Enabled = true;
            }
        }

        private void deshabilitarTodo()
        {
            btnIniciar.Enabled = false;
            btnAgregarTiempo.Enabled = false;
            btnCerrarApp.Enabled = false;
            btnEnviarMensaje.Enabled = false;
            txtboxMensajes.Enabled = false;
        }

        private void habilitarTodo()
        {
            btnIniciar.Enabled = true;
            btnAgregarTiempo.Enabled = true;
            btnCerrarApp.Enabled = true;
            btnEnviarMensaje.Enabled = true;
            txtboxMensajes.Enabled = true;
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (computadoraSeleccionada == null)
            {
                MessageBox.Show("Seleccione una computadora primero.");
                return;
            }
            Computadora pc = computadoraSeleccionada.Tag as Computadora;
            string ipString = pc.Ip;

            if (btnIniciar.Text == "Iniciar")
            {
                if (numHoras.Value == 0 && numMinutos.Value == 0)
                {
                    MessageBox.Show("Seleccione un tiempo");
                    return;
                }

                if (!await ProbarConexionAsync(IPAddress.Parse(ipString)))
                {
                    MessageBox.Show("No se pudo conectar al cliente. Verifica que esté en línea.");
                    return;
                }

                lock (estadoLock)
                {
                    conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'En uso' WHERE PcIp = '{ipString}'");
                }
                await EnviarComandoAsync("INICIAR", ipString, (int)numHoras.Value, (int)numMinutos.Value);
                btnIniciar.Text = "Detener";
                computadoraSeleccionada.Image = imglestadoscomputadora.Images[1];
                actualizarImagenesSegunEstado();
                deshabilitarTodo();
                computadoraSeleccionada.Parent.BackColor = Color.FromArgb(36, 69, 69);
                computadoraSeleccionada = null;
            }
            else if (btnIniciar.Text == "Detener")
            {
                await EnviarComandoAsync("BLOQUEO", ipString);
                lock (estadoLock)
                {
                    conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'");
                }
                btnIniciar.Text = "Iniciar";
                computadoraSeleccionada.Image = imglestadoscomputadora.Images[0];
                actualizarImagenesSegunEstado();
                deshabilitarTodo();
                computadoraSeleccionada.Parent.BackColor = Color.FromArgb(36, 69, 69);
                computadoraSeleccionada = null;
            }

            numHoras.Value = 0m;
            numMinutos.Value = 0m;
        }

        private async void btnAgregarTiempo_Click(object sender, EventArgs e)
        {
            if (numHoras.Value == 0 && numMinutos.Value == 0)
            {
                MessageBox.Show("Seleccione un tiempo");
                return;
            }
            if (computadoraSeleccionada == null)
            {
                MessageBox.Show("Seleccione una computadora primero.");
                return;
            }

            Computadora pc = computadoraSeleccionada.Tag as Computadora;
            string ipString = pc.Ip;
            await EnviarComandoAsync("AÑADIR", ipString, (int)numHoras.Value, (int)numMinutos.Value);
            numHoras.Value = 0m;
            numMinutos.Value = 0m;
        }

        private async void btnCerrarApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CIERRA EL CLIENT DE LA PC", "CONFIRMACION CIERRE", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                    return;
                }

                Computadora pc = computadoraSeleccionada.Tag as Computadora;
                string ipString = pc.Ip;
                await EnviarComandoAsync("CERRAR", ipString);
                lock (estadoLock)
                {
                    conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'");
                }
                actualizarImagenesSegunEstado();
                deshabilitarTodo();
                computadoraSeleccionada.Parent.BackColor = Color.FromArgb(36, 69, 69);
                computadoraSeleccionada = null;
            }
        }

        private async void txtboxMensajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                    return;
                }

                Computadora pc = computadoraSeleccionada.Tag as Computadora;
                string ipString = pc.Ip;
                await EnviarComandoAsync("MENSAJE", ipString, 0, 0, txtboxMensajes.Text);
                txtboxMensajes.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private async void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                    return;
                }

                Computadora pc = computadoraSeleccionada.Tag as Computadora;
                string ipString = pc.Ip;
                await EnviarComandoAsync("MENSAJE", ipString, 0, 0, txtboxMensajes.Text);
                txtboxMensajes.Clear();
            }
        }

        private void BotonAddClientePc_Click(object sender, EventArgs e)
        {
            if (numHoras.Value == 0 && numMinutos.Value == 0)
            {
                MessageBox.Show("Seleccione un tiempo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (computadoraSeleccionada == null)
            {
                MessageBox.Show("Seleccione una computadora para vincular.");
                return;
            }

            Computadora pc = computadoraSeleccionada.Tag as Computadora;
            string ipString = pc.Ip;
            frmClientes frmCli = new frmClientes
            {
                VinculacionMode = true,
                SelectedPcIp = ipString,
                TiempoHorasCalculados = (int)numHoras.Value,
                TiempoMinutosCalculados = (int)numMinutos.Value
            };
            frmCli.ShowDialog();
            mostrarComputadorasEnPanel();
        }

    }

    public class Computadora
    {
        public string Numero { get; set; }
        public string Ip { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}


