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
        private int puertoServidor = 12345; // Puerto donde el servidor escucha mensajes de los clientes
        private int puertoCliente = 12346;  // Puerto donde los clientes escuchan comandos del servidor
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
            IniciarEscucha(); 
        }

        private void Computadoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            escuchando = false;
        }

        private void LlenarTabla()
        {
            string consulta = "select PcIp, PcStatus, PcInfo from Computers";
            DataTable tabla = conexionsql.retornaRegistros(consulta);
            dgvComputadoras.DataSource = tabla;
        }

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

                if (ipStatus != "OCUPADO")
                {
                    if (IPAddress.TryParse(ipString, out IPAddress ipAddress))
                    {
                        bool disponible = await ProbarConexionAsync(ipAddress);
                        string estado = disponible ? "Disponible" : "Desconectado";
                        conexionsql.EjecutarAccion($"Update Computers set PcStatus = '{estado}' Where PcIp='{ipString}'");
                    }
                    else
                    {
                        conexionsql.EjecutarAccion($"Update Computers set PcStatus = 'IP no válida' Where PcIp='{ipString}'");
                    }
                }
            }

            LlenarTabla(); 
        }

        private async Task<bool> ProbarConexionAsync(IPAddress ipAddress)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    var connectTask = client.ConnectAsync(ipAddress, puertoCliente);//12346
                    var timeoutTask = Task.Delay(2000); //tiempo max espera

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

        private async Task EnviarComandoAsync(string comando)
        {
            try
            {
                string ipString = conexionsql.DevuelveString($"Select PcIp from Computers Where PcIp='{dgvComputadoras.CurrentRow.Cells[0].Value}'");
                if (IPAddress.TryParse(ipString, out IPAddress ipAddress))
                {
                    using (TcpClient client = new TcpClient())
                    {
                        await client.ConnectAsync(ipAddress, puertoCliente); //Conectar puerto: 12346 del cliente
                        NetworkStream stream = client.GetStream();
                        byte[] mensaje = Encoding.UTF8.GetBytes(comando);
                        await stream.WriteAsync(mensaje, 0, mensaje.Length);
                    }
                }
                else
                {
                    MessageBox.Show("Dirección IP no válida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IniciarEscucha()
        {
            Task.Run(async () =>
            {
                TcpListener listener = new TcpListener(IPAddress.Any, puertoServidor); //Escuchar puerto: 12345
                listener.Start();
                try
                {
                    while (escuchando)
                    {
                        if (listener.Pending())
                        {
                            TcpClient client = await listener.AcceptTcpClientAsync();
                            NetworkStream stream = client.GetStream();
                            byte[] buffer = new byte[client.ReceiveBufferSize];
                            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                            string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                            if (mensaje == "TIEMPO_ACABADO")
                            {
                                string ipString = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                                //RealizarTransaccion(ipString);
                                conexionsql.EjecutarAccion($"UPDATE Computers SET PcStatus = 'Disponible' WHERE PcIp = '{ipString}'");
                            }
                            client.Close();
                        }
                        await Task.Delay(100); //evitar sobrecarga
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    listener.Stop();
                }
            });
        }

        private void RealizarTransaccion(string ipString)
        {
            //cambiar por completo
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

        #region Botones
        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string ipString = dgvComputadoras.CurrentRow.Cells[0].Value.ToString();
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
                        conexionsql.EjecutarAccion($"Update Computers set PcStatus = 'OCUPADO' Where PcIp='{ipString}'");
                        await EnviarComandoAsync($"INICIAR:{numHoras.Value}:{numMinutos.Value}");
                        btnIniciar.Text = "Detener";
                    }
                    else
                    {
                        MessageBox.Show("No se puede iniciar el tiempo. La computadora no está conectada.");
                    }
                }
            }
            else if (btnIniciar.Text == "Detener")
            {
                await EnviarComandoAsync("DETENER:0:0");
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
                await EnviarComandoAsync($"AÑADIR:{numHoras.Value}:{numMinutos.Value}");
                numHoras.Value = 0m;
                numMinutos.Value = 0m;
            }
        }
        private async void btnApagar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("APAGA EL ORDENADOR REMOTO", "CONFIRMACION APAGADO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("APAGAR:0:0");
            }
        }

        private async void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("REINICIA EL ORDENADOR REMOTO", "CONFIRMACION REINICIO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("REINICIAR:0:0");
            }
        }

        private async void btnCerrarApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CIERRA LA APLICACION REMOTA", "CONFIRMACION CIERRE", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("CERRAR:0:0");
            }
        }

        private async void btnBloqueoPc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BLOQUEA LA APLICACION REMOTA", "CONFIRMACION BLOQUEO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await EnviarComandoAsync("BLOQUEO:0:0");
            }
        }

        private async void txtboxMensajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                await EnviarComandoAsync($"MENSAJE:{txtboxMensajes.Text}:0");
                txtboxMensajes.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private async void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxMensajes.Text))
            {
                await EnviarComandoAsync($"MENSAJE:{txtboxMensajes.Text}:0");
                txtboxMensajes.Clear();
            }
        }
        #endregion
    }
}