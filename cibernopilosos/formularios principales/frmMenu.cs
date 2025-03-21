using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Computadoras formularioComputadoras = null;

        private void abrirFormularioHijo(Form FormularioHijo)
        {
            try
            {
                if (FormularioHijo != null)
                {
                    if (FormularioHijo is Computadoras)//comprobar si el existe un computadoras abierto pa q no se reinice
                    {
                        if (formularioComputadoras != null)
                        {
                            FormularioHijo = formularioComputadoras;
                        }
                        else
                        {
                            formularioComputadoras = (Computadoras)FormularioHijo; 
                        }
                    }
                    if (FormulariosAbierto != null && FormulariosAbierto != FormularioHijo)
                    {
                        if (FormulariosAbierto != formularioComputadoras)
                        {
                            FormulariosAbierto.Close();
                        }
                    }

                    FormulariosAbierto = FormularioHijo;
                    FormularioHijo.TopLevel = false;
                    FormularioHijo.FormBorderStyle = FormBorderStyle.None;
                    FormularioHijo.Dock = DockStyle.Fill;

                    if (!pnlChildForms.Controls.Contains(FormularioHijo))
                    {
                        pnlChildForms.Controls.Add(FormularioHijo);
                    }
                    FormularioHijo.BringToFront();
                    FormularioHijo.Show();
                }
                else
                {
                    throw new ArgumentNullException(nameof(FormularioHijo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (formularioComputadoras == null)
            {
                formularioComputadoras = new Computadoras();
            }
            abrirFormularioHijo(formularioComputadoras);
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
            // Al cerrarse Form1, se dispara este evento:
            //form1.FormClosed += (s, args) =>
            //{
            //    // Re-mostrar el menú
            //    this.Show();
            //};

            //this.Hide();
            //form1.Show();
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
    }
}