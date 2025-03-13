using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;

namespace cibernopilosos
{
    public partial class Computadoras : Form
    {
        private sqlConexion conexionsql = new sqlConexion();
        private int puertoServidor = 12345; //puerto donde el servidor escucha mensajes de los clientes
        private int puertoCliente = 12346;  //uerto donde los clientes escuchan comandos del servidor
        private System.Windows.Forms.Timer actualizacionTimer;
        private bool escuchando = true;

        public Computadoras()
        {
            InitializeComponent();
            actualizacionTimer = new System.Windows.Forms.Timer();
            actualizacionTimer.Interval = 5000;
            actualizacionTimer.Tick += ActualizacionTimer_Tick;
        }

        private void Computadoras_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            actualizacionTimer.Start();
            _ = IniciarEscuchaAsync(); //pa no reciba el task(pq nunca va acabar)
        }

        private void Computadoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            escuchando = false;
        }

        #region Actualización y conexiones

        private async void ActualizacionTimer_Tick(object sender, EventArgs e)
        {
            await ActualizarEstadoComputadorasAsync();
        }

        private async Task ActualizarEstadoComputadorasAsync()
        {
            string consulta = "select PcIp, PcStatus from Computers";
            DataTable tabla = conexionsql.retornaRegistros(consulta);
            foreach (DataRow row in tabla.Rows)
            {
                string ipString = row["PcIp"].ToString();
                string ipStatus = row["PcStatus"].ToString();
                string estado = "";

                if (ipStatus == "Disponible" || ipStatus == "Desconectado")
                {
                    if (IPAddress.TryParse(ipString, out IPAddress ipAddress))
                    {
                        bool disponible = await ProbarConexionAsync(ipAddress);
                        if (disponible)
                        {
                            estado = "Disponible";
                        }
                        else
                        {
                            estado = "Desconectado";
                        }
                        conexionsql.EjecutarAccion($"Update Computers set PcStatus = '{estado}' Where PcIp='{ipString}'");
                    }
                    else
                    {
                        conexionsql.EjecutarAccion($"Update Computers set PcStatus = 'IP no válida' Where PcIp='{ipString}'");
                    }
                }
            }

            string selectedPcIp = "";
            int selectedRowIndex = -1;

            if (dgvComputadoras.CurrentRow != null)
            {
                selectedPcIp = dgvComputadoras.CurrentRow.Cells["PcIp"].Value.ToString();
                selectedRowIndex = dgvComputadoras.CurrentCell.RowIndex;
            }

            dgvComputadoras.SelectionChanged -= dgvComputadoras_SelectionChanged;
            LlenarTabla();

            if (selectedPcIp != "" && selectedRowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvComputadoras.Rows)
                {
                    if (row.Cells["PcIp"].Value.ToString() == selectedPcIp)
                    {
                        dgvComputadoras.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            dgvComputadoras.SelectionChanged += dgvComputadoras_SelectionChanged;
        }

        private async Task<bool> ProbarConexionAsync(IPAddress ipAddress)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    var connectTask = client.ConnectAsync(ipAddress, puertoCliente);
                    var timeoutTask = Task.Delay(2000);
                    var completedTask = await Task.WhenAny(connectTask, timeoutTask);
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

        private async Task EnviarComandoAsync(string comando, int horas = 0, int minutos = 0, string mensajeAdicional = "")
        {
            try
            {
                string ipString = dgvComputadoras.CurrentRow.Cells["PcIp"].Value.ToString();
                if (IPAddress.TryParse(ipString, out IPAddress ipAddress))
                {
                    TcpClient client = new TcpClient();
                    await client.ConnectAsync(ipAddress, puertoCliente);
                    NetworkStream stream = client.GetStream();
                    string mensaje;
                    if (string.IsNullOrEmpty(mensajeAdicional))
                    {
                        mensaje = $"{comando}:{horas}:{minutos}";
                    }
                    else
                    {
                        mensaje = $"{comando}:{mensajeAdicional}";
                    }
                    byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensaje);

                    await stream.WriteAsync(mensajeBytes, 0, mensajeBytes.Length);

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar comando: {ex.Message}");
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
                        //RealizaTransaccion(ipString);
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

        private void LlenarTabla()
        {
            string consulta = "select PcIp, PcStatus, PcInfo from Computers";
            DataTable tabla = conexionsql.retornaRegistros(consulta);
            dgvComputadoras.DataSource = tabla;
        }

        private void dgvComputadoras_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComputadoras.CurrentRow != null)
            {
                string consulta = $"select PcStatus from Computers where PcIp='{dgvComputadoras.CurrentRow.Cells["PcIp"].Value.ToString()}'";
                string estadopc = conexionsql.DevuelveString(consulta);
                if (estadopc == "En uso")
                {
                    habilitarTodo();
                    btnIniciar.Text = "Detener";
                }
                else if (estadopc == "Mantenimiento" || estadopc == "Desconectado")
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
        }

        private void deshabilitarTodo()
        {
            btnIniciar.Enabled = false;
            btnAgregarTiempo.Enabled = false;
            btnApagar.Enabled = false;
            btnReiniciar.Enabled = false;
            btnCerrarApp.Enabled = false;
            btnBloqueoPc.Enabled = false;
            btnEnviarMensaje.Enabled = false;
            txtboxMensajes.Enabled = false;
        }

        private void habilitarTodo()
        {
            btnIniciar.Enabled = true;
            btnAgregarTiempo.Enabled = true;
            btnApagar.Enabled = true;
            btnReiniciar.Enabled = true;
            btnCerrarApp.Enabled = true;
            btnBloqueoPc.Enabled = true;
            btnEnviarMensaje.Enabled = true;
            txtboxMensajes.Enabled = true;
        }

        #endregion

        #region Métodos de transacciones

        private void RealizaTransaccion(string ipString)
        {
            string transID = "TransID";
            string transClientID = "TransClientID";
            string transServicesID = "TransServicesID";
            string transDescrip = "TransDescrip";
            string transPaidMoney = "TransPaidMoney";
            string transDiscount = "TransDiscount";
            string transQuantity = "TransQuantity";
            string transDateTime = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            string transUsername = "TransUsername";

            string consulta = $"INSERT INTO Transactions (TransID, TransClientID, TransServicesID, TransDescrip, TransPaidMoney, TransDiscount, TransQuantity, TransDateTime, TransUsername) " +
                              $"VALUES ('{transID}', '{transClientID}', '{transServicesID}', '{transDescrip}', '{transPaidMoney}', '{transDiscount}', '{transQuantity}', '{transDateTime}', '{transUsername}')";
            conexionsql.EjecutarAccion(consulta);
        }

        #endregion

        #region Botones eventos

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string ipString = dgvComputadoras.CurrentRow.Cells["PcIp"].Value.ToString();
            if (btnIniciar.Text == "Iniciar")
            {
                if (numHoras.Value == 0 && numMinutos.Value == 0)
                {
                    MessageBox.Show("Seleccione un tiempo");
                }
                else
                {
                    if (await ProbarConexionAsync(IPAddress.Parse(ipString)))
                    {
                        conexionsql.EjecutarAccion($"Update Computers set PcStatus = 'En uso' Where PcIp='{ipString}'");
                        await EnviarComandoAsync("INICIAR", (int)numHoras.Value, (int)numMinutos.Value);
                        btnIniciar.Text = "Detener";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al cliente.");
                    }
                }
            }
            else if (btnIniciar.Text == "Detener")
            {
                await EnviarComandoAsync("BLOQUEO");
                conexionsql.EjecutarAccion($"Update Computers set PcStatus = 'Disponible' Where PcIp='{ipString}'");
                btnIniciar.Text = "Iniciar";
            }
            numHoras.Value = 0m;
            numMinutos.Value = 0m;
        }

        private async void btnAgregarTiempo_Click(object sender, EventArgs e)
        {
            if (numHoras.Value == 0 && numMinutos.Value == 0)
            {
                MessageBox.Show("Seleccione un tiempo");
            }
            else
            {
                await EnviarComandoAsync("AÑADIR", (int)numHoras.Value, (int)numMinutos.Value);
                numHoras.Value = 0m;
                numMinutos.Value = 0m;
            }
        }

        private async void btnApagar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("APAGA LA PC", "CONFIRMACION APAGADO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("APAGAR");
            }
        }

        private async void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("REINICIAR LA PC", "CONFIRMACION REINICIO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("REINICIAR");
            }
        }

        private async void btnCerrarApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CIERRA EL CLIENT DE LA PC", "CONFIRMACION CIERRE", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("CERRAR");
            }
        }

        private async void btnBloqueoPc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BLOQUEA LA PC", "CONFIRMACION BLOQUEO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("BLOQUEO");
            }
        }

        private async void txtboxMensajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                await EnviarComandoAsync("MENSAJE", 0, 0, txtboxMensajes.Text);
                txtboxMensajes.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private async void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                await EnviarComandoAsync("MENSAJE", 0, 0, txtboxMensajes.Text);
                txtboxMensajes.Clear();
            }
        }

        private void BotonAddClientePc_Click(object sender, EventArgs e)
        {
            if (dgvComputadoras.CurrentRow != null)
            {
                string pcIp = dgvComputadoras.CurrentRow.Cells["PcIp"].Value.ToString();
                cibernopilosos.formularios.frmClientes frmCli = new cibernopilosos.formularios.frmClientes();
                frmCli.VinculacionMode = true;
                frmCli.SelectedPcIp = pcIp;
                frmCli.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una computadora para vincular.");
            }
        }

        #endregion
    }
}
