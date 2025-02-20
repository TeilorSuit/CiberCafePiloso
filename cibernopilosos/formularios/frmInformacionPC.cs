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
        private void AgregarPCs(string pcNumber, string pcInfo)
        {
            sqlConexion conexionsql = new sqlConexion();
            string consulta = $"Insert into Computers (pcNumber,pcStatus, pcInfo) values ('{pcNumber}','idle','{pcInfo}')";
            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Pc agregada exitosamente");
            }
            else
            {
                MessageBox.Show("Error al agregar pc");
            }
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string pcNumber, pcInfo;
            pcNumber = txtPcNumber.Text;
            pcInfo = txtPcInfo.Text;
            if (ValidacionDAtos(pcNumber)==false)//Validar casillas vacías
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }
            if (ValidacionDAtos(pcInfo)==false)
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }
            AgregarPCs(pcNumber, pcInfo);
        }

        private bool ValidacionDAtos(string Dato)
        {
            if (Dato.Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
