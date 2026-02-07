using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.Interfaces;

namespace cibernopilosos.formularios
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            llenarTabla(true);
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            frmInformacionUsuario frm = new frmInformacionUsuario();
            frm.modo = "add";
            frm.btnConfirmacion.Text = "Registrar";
            frm.ShowDialog();
            llenarTabla(true);
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            frmInformacionUsuario frm = new frmInformacionUsuario();
            frm.modo = "edit";
            frm.btnConfirmacion.Text = "Editar";
            frm.AuxUserID = dgvUsers.CurrentRow.Cells["UserID"].Value.ToString();
            PrecargarDatos(frm);
            frm.ShowDialog();
            llenarTabla(true);
        }

        private void PrecargarDatos(frmInformacionUsuario UserInfo)
        {
            UserInfo.txtUsername.Text = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            UserInfo.txtPassword.Text = dgvUsers.CurrentRow.Cells["Password"].Value.ToString();
        }
        private void llenarTabla(bool modo)
        {
            sqlConexion ConexionSql = new sqlConexion();
            string consulta;
            if (modo)
            {
                consulta = "select UserID, Username, Password, Admin from Users";
                btnResgistrosCaja.Text = "Ver registros de caja";
            }
            else
            {
                consulta = "select * from Caja";
                btnResgistrosCaja.Text = "Ver Usuarios";

            }
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvUsers.DataSource = "";
            dgvUsers.DataSource = tabla;
        }

        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            string useridactual = frmLogin.UserIdActual.ToString();
            if (dgvUsers.CurrentRow.Cells["UserID"].Value.ToString() == useridactual)
            {
                MessageBox.Show("No puedes eliminar tu propio usuario");
                return;
            }

            DialogResult confirmacion;
            confirmacion = MessageBox.Show("Está acción no se puede deshacer. ¿Desea continuar?", "ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (confirmacion == DialogResult.OK)
            {
                sqlConexion ConexionSql = new sqlConexion();
                string comando = $"delete from Users where UserID={dgvUsers.CurrentRow.Cells["UserID"].Value}";
                if (ConexionSql.EjecutarAccion(comando))
                {
                    MessageBox.Show("Cliente eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente");
                }
            }
            llenarTabla(true);
        }

        bool modolol = true;
        private void btnResgistrosCaja_Click(object sender, EventArgs e)
        {
            modolol = !modolol;
            llenarTabla(modolol);
            btnAgregarUsuario.Visible = modolol;
            btnEditarUsuario.Visible = modolol;
            btnBorrarUsuario.Visible = modolol;
        }
    }
}
