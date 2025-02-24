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
    public partial class frmMenu : Form
    {
        public frmMenu(string modo)
        {
            InitializeComponent();
            checkUser(modo);
        }

        #region Formularios Activos

        private Form FormulariosAbierto = null;

        private void abrirFormularioHijo(Form FormularioHijo)
        {
            if (FormularioHijo == null)//cambia el mensaje de excepcion
                throw new ArgumentNullException(nameof(FormularioHijo));

            if (FormulariosAbierto != null)
                FormulariosAbierto.Close();

            FormulariosAbierto = FormularioHijo;
            FormularioHijo.TopLevel = false;
            FormularioHijo.FormBorderStyle = FormBorderStyle.None;
            FormularioHijo.Dock = DockStyle.Fill;
            pnlChildForms.Controls.Add(FormularioHijo);
            FormularioHijo.BringToFront();
            FormularioHijo.Show();
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
                flwSideBar.Width -= 10;
                if (flwSideBar.MinimumSize.Width == flwSideBar.Width)
                {
                    MenuTamanoMaximo = false;
                    tmrSideBar.Stop();
                }
            }
            else
            {
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
            frmComputadoras computadoras = new frmComputadoras();
            abrirFormularioHijo(computadoras);
        }

        private void btnAdministrarPcs_Click(object sender, EventArgs e)
        {
            frmAdministrarComputadoras administrarmComputadoras = new frmAdministrarComputadoras();
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
            frmReportes Reportes = new frmReportes();
            abrirFormularioHijo(Reportes);
        }
        #endregion

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkUser(string user)
        {
            if (user != "1")
            {
                btnAdministrarPcs.Hide();
                btnUsuarios.Hide();
                btnReportes.Hide();
            }
        }
    }
}
