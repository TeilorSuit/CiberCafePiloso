using System;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmInformacionCliente : Form
    {
        sqlConexion conexionsql = new sqlConexion();

        public frmInformacionCliente()
        {
            InitializeComponent();
            dtClientBirthDate.MaxDate = DateTime.Today.AddYears(-18); // No menores de 18 años
            dtClientBirthDate.MinDate = DateTime.Today.AddYears(-120); // No mayores de 120 años
            btnConfirmacion.Enabled = false;
        }

        private void AgregarCliente(string clientId, string clientName, DateTime clientBirthDate, string clientPhone, string clientAddress)
        {
            string fechaFormateada = clientBirthDate.ToString("yyyy-MM-dd");
            string consulta = "Insert into Clients (ClientID, ClientMemStatus, ClientName, ClientBirthDate, ClientPhone, ClientAddress) " +
                  $"values ('{clientId}', 0, '{clientName}', '{fechaFormateada}', '{clientPhone}', '{clientAddress}')";

            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Cliente registrado exitosamente.");
            }
            else
            {
                MessageBox.Show("Error al registrar cliente. Intente nuevamente.");
            }
        }

        private void ActualizarCliente(string clientId, string clientName, DateTime clientBirthDate, string clientPhone, string clientAddress)
        {
            string fechaFormateada = clientBirthDate.ToString("yyyy-MM-dd");
            string consulta = $"Update Clients set ClientID='{clientId}',ClientName='{clientName}',ClientBirthDate='{fechaFormateada}',ClientPhone='{clientPhone}',ClientAddress='{clientAddress}' where ClientID='{aux_id}'";
            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Cliente actualizado exitosamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar cliente. Intente nuevamente.");
            }
        }

        public string modo = "add", aux_id = "";

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string clientID = txtClientID.Text.Trim();
            string clientName = txtClientName.Text.Trim();
            string clientPhone = txtClientPhone.Text.Trim();
            string clientAddress = txtClientAddress.Text.Trim();
            DateTime clientBirthdate = dtClientBirthDate.Value;

            // Validar campos obligatorios
            if (!validacionDatos(clientID))
            {
                MessageBox.Show("La cédula es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClientID.Focus();
                return;
            }

            if (!validacionDatos(clientName))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClientName.Focus();
                return;
            }

            // Validar formato de cédula (solo números, 10 dígitos)
            if (!validarCedula(clientID))
            {
                MessageBox.Show("La cédula debe tener exactamente 10 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClientID.Focus();
                return;
            }

            // Validar fecha de nacimiento
            if (!validarFechaNacimiento(clientBirthdate))
            {
                MessageBox.Show("La fecha de nacimiento debe ser de un mayor de edad (18+ años).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtClientBirthDate.Focus();
                return;
            }

            // Validar teléfono si está lleno
            if (clientPhone.Length > 0 && !validarTelefono(clientPhone))
            {
                MessageBox.Show("El teléfono debe tener exactamente 10 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClientPhone.Focus();
                return;
            }

            if (modo == "add")
            {
                AgregarCliente(clientID, clientName, clientBirthdate, clientPhone, clientAddress);
            }
            else
            {
                ActualizarCliente(clientID, clientName, clientBirthdate, clientPhone, clientAddress);
            }
            this.Close();
        }

        private bool validacionDatos(string dato)
        {
            return !string.IsNullOrWhiteSpace(dato);
        }

        private bool validarCedula(string cedula)
        {
            return cedula.Length == 10 && long.TryParse(cedula, out _);
        }

        private bool validarFechaNacimiento(DateTime fecha)
        {
            // No puede ser mayor a hoy
            if (fecha > DateTime.Today)
                return false;

            // No puede ser menor de 18 años
            if (DateTime.Today.AddYears(-18) < fecha)
                return false;

            return true;
        }

        private bool validarTelefono(string telefono)
        {
            return telefono.Length == 10 && long.TryParse(telefono, out _);
        }

        private void txtClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClientPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            ActualizarBotonConfirmacion();
        }

        private void txtClientPhone_TextChanged(object sender, EventArgs e)
        {
            ActualizarBotonConfirmacion();
        }

        private void ActualizarBotonConfirmacion()
        {
            bool cedulaValida = txtClientID.Text.Length == 10;
            bool nombreValido = !string.IsNullOrWhiteSpace(txtClientName.Text);
            bool telefonoValido = txtClientPhone.Text.Length == 0 || txtClientPhone.Text.Length == 10;

            btnConfirmacion.Enabled = cedulaValida && nombreValido && telefonoValido;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
