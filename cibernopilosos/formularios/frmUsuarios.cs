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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            frmInformacionUsuario frm = new frmInformacionUsuario();
            frm.modo = "add";
            frm.btnConfirmacion.Text = "Registrar";
            frm.ShowDialog();
            llenarTabla();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            frmInformacionUsuario frm = new frmInformacionUsuario();
            frm.modo = "edit";
            frm.btnConfirmacion.Text = "Editar";
            frm.userID = dgvUsers.CurrentRow.Cells[0].Value.ToString();
            PrecargarDatos(frm);
            frm.ShowDialog();
            llenarTabla();
        }


        private void PrecargarDatos(frmInformacionUsuario UserInfo)
        {
            UserInfo.txtUsername.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            UserInfo.txtPassword.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
        }
        private void llenarTabla()
        {
            sqlConexion ConexionSql = new sqlConexion();
            string consulta = "select * from Users";
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = tabla;
        }

        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion;
            confirmacion = MessageBox.Show("Está acción no se puede deshacer. ¿Desea continuar?", "ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (confirmacion == DialogResult.OK)
            {
                sqlConexion ConexionSql = new sqlConexion();
                string comando = $"delete from Users where UserID='{dgvUsers.CurrentRow.Cells[0].Value.ToString()}'";
                if (ConexionSql.EjecutarAccion(comando))
                {
                    MessageBox.Show("Cliente eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente");
                }
            }
            llenarTabla();
        }
    }
}
