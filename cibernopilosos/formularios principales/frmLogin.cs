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
        public static string UserActual;

        public frmLogin()
        {
            InitializeComponent();
        }

        sqlConexion conexion = new sqlConexion();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fn_ProcedimientodeLogin();
        }
        private void fn_ProcedimientodeLogin()
        {
            string username = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();
            UserActual = username;
            comprobarAcceso(username, password);
        }

        private void comprobarAcceso(string username, string password)
        {
            if (username!= "" && password!="")
            {
                if (conexion.Login(username.Trim(), password.Trim()))
                {
                    bool admin = conexion.DevuelveValorBooleano($"Select Admin from Users Where Username='{username}' and Password='{password}'");
                    frmMenu menu = new frmMenu(admin);
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
            btnShowPassword.Image = imgListLogin.Images[3];
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fn_ProcedimientodeLogin();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fn_ProcedimientodeLogin();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Image = imgListLogin.Images[2];
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Image = imgListLogin.Images[3];
            }
        }
    }
}
