using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmInformacionPC : Form
    {
        private TcpClient Tester;
        private IPAddress ipAddress;
        private int puerto = 12346;

        public frmInformacionPC()
        {
            InitializeComponent();
        }
        public string modo = "add", pcIPOG = "";

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string pcNumber = txtPcNumber.Text;
            string pcInfo = txtPcInfo.Text;
            string pciP = txtPcIP.Text;
            if (!ValidacionDatos(pcNumber) || !ValidacionDatos(pcInfo))
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (modo == "add")
            {
                AgregarPCs(pcNumber, pcInfo, pciP);
            }
            else //modo edit
            {
                ActualizarPC(pcNumber, pcInfo, pciP);
            }
        }

        private void AgregarPCs(string pcNumber, string pcInfo, string pcIp)
        {
            sqlConexion conexionsql = new sqlConexion();
            string consulta = $"Insert into Computers (PcNumber, PcStatus, PcInfo, PcIp) values ('{pcNumber}','Disponible','{pcInfo}','{pcIp}')";

            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("PC agregada exitosamente");
            }
            else
            {
                MessageBox.Show("Error al agregar PC");
            }
        }

        private void ActualizarPC(string pcNumber, string pcInfo, string pcIp)
        {
            sqlConexion conexionsql = new sqlConexion();
            string consulta = $"Update Computers set PcNumber='{pcNumber}', PcInfo='{pcInfo}', PcIp='{pcIp}' where PcIp='{pcIPOG}'";


            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("PC actualizada exitosamente");
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


        //validar ip ingresada
        private void btnValidar_Click(object sender, EventArgs e)
        {
            //validar conexión (textoIP, salida ipAddress con el valor de textoIp)
            if (IPAddress.TryParse(txtPcIP.Text, out ipAddress))
            {
                try
                {
                    Tester = new TcpClient();
                    Tester.Connect(ipAddress, puerto);
                    MessageBox.Show("Conexión exitosa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message);
                }
                finally
                {
                    if (Tester.Connected)
                    {
                        btnConfirmacion.Enabled = true;
                        btnConfirmacion.BackColor = Color.White;
                        btnConfirmacion.FlatStyle = FlatStyle.Standard;
                        btnConfirmacion.ForeColor = Color.Black;
                        Tester.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Dirección IP no válida");
            }
        }

        private void frmInformacionPC_Load(object sender, EventArgs e)
        {
            btnConfirmacion.Enabled = false;
            btnConfirmacion.BackColor = Color.Red;
            btnConfirmacion.FlatStyle = FlatStyle.Flat;
            btnConfirmacion.ForeColor = Color.White;
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