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
    public partial class frmInformacionUsuario: Form
    {
        public frmInformacionUsuario()
        {
            InitializeComponent();
        }
        sqlConexion conexionsql = new sqlConexion();
        public string modo = "add", userID = "";
        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;

            if (ValidacionDatos(username) == false)//Validar casillas vacías
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }
            if (ValidacionDatos(password) == false)
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (modo == "add")
            {
                AgregarUsuario(username, password);
            }
            else
            {
                ActualizarUsuario(username, password);
            }
        }
        private void AgregarUsuario(string username, string password)
        {
            int Admin = checkAdmin();
            string consulta = $"Insert into Users (Username,Password,Admin) values ('{username}','{password}',{Admin})";
            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Usuario creado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al agregar usuario");
            }
        }
        private void ActualizarUsuario(string username, string password)
        {
            int Admin = checkAdmin();
            string consulta = $"Update Users set Username='{username}', Password='{password}', Admin={Admin} where UserID='{userID}'";
            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Cliente actualizado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al actualizar cliente");
            }
        }
        private bool ValidacionDatos(string Dato)
        {
            if (Dato.Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int checkAdmin()
        {
            int Admin;
            if (chkAdmin.Checked)
            {
                Admin = 1;
            }
            else
            {
                Admin = 0;
            }
            return Admin;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
