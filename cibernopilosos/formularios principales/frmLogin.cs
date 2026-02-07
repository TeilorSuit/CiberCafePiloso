using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration; // <--- AGREGA ESTO

namespace cibernopilosos.formularios
{
    public partial class frmLogin : Form
    {
        public static int UserIdActual;
        public static string UserActual;

        // CAMBIO: Ya no escribimos la conexión aquí. La leemos del archivo de configuración.
        // Así, si cambia el servidor, solo cambias el archivo de texto y no el código.
        private string connectionString = ConfigurationManager.ConnectionStrings["CiberCafeDB"].ConnectionString;

        public frmLogin()
        {
            InitializeComponent();
        }

        // ... El resto de tu código sigue igual ...

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ProcedimientoLogin();
        }

        private void ProcedimientoLogin()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                lblIncorrectPassword.Text = "Rellene todos los campos";
                return;
            }

            ValidarUsuario(username, password);
        }

        private void ValidarUsuario(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT UserID, Admin
                        FROM Users
                        WHERE Username = @user AND Password = @pass";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parámetros (PROTEGE contra SQL Injection)
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Usuario válido
                                UserIdActual = Convert.ToInt32(reader["UserID"]);
                                bool admin = Convert.ToBoolean(reader["Admin"]);
                                UserActual = username;

                                frmMenu menu = new frmMenu(admin);
                                this.Hide();
                                menu.Show();
                            }
                            else
                            {
                                lblIncorrectPassword.Text = "Usuario o contraseña incorrectos";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (lblIncorrectPassword.Text.Length > 0)
                lblIncorrectPassword.Text = "";
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcedimientoLogin();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcedimientoLogin();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnLogin.Image = imgListLogin.Images[1];
            btnShowPassword.Image = imgListLogin.Images[3];
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.Image = imgListLogin.Images[0];
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.Image = imgListLogin.Images[1];
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
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
