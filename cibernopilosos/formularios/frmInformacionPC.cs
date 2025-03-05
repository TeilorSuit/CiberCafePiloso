using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmInformacionPC : Form
    {
        public frmInformacionPC()
        {
            InitializeComponent();
        }
        // Propiedades para indicar el modo ("add" o "edit") y almacenar el ID de la PC a editar
        public string modo = "add", pcID = "";

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string pcNumber = txtPcNumber.Text;
            string pcInfo = txtPcInfo.Text;

            if (!ValidacionDatos(pcNumber) || !ValidacionDatos(pcInfo))
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (modo == "add")
            {
                AgregarPCs(pcNumber, pcInfo);
            }
            else // Modo "edit"
            {
                ActualizarPC(pcNumber, pcInfo);
            }
        }

        private void AgregarPCs(string pcNumber, string pcInfo)
        {
            sqlConexion conexionsql = new sqlConexion();
            string consulta = $"Insert into Computers (pcNumber, pcStatus, pcInfo) values ('{pcNumber}','idle','{pcInfo}')";
            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("PC agregada exitosamente");
            }
            else
            {
                MessageBox.Show("Error al agregar PC");
            }
        }

        private void ActualizarPC(string pcNumber, string pcInfo)
        {
            sqlConexion conexionsql = new sqlConexion();
            string consulta = $"Update Computers set pcNumber='{pcNumber}', pcInfo='{pcInfo}' where PcID='{pcID}'";
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

        private void txtPcNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
