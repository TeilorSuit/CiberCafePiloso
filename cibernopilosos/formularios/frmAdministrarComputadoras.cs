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
    public partial class frmAdministrarComputadoras : Form
    {
        public frmAdministrarComputadoras()
        {
            InitializeComponent();
            llenarTabla();
        }
        //Agregar PCS
        //Editar PCS
        //Borrar PCS

        private void llenarTabla()
        {
            sqlConexion ConexionSql = new sqlConexion();
            string consulta = "select * from Computers";
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvAdmiPCs.DataSource = "";
            dgvAdmiPCs.DataSource = tabla;
        }
        private void btnAgregarPC_Click(object sender, EventArgs e)
        {
            frmInformacionPC PcInfo = new frmInformacionPC();
            PcInfo.ShowDialog();
            llenarTabla();
        }

        private void btnBorrarPC_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion;
            confirmacion = MessageBox.Show("Esta acción no se puede deshacer. ¿Desea continuar?", "ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (confirmacion == DialogResult.OK)
            {
                sqlConexion ConexionSql = new sqlConexion();
                string comando = $"delete from Computers where PcID='{dgvAdmiPCs.CurrentRow.Cells[0].Value.ToString()}'";
                if (ConexionSql.EjecutarAccion(comando))
                {
                    MessageBox.Show("Computadora eliminada");
                }
                else
                {
                    MessageBox.Show("Error al eliminar computadora");
                }
            }
            llenarTabla();
        }

        private void btnEditarPC_Click(object sender, EventArgs e)
        {
            if (dgvAdmiPCs.CurrentRow != null)
            {
                frmInformacionPC frm = new frmInformacionPC();
                frm.modo = "edit";
                frm.btnConfirmacion.Text = "Editar";
                // Se asume que la columna del ID de la PC se llama "PcID"
                frm.pcID = dgvAdmiPCs.CurrentRow.Cells["PcID"].Value.ToString();
                PrecargarDatos(frm);
                frm.ShowDialog();
                llenarTabla();
            }
            else
            {
                MessageBox.Show("Seleccione una computadora para editar.");
            }
        }

        private void PrecargarDatos(frmInformacionPC PCInfo)
        {
            // Se asume que en el DataGridView las columnas se llaman "pcNumber" y "pcInfo"
            PCInfo.txtPcNumber.Text = dgvAdmiPCs.CurrentRow.Cells["pcNumber"].Value.ToString();
            PCInfo.txtPcInfo.Text = dgvAdmiPCs.CurrentRow.Cells["PcInfo"].Value.ToString();
        }

        private void flwPanelCuadro_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
