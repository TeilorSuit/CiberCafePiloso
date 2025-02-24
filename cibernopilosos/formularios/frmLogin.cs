using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void comprobarContra()
        {
            sqlConexion conexion = new sqlConexion();
            if (txtUserName.Text != ""&& txtPassword.Text !="")
            {
                string username = txtUserName.Text.ToString();
                string password = txtPassword.Text.ToString();
                if (conexion.Login(username, password))
                {
                    DataTable tablita = conexion.retornaRegistros($"Select UserID from Users Where Username='{username}' and Password='{password}'");
                    frmMenu menu = new frmMenu(tablita.Rows[0][0].ToString());
                    this.Hide();
                    menu.Show();
                }
                else lblIncorrectPassword.Text = "Contraseña o Usuario Incorreto";
            }
            else
            {
                lblIncorrectPassword.Text = "Rellene todos los campos";
            }
        }
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.Image = imgListLogin.Images[0];
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.Image = imgListLogin.Images[1];
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            comprobarContra();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Image = imgListLogin.Images[3];
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Image = imgListLogin.Images[2];
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (lblIncorrectPassword.Text.Length > 0)
            {
                lblIncorrectPassword.Text = "";
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnLogin.Image = imgListLogin.Images[1];
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comprobarContra();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comprobarContra();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            DialogResult pepa;
            pepa = MessageBox.Show("Creador: Marlon", "El Creador", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, displayHelpButton: false);
            if (pepa == DialogResult.No)
            {
                MessageBox.Show("Sí es");
            }
        }
    }
}
