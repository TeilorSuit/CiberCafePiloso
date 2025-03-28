using System;
using System.Windows.Forms;
using cibernopilosos.formularios_principales;
using Presentation;

namespace cibernopilosos.formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu(bool modo)
        {
            InitializeComponent();
            checkUser(modo);
            //Saludito(frmLogin.UserActual.Trim());
        }

        private void Saludito(string user = "mundo")
        {
            string capitalizado;
            if (string.IsNullOrEmpty(user)) capitalizado = "Mundo:D";
            else capitalizado = char.ToUpper(user[0]) + user.Substring(1).ToLower();
            lblUsuariologin.Text = capitalizado + "!";
        }

        private void checkUser(bool admin)
        {
            if (!admin)
            {
                btnAdministrarPcs.Hide();
                btnUsuarios.Hide();
                btnReportes.Hide();
                pnlSeparador.Hide();
            }
        }

        #region Formularios Activos

        private Form FormulariosAbierto = null;
        private Computadoras formularioComputadoras = new Computadoras();

        private void abrirFormularioHijo(Form FormularioHijo)
        {
            try
            {
                if (FormularioHijo == formularioComputadoras)
                {
                    if (!pnlChildForms.Controls.Contains(FormularioHijo))
                    {
                        ConfigurarFormularioHijo(FormularioHijo);
                    }
                    FormularioHijo.BringToFront();
                    FormularioHijo.Show();
                    FormulariosAbierto = FormularioHijo;
                    return; 
                }

                if (FormulariosAbierto != null && FormulariosAbierto != formularioComputadoras)
                {
                    FormulariosAbierto.Close();
                }

                FormulariosAbierto = FormularioHijo;
                ConfigurarFormularioHijo(FormularioHijo);
                FormularioHijo.BringToFront();
                FormularioHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarFormularioHijo(Form formulario)
        {
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            if (!pnlChildForms.Controls.Contains(formulario))
            {
                pnlChildForms.Controls.Add(formulario);
            }
        }

        #endregion

        #region AmpliarMenu
        private void btnAmpliarMenu_Click(object sender, EventArgs e)
        {
            tmrSideBar.Start();
        }
        private bool MenuTamanoMaximo = true;
        private void tmrSideBar_Tick(object sender, EventArgs e)
        {
            if (MenuTamanoMaximo)
            {
                lblUsuariologin.Hide();
                lblHola.Hide();
                flwSideBar.Width -= 10;
                if (flwSideBar.MinimumSize.Width == flwSideBar.Width)
                {
                    MenuTamanoMaximo = false;
                    tmrSideBar.Stop();
                }
            }
            else
            {
                lblUsuariologin.Show();
                lblHola.Show();
                flwSideBar.Width += 10;
                if (flwSideBar.MaximumSize.Width == flwSideBar.Width)
                {
                    MenuTamanoMaximo = true;
                    tmrSideBar.Stop();
                }
            }
        }

        #endregion

        #region Botones

        private void btnComputadoras_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(formularioComputadoras);
            formularioComputadoras.mostrarComputadorasEnPanel();
        }

        private void btnAdministrarPcs_Click(object sender, EventArgs e)
        {
            frmAdminPcs administrarmComputadoras = new frmAdminPcs();
            abrirFormularioHijo(administrarmComputadoras);
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            abrirFormularioHijo(clientes);
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            abrirFormularioHijo(usuarios);
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            abrirFormularioHijo(form1);
        }
        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            frmTrans Trans = new frmTrans();
            abrirFormularioHijo(Trans);
        }

        #endregion

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void flwSideBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}