using System;
using System.Data;
using System.Windows.Forms;
using cibernopilosos.formularios_principales;

namespace cibernopilosos.formularios
{
    public partial class frmAdminPcs : Form
    {
        sqlConexion ConexionSql = new sqlConexion();
        public frmAdminPcs()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void llenarTabla()
        {
            string consulta = "select * from Computers";
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvAdmiPCs.DataSource = "";
            dgvAdmiPCs.DataSource = tabla;
            cambiarNombreColumnas(tabla);
        }

        private void cambiarNombreColumnas(DataTable dt)
        {
            if (dt.Columns.Contains("PcID"))
                dgvAdmiPCs.Columns["PcID"].HeaderText = "ID";
            if (dt.Columns.Contains("PcNumber"))
                dgvAdmiPCs.Columns["PcNumber"].HeaderText = "Número de PC";
            if (dt.Columns.Contains("PcInfo"))
                dgvAdmiPCs.Columns["PcInfo"].HeaderText = "Información";
            if (dt.Columns.Contains("PcIP"))
                dgvAdmiPCs.Columns["PcIP"].HeaderText = "Dirección IP";
            if (dt.Columns.Contains("PcStatus"))
                dgvAdmiPCs.Columns["PcStatus"].HeaderText = "Estado";
        }

        private void btnAgregarPC_Click(object sender, EventArgs e)
        {
            frmInformacionPC PcInfo = new frmInformacionPC();
            PcInfo.ShowDialog();
            llenarTabla();
        }

       

        private void btnEditarPC_Click(object sender, EventArgs e)
        {
            if (dgvAdmiPCs.CurrentRow != null)
            {
                frmInformacionPC frm = new frmInformacionPC();
                frm.modo = "edit";
                frm.btnConfirmacion.Text = "Editar";
                frm.pcIPOG = dgvAdmiPCs.CurrentRow.Cells["PcIp"].Value.ToString();
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
            PCInfo.txtPcNumber.Text = dgvAdmiPCs.CurrentRow.Cells["PcNumber"].Value.ToString();
            PCInfo.txtPcInfo.Text = dgvAdmiPCs.CurrentRow.Cells["PcInfo"].Value.ToString();
            PCInfo.txtPcIP.Text = dgvAdmiPCs.CurrentRow.Cells["PcIP"].Value.ToString();
        }

        private void btnNuevoPrecio_Click(object sender, EventArgs e)
        {
            decimal dolares = numDolares.Value;
            decimal centavos = numCentavos.Value;
            string consulta = $"update Services_Products set ServicePrice = {dolares}.{centavos} where ServiceID = 2";
            if (ConexionSql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Precio actualizado");
                lblPrecioActual.Text = $"${dolares}.{centavos}";
            }
            else
            {
                MessageBox.Show("Error al actualizar precio");
            }
        }

        private void frmAdminPcs_Load(object sender, EventArgs e)
        {
            string consulta = "select ServicePrice from Services_Products where ServiceID = 2";
            decimal valor = ConexionSql.DevuelveValorDecimal(consulta);
            lblPrecioActual.Text = Math.Round(valor, 2).ToString();
        }
        private void btnBorrarPC_Click(object sender, EventArgs e)
        {
            string consulta = $"select PcStatus from Computers where PcIp='{dgvAdmiPCs.CurrentRow.Cells["PcIp"].Value.ToString()}'";

            string estadopc = ConexionSql.DevuelveString(consulta);
            if (estadopc != "En uso")
            {
                DialogResult confirmacion;
                confirmacion = MessageBox.Show("Esta acción no se puede deshacer. ¿Desea continuar?", "ADVERTENCIA",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (confirmacion == DialogResult.OK)
                {
                    string comando = $"delete from Computers where PcIP='{dgvAdmiPCs.CurrentRow.Cells["PcIP"].Value.ToString()}'";
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
            else
            {
                MessageBox.Show("No es posible borrar una pc en uso");
            }
        }
    }
}
