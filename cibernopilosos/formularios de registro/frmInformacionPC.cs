using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using cibernopilosos.formularios_principales;

namespace cibernopilosos.formularios
{
    public partial class frmInformacionPC : Form
    {
        private sqlConexion conexionsql = new sqlConexion();
        private IPAddress ipAddress;
        private int puerto = 12346;

        public string modo = "add";
        public string pcIPOG = ""; // IP Original para el WHERE

        public frmInformacionPC()
        {
            InitializeComponent();
        }

        private void frmInformacionPC_Load(object sender, EventArgs e)
        {
            btnConfirmacion.Enabled = false;
            btnConfirmacion.BackColor = Color.Red;
            btnConfirmacion.FlatStyle = FlatStyle.Flat;
            btnConfirmacion.ForeColor = Color.White;
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string pcNumber = txtPcNumber.Text.Trim();
            string pcInfo = txtPcInfo.Text.Trim();
            string pcIp = txtPcIP.Text.Trim();

            if (!ValidacionDatos(pcNumber) || !ValidacionDatos(pcInfo) || !ValidacionDatos(pcIp))
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            // PEQUEÑO TRUCO DE SEGURIDAD (SANITIZACIÓN BÁSICA):
            // Si el texto tiene una comilla simple ('), la duplicamos ('') para que SQL no explote.
            // Ejemplo: "Teilor's PC" se convierte en "Teilor''s PC", y SQL lo guarda bien.
            pcNumber = pcNumber.Replace("'", "''");
            pcInfo = pcInfo.Replace("'", "''");
            pcIp = pcIp.Replace("'", "''");

            if (modo == "add")
            {
                AgregarPCs(pcNumber, pcInfo, pcIp);
            }
            else
            {
                ActualizarPC(pcNumber, pcInfo, pcIp);
            }
        }

        private void AgregarPCs(string pcNumber, string pcInfo, string pcIp)
        {
            // ADAPTADO A TU CLASE: Usamos interpolación de strings ($"...")
            string consulta = $"INSERT INTO Computers (PcNumber, PcStatus, PcInfo, PcIp) VALUES ('{pcNumber}', 'Desconectado', '{pcInfo}', '{pcIp}')";

            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("PC agregada exitosamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar PC");
            }
        }

        private void ActualizarPC(string pcNumber, string pcInfo, string pcIp)
        {
            // ADAPTADO A TU CLASE
            string consulta = $"UPDATE Computers SET PcNumber='{pcNumber}', PcInfo='{pcInfo}', PcIp='{pcIp}' WHERE PcIp='{pcIPOG}'";

            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("PC actualizada exitosamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar PC");
            }
        }

        private bool ValidacionDatos(string dato)
        {
            return !string.IsNullOrEmpty(dato);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string ipTexto = txtPcIP.Text.Trim();

            if (IPAddress.TryParse(ipTexto, out ipAddress))
            {
                TcpClient tester = null;
                try
                {
                    tester = new TcpClient();
                    // Timeout manual de 2 segundos para no congelar la pantalla mucho tiempo
                    var result = tester.BeginConnect(ipAddress, puerto, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));

                    if (!success)
                    {
                        throw new Exception("Tiempo de espera agotado.");
                    }

                    tester.EndConnect(result);

                    MessageBox.Show("¡Conexión exitosa!");
                    btnConfirmacion.Enabled = true;
                    btnConfirmacion.BackColor = Color.Green;
                    btnConfirmacion.FlatStyle = FlatStyle.Standard;
                    btnConfirmacion.ForeColor = Color.Black;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar: " + ex.Message);
                    btnConfirmacion.Enabled = false;
                    btnConfirmacion.BackColor = Color.Red;
                }
                finally
                {
                    if (tester != null) tester.Close();
                }
            }
            else
            {
                MessageBox.Show("IP no válida");
            }
        }

        private void txtPcNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}