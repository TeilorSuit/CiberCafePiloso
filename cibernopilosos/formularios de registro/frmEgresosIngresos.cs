using cibernopilosos.formularios;
using System;
using System.Windows.Forms;

namespace cibernopilosos.formularios_de_registro
{
    public partial class frmEgresosIngresos : Form
    {
        private sqlConexion conexion = new sqlConexion();

        public frmEgresosIngresos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una caja abierta
            string consultaCajaAbierta = "SELECT TOP 1 IdCaja FROM Caja WHERE Estado = 1 ORDER BY FechaApertura DESC";
            int idCaja = conexion.DevuelveValorEntero(consultaCajaAbierta);

            if (idCaja == 0)
            {
                MessageBox.Show("No hay una caja abierta para registrar la transacción.");
                return;
            }

            if (cmbTipo.SelectedIndex == -1 || txtDescripcion.Text == null || txtMonto.Text == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            decimal monto;
            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            string tipo = cmbTipo.SelectedItem.ToString().ToLower(); // trabajamos con minúsculas
            string idUsuario = frmLogin.UserIdActual.ToString();

            string insertardatos = $"INSERT INTO Transactions (IdCaja, TransClientID, TransServiceID, TransType, TransDescrip, TransSUBTOTAL, TransDiscount, TransQuantity, TransDateTime, TransUserID, TransTOTAL, TransServicePrice) " +
                                 $"VALUES ({idCaja}, '0000000000', 6, '{tipo}', '{txtDescripcion.Text}', {monto}, 0, 1, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {idUsuario}, {monto}, {monto})";
            if (conexion.EjecutarAccion(insertardatos))
            {
                MessageBox.Show("Transacción registrada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar la transacción.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
