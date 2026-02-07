using System;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmInformacionUsuario : Form
    {
        public frmInformacionUsuario()
        {
            InitializeComponent();
        }

        sqlConexion conexionsql = new sqlConexion();
        public string modo = "add";
        public string AuxUserID; 

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!ValidacionDatos(username))
            {
                MessageBox.Show("Rellene el campo Usuario");
                return;
            }
            if (!ValidacionDatos(password))
            {
                MessageBox.Show("Rellene el campo Contraseña");
                return;
            }

            username = username.Replace("'", "''");
            password = password.Replace("'", "''");

            if (modo == "add")
            {
                AgregarUsuario(username, password);
            }
            else
            {
                ActualizarUsuario(username, password);
            }

            this.Close();
        }

        private void AgregarUsuario(string username, string password)
        {
            int Admin = checkAdmin();

            string consulta = $"INSERT INTO Users (Username, Password, Admin) VALUES ('{username}', '{password}', {Admin})";

            if (conexionsql.EjecutarAccion(consulta))
            {
                string actor = frmLogin.UserActual;
                string detalle = $"Creó el usuario: {username} (Admin: {Admin})";
                string logQuery = $"INSERT INTO Auditoria (UsuarioActor, Accion, Detalle, Fecha) VALUES ('{actor}', 'CREAR USUARIO', '{detalle}', GETDATE())";
                conexionsql.EjecutarAccion(logQuery);

                MessageBox.Show("Usuario creado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al agregar usuario (probablemente el nombre ya existe)");
            }
        }

        private void ActualizarUsuario(string username, string password)
        {
            int Admin = checkAdmin();

            string consulta = $"UPDATE Users SET Username='{username}', Password='{password}', Admin={Admin} WHERE UserID={AuxUserID}";

            if (conexionsql.EjecutarAccion(consulta))
            {
                string actor = frmLogin.UserActual;
                string detalle = $"Editó al usuario ID {AuxUserID}. Nuevo nombre: {username}";
                string logQuery = $"INSERT INTO Auditoria (UsuarioActor, Accion, Detalle, Fecha) VALUES ('{actor}', 'EDITAR USUARIO', '{detalle}', GETDATE())";
                conexionsql.EjecutarAccion(logQuery);

                MessageBox.Show("Usuario actualizado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al actualizar usuario");
            }
        }

        private bool ValidacionDatos(string Dato)
        {
            return !string.IsNullOrEmpty(Dato);
        }

        private int checkAdmin()
        {
            return chkAdmin.Checked ? 1 : 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}