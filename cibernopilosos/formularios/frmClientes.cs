using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            llenarTabla();
        }
        private void llenarTabla()
        {
            sqlConexion ConexionSql = new sqlConexion();
            string consulta = "select * from Clients";
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvAdmiClientes.DataSource = "";
            dgvAdmiClientes.DataSource = tabla;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmInformacionCliente ClientInfo = new frmInformacionCliente();
            ClientInfo.modo = "add";
            ClientInfo.btnConfirmacion.Text = "Registrar";
            ClientInfo.ShowDialog();
            llenarTabla();
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            frmInformacionCliente ClientInfo = new frmInformacionCliente();
            PrecargarDatos(ClientInfo);
            ClientInfo.aux_id = dgvAdmiClientes.CurrentRow.Cells[0].Value.ToString();
            ClientInfo.modo = "edit";
            ClientInfo.btnConfirmacion.Text = "Actualizar";
            ClientInfo.ShowDialog();
            llenarTabla();
        }
        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion;
            confirmacion= MessageBox.Show("Está acción no se puede deshacer. ¿Desea continuar?", "ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (confirmacion == DialogResult.OK)
            {
                sqlConexion ConexionSql = new sqlConexion();
                string comando = $"delete from Clients where ClientID='{dgvAdmiClientes.CurrentRow.Cells[0].Value.ToString()}'";
                if(ConexionSql.EjecutarAccion(comando))
                {
                    MessageBox.Show("Cliente eliminado");
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente");
                }
            }
            llenarTabla();
        }
        private void PrecargarDatos(frmInformacionCliente ClientInfo)
        {
            ClientInfo.txtClientID.Text = dgvAdmiClientes.CurrentRow.Cells[0].Value.ToString();
            ClientInfo.txtClientName.Text = dgvAdmiClientes.CurrentRow.Cells[2].Value.ToString();
            ClientInfo.txtClientPhone.Text = dgvAdmiClientes.CurrentRow.Cells[4].Value.ToString();
            ClientInfo.txtClientAddress.Text = dgvAdmiClientes.CurrentRow.Cells[5].Value.ToString();
            ClientInfo.dtClientBirthDate.Value = Convert.ToDateTime(dgvAdmiClientes.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnAdminSubs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }
    }
}
