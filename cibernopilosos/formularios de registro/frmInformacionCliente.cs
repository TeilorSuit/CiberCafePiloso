using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    public partial class frmInformacionCliente: Form
    {
        sqlConexion conexionsql = new sqlConexion();

        public frmInformacionCliente()
        {
            InitializeComponent();
            dtClientBirthDate.MaxDate = DateTime.Today.AddYears(-18);
            btnConfirmacion.Enabled = false;
        }
        private void AgregarCliente(string clientId, string clientName, DateTime clientBirthDate, string clientPhone, string clientAddress)
        {
            string fechaFormateada = clientBirthDate.ToString("yyyy-MM-dd");
            string consulta = $"Insert into Clients (ClientID, ClientMemStatus, ClientName, ClientBirthDate, ClientPhone, ClientAddress) " +
                  $"values ('{clientId}', 0, '{clientName}', '{fechaFormateada}', '{clientPhone}', '{clientAddress}')";

            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Cliente registrado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al registrar cliente");
            }
        }

        private void ActualizarCliente(string clientId, string clientName, DateTime clientBirthDate, string clientPhone, string clientAddress)
        {
            string fechaFormateada = clientBirthDate.ToString("yyyy-MM-dd");
            string consulta = $"Update Clients set ClientID='{clientId}',ClientName='{clientName}',ClientBirthDate='{fechaFormateada}',ClientPhone='{clientPhone}',ClientAddress='{clientAddress}' where ClientID='{aux_id}'";
            if (conexionsql.EjecutarAccion(consulta))
            {
                MessageBox.Show("Cliente actualizado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al actualizar cliente");
            }
        }


        public string modo = "add", aux_id = "";
        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            string clientID, clientName,clientPhone,clientAddress;
            DateTime clientBirthdate;

            clientID = txtClientID.Text;
            clientName = txtClientName.Text;
            clientPhone = txtClientPhone.Text;
            clientAddress = txtClientAddress.Text;
            clientBirthdate = dtClientBirthDate.Value;

            if (validacionDatos(clientID) == false)//Validar casillas vacías
            {
                MessageBox.Show("Rellene todos los campos obligatorios");
                return;
            }
            if (validacionDatos(clientName) == false)
            {
                MessageBox.Show("Rellene todos los campos obligatorios");
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
        private bool validacionDatos(string Dato)//pepe
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

        private void txtClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //trozo robado
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
            if (txtClientID.Text.Length < 10)
            {
                btnConfirmacion.Enabled = false;
            }
            else
            {
                btnConfirmacion.Enabled = true;
            }
        }

        private void txtClientPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtClientPhone.Text.Length < 10 && txtClientPhone.Text.Length !=0)
            {
                btnConfirmacion.Enabled = false;
            }
            else
            {
                if (txtClientID.Text.Length == 10)
                {
                    btnConfirmacion.Enabled = true;
                }
                else
                {
                    btnConfirmacion.Enabled = false;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
