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
        private int puertoServidor = 12345; // Puerto donde el servidor escucha mensajes de los clientes
        private int puertoCliente = 12346; // Puerto donde los clientes escuchan comandos del servidor
        private Timer actualizacionTimer;
        private bool escuchando = true;
        private Dictionary<string, PictureBox> imagenesPorIp =
            new Dictionary<string, PictureBox>(); // Asociar imagen con ip

        public Computadoras()
        {
            InitializeComponent();
            actualizacionTimer = new System.Windows.Forms.Timer();
            actualizacionTimer.Interval = 5000; // Cada 5 segundos revisa el estado
            actualizacionTimer.Tick += ActualizacionTimer_Tick;
        }

        private void Computadoras_Load(object sender, EventArgs e)
        {
            mostrarComputadorasEnPanel();
            actualizacionTimer.Start();
            _ = IniciarEscuchaAsync(); //para que no reciba el task (nunca va a acabar)
            _ = ActualizarEstadoComputadorasAsync(); //actualización inicial al abrir el formulario
        }

        #region CargarComputadoras

        private PictureBox computadoraSeleccionada = null;
        private List<Computadora> cargarListaConLasComputadoras()
        {
            List<Computadora> computadoras = new List<Computadora>();
            string consulta = "SELECT * FROM Computers";
            DataTable dt = conexionsql.retornaRegistros(consulta);

            foreach (DataRow row in dt.Rows)
            {
                Computadora comp = new Computadora();
                comp.Ip = row["PcIp"].ToString();
                comp.Numero = row["PcNumber"].ToString();
                comp.Descripcion = row["PcInfo"].ToString();
                comp.Estado = row["PcStatus"].ToString();

                computadoras.Add(comp);
            }
            return computadoras;
        }

        private void mostrarComputadorasEnPanel()
        {
            List<Computadora> computadoras = cargarListaConLasComputadoras();
            foreach (Computadora comp in computadoras)
            {
                //panel para cada computadora
                Panel panel = new Panel();
                panel.Size = new System.Drawing.Size(200, 200);
                panel.BorderStyle = BorderStyle.None;
                panel.BackColor = System.Drawing.Color.FromArgb(36, 69, 69);

                Label lblNumero = new Label();
                lblNumero.Text = comp.Numero;
                lblNumero.Location = new System.Drawing.Point(90, 10);
                lblNumero.AutoSize = true;
                lblNumero.ForeColor = Color.White;
                lblNumero.Font = new Font("MS Reference Sans Serif", 13, FontStyle.Bold);

                Label lblDescripcion = new Label();
                lblDescripcion.Text = comp.Descripcion;
                lblDescripcion.Location = new System.Drawing.Point(10, 30);
                lblDescripcion.AutoSize = true;
                lblDescripcion.ForeColor = Color.White;
                lblDescripcion.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);

                PictureBox pb = new PictureBox();
                pb.Tag = comp; 
                pb.Image = imglestadoscomputadora.Images[2]; 
                pb.Size = new Size(150, 150); 
                pb.SizeMode = PictureBoxSizeMode.StretchImage; 
                pb.Location = new Point(25, 50); 
                pb.Click += Imagen_Clicito;

                panel.Controls.Add(lblNumero);
                panel.Controls.Add(lblDescripcion);
                panel.Controls.Add(pb);

                fpnlComputadoras.Controls.Add(panel);

                //diccionario para actualizar img 
                imagenesPorIp[comp.Ip] = pb;
            }
        }

        //imitacion selección imagen
        private void Imagen_Clicito(object sender, EventArgs e) // Evento creado a mano
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                if (computadoraSeleccionada != null)
                {
                    computadoraSeleccionada.Parent.BackColor = Color.FromArgb(36, 69, 69);
                    estadoBonotesPorComputadora();
                }

                if (computadoraSeleccionada == pb)
                {
                    deshabilitarTodo();
                    computadoraSeleccionada = null;
                }
                else
                {
                    computadoraSeleccionada = pb;
                    pb.Parent.BackColor = Color.LightBlue; //resalta el panel seleccionado
                    estadoBonotesPorComputadora();
                }
            }
        }

        private void Computadoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            escuchando = false;
        }
        #endregion

        #region Actualización y conexiones

        private void ActualizacionTimer_Tick(object sender, EventArgs e)
        {
            _ = ActualizarEstadoComputadorasAsync(); //revisa el estado cada 5 segundos
        }

        private async Task ActualizarEstadoComputadorasAsync()
        {
            string consulta = "SELECT PcIp, PcStatus FROM Computers";
            DataTable tabla = conexionsql.retornaRegistros(consulta);

            foreach (DataRow row in tabla.Rows)
            {
                string ipString = row["PcIp"].ToString();
                string estadoActual = row["PcStatus"].ToString();

                if (estadoActual != "En uso")
                {
                    if (IPAddress.TryParse(ipString, out IPAddress ipAddress))
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
                        conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = '{nuevoEstado}' WHERE PcIp = '{ipString}'");
                    }
                    else
                    {
                        conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'IP no válida' WHERE PcIp = '{ipString}'");
                    }
                }
            }
            actualizarImagenesSegunEstado(); //actualiza las imágenes después de cambiar el estado
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
                    int indiceImagenPorEstado = obtenerIndiceImagenPorEstado(estado);
                    pb.Image = imglestadoscomputadora.Images[indiceImagenPorEstado];
                }
            }
        }

        private int obtenerIndiceImagenPorEstado(string estado)
        {
            switch (estado.ToLower())
            {
                case "disponible":
                    return 0;
                case "en uso":
                    return 1;
                case "desconectado":
                    return 2;
                default:
                    return 0;
            }
        }

        private async Task<bool> ProbarConexionAsync(IPAddress ipAddress)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    Task connectTask = client.ConnectAsync(ipAddress, puertoCliente);
                    Task timeoutTask = Task.Delay(2000); //espera 2 segundos como max
                    Task completedTask = await Task.WhenAny(connectTask, timeoutTask);

                    if (completedTask == timeoutTask)
                    {
                        return false;
                    }

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
                        conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'");
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

        #endregion

        #region Métodos de interfaz

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

        #endregion

        #region Botones eventos

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (computadoraSeleccionada == null)
            {
                MessageBox.Show("Seleccione una computadora primero.");
                return;
            }
            Computadora pc = computadoraSeleccionada.Tag as Computadora;
            string ipString = pc.Ip;

            IPAddress ipAddress = IPAddress.Parse(ipString);

            if (btnIniciar.Text == "Iniciar")
            {
                if (numHoras.Value == 0 && numMinutos.Value == 0)
                {
                    MessageBox.Show("Seleccione un tiempo");
                    return;
                }

                if (!await ProbarConexionAsync(ipAddress))
                {
                    MessageBox.Show("No se pudo conectar al cliente. Verifica que esté en línea.");
                    return;
                }

                string updateQuery = $"UPDATE Computers SET PcStatus = 'En uso' WHERE PcIp = '{ipString}'";
                conexionsql.EjecutarAccion(updateQuery);

                await EnviarComandoAsync("INICIAR", ipString, (int)numHoras.Value, (int)numMinutos.Value);

                btnIniciar.Text = "Detener";
                computadoraSeleccionada.Image = imglestadoscomputadora.Images[1];
            }
            else if (btnIniciar.Text == "Detener")
            {
                await EnviarComandoAsync("BLOQUEO", ipString);

                string updateQuery = $"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'";
                conexionsql.EjecutarAccion(updateQuery);

                btnIniciar.Text = "Iniciar";
                computadoraSeleccionada.Image = imglestadoscomputadora.Images[0];
            }

            numHoras.Value = 0m;
            numMinutos.Value = 0m;
            actualizarImagenesSegunEstado(); // Actualiza las imágenes inmediatamente
        }

        private async void btnAgregarTiempo_Click(object sender, EventArgs e)
        {
            if (numHoras.Value == 0 && numMinutos.Value == 0)
            {
                MessageBox.Show("Seleccione un tiempo");
            }
            else
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                }
                else
                {
                    Computadora pc = computadoraSeleccionada.Tag as Computadora;
                    string ipString = pc.Ip;
                    await EnviarComandoAsync("AÑADIR", ipString, (int)numHoras.Value, (int)numMinutos.Value);
                    numHoras.Value = 0m;
                    numMinutos.Value = 0m;
                }
            }
        }

        private async void btnCerrarApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CIERRA EL CLIENT DE LA PC", "CONFIRMACION CIERRE", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                }
                else
                {
                    Computadora pc = computadoraSeleccionada.Tag as Computadora;
                    string ipString = pc.Ip;
                    await EnviarComandoAsync("CERRAR", ipString);
                    string updateQuery = $"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'";
                    conexionsql.EjecutarAccion(updateQuery);
                    actualizarImagenesSegunEstado(); // Actualiza las imágenes inmediatamente
                }
            }
        }

        private async void txtboxMensajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                }
                else
                {
                    Computadora pc = computadoraSeleccionada.Tag as Computadora;
                    string ipString = pc.Ip;
                    await EnviarComandoAsync("MENSAJE", ipString, 0, 0, txtboxMensajes.Text);
                    txtboxMensajes.Clear();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private async void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                if (computadoraSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una computadora primero.");
                }
                else
                {
                    Computadora pc = computadoraSeleccionada.Tag as Computadora;
                    string ipString = pc.Ip;
                    await EnviarComandoAsync("MENSAJE", ipString, 0, 0, txtboxMensajes.Text);
                    txtboxMensajes.Clear();
                }
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
            }
            else
            {
                Computadora pc = computadoraSeleccionada.Tag as Computadora;
                string ipString = pc.Ip;
                frmClientes frmCli = new frmClientes();
                frmCli.VinculacionMode = true;
                frmCli.SelectedPcIp = ipString;
                frmCli.TiempoHorasCalculados = (int)numHoras.Value;
                frmCli.TiempoMinutosCalculados = (int)numMinutos.Value;
                frmCli.ShowDialog();
            }
        }

        #endregion
    }

    public class Computadora
    {
        public string Numero { get; set; }
        public string Ip { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}