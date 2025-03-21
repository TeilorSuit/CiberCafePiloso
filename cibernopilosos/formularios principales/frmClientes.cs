using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using cibernopilosos.formularios_de_registro;

namespace cibernopilosos.formularios
{
    public partial class frmClientes : Form
    {
        sqlConexion ConexionSql = new sqlConexion();

        public int TiempoHorasCalculados { get; set; }
        public int TiempoMinutosCalculados { get; set; }
        public bool VinculacionMode { get; set; }
        public string SelectedPcIp { get; set; } = "";

        public frmClientes()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void llenarTabla()
        {
            string consulta = "select * from Clients";
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvAdmiClientes.DataSource = "";
            dgvAdmiClientes.DataSource = tabla;
            cambiarNombreColumnas(tabla);
        }

        private void cambiarNombreColumnas(DataTable tabla)
        {
            if (tabla.Columns.Contains("ClientID"))
                dgvAdmiClientes.Columns["ClientID"].HeaderText = "ID";
            if (tabla.Columns.Contains("ClientMemStatus"))
                dgvAdmiClientes.Columns["ClientMemStatus"].HeaderText = "Membresía";
            if (tabla.Columns.Contains("ClientName"))
                dgvAdmiClientes.Columns["ClientName"].HeaderText = "Nombre";
            if (tabla.Columns.Contains("ClientBirthDate"))
                dgvAdmiClientes.Columns["ClientBirthDate"].HeaderText = "Fecha de Nacimiento";
            if (tabla.Columns.Contains("ClientPhone"))
                dgvAdmiClientes.Columns["ClientPhone"].HeaderText = "Teléfono";
            if (tabla.Columns.Contains("ClientAddress"))
                dgvAdmiClientes.Columns["ClientAddress"].HeaderText = "Dirección";
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmInformacionCliente ClientInfo = new frmInformacionCliente();
            ClientInfo.modo = "add";
            ClientInfo.btnConfirmacion.Text = "Registrar";
            ClientInfo.ShowDialog();
            llenarTabla();
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            frmInformacionCliente ClientInfo = new frmInformacionCliente();
            PrecargarDatos(ClientInfo);
            ClientInfo.aux_id = dgvAdmiClientes.CurrentRow.Cells[0].Value.ToString();
            ClientInfo.modo = "edit";
            ClientInfo.btnConfirmacion.Text = "Actualizar";
            ClientInfo.ShowDialog();
            llenarTabla();
        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            string clienteId = dgvAdmiClientes.CurrentRow.Cells["ClientID"].Value.ToString();
            string clienteName = dgvAdmiClientes.CurrentRow.Cells["ClientName"].Value.ToString();
            DialogResult confirmacion;
            confirmacion = MessageBox.Show($"Está acción borrará absolutamente todos los registros existentes del cliente {clienteName}. ¿Desea continuar?", "ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (confirmacion == DialogResult.OK)
            {
                sqlConexion ConexionSql = new sqlConexion();
                // Se eliminan registros relacionados en otras tablas y luego el cliente
                string comando = $"delete from ClientMembership where CMClientID = '{clienteId}';" +
                                 $"delete from ClientComputer where CC_ClientID = '{clienteId}';" +
                                 $"delete from Transactions where TransClientID = '{clienteId}';" +
                                 $"delete from Clients where ClientID = '{clienteId}';";
                if (ConexionSql.EjecutarAccion(comando))
                {
                    MessageBox.Show("Cliente eliminado");
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente");
                }
            }
            llenarTabla();
        }

        private void PrecargarDatos(frmInformacionCliente ClientInfo)
        {
            ClientInfo.txtClientID.Text = dgvAdmiClientes.CurrentRow.Cells[0].Value.ToString();
            ClientInfo.txtClientName.Text = dgvAdmiClientes.CurrentRow.Cells[2].Value.ToString();
            ClientInfo.txtClientPhone.Text = dgvAdmiClientes.CurrentRow.Cells[4].Value.ToString();
            ClientInfo.txtClientAddress.Text = dgvAdmiClientes.CurrentRow.Cells[5].Value.ToString();
            ClientInfo.dtClientBirthDate.Value = Convert.ToDateTime(dgvAdmiClientes.CurrentRow.Cells[3].Value.ToString());
        }


        // Evento para vincular la computadora con el cliente seleccionado - Kenneth
        private void btnVincularPc_Click(object sender, EventArgs e)
        {
            if (dgvAdmiClientes.CurrentRow != null)
            {
                // Obtener datos del cliente seleccionado
                string clientId = dgvAdmiClientes.CurrentRow.Cells["ClientID"].Value.ToString();
                string clientName = dgvAdmiClientes.CurrentRow.Cells["ClientName"].Value.ToString();

                // Verificar que la IP de la PC se haya asignado
                if (string.IsNullOrEmpty(SelectedPcIp))
                {
                    MessageBox.Show("No se ha seleccionado una computadora.");
                    return;
                }

                // Crear la descripción para la transacción
                string descripcion = $"Vinculación de PC {SelectedPcIp} con Cliente {clientName}";

                sqlConexion ConexionSql = new sqlConexion();

                // Consultar el precio por hora (se asume que ServiceID = 2 es "Precioxhora PC")
                string consultaPrecio = "SELECT ServicePrice FROM Services_Products WHERE ServiceID = 2";
                decimal precioHora = ConexionSql.DevuelveValorDecimal(consultaPrecio);

                // Calcular el tiempo total en horas (conversión de minutos a fracción de hora)
                decimal tiempoTotal = TiempoHorasCalculados + ((decimal)TiempoMinutosCalculados / 60m);
                decimal transServicePrice = tiempoTotal * precioHora;

                // Consultar el descuento activo del cliente (si tiene membresía activa)
                string consultaDescuento = "SELECT ISNULL((SELECT m.Discount FROM Membership m " +
                    "INNER JOIN ClientMembership cm ON m.MembershipID = cm.CMMembershipID " +
                    $"WHERE cm.CMClientID = '{clientId}' AND GETDATE() BETWEEN cm.CMStartDate AND cm.CMEndDate), 0)";
                object resultadoDescuento = ConexionSql.DevuelveValorDecimal(consultaDescuento);
                decimal discountValue = 0m;
                if (resultadoDescuento != null && resultadoDescuento != DBNull.Value)
                {
                    try
                    {
                        discountValue = Convert.ToDecimal(resultadoDescuento, CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        discountValue = 0m;
                    }
                }

                // Calcular el descuento, subtotal y total
                decimal transDiscount = transServicePrice * discountValue;
                decimal transSubTotal = transServicePrice - transDiscount;
                decimal transTotal = transSubTotal+(transSubTotal * 0.15m);

                // Construir la consulta INSERT para Transactions
                string queryTransactions = $"INSERT INTO Transactions (TransClientID, TransServicesID, TransDescrip, TransSubTotal, TransDiscount, TransQuantity, TransDateTime, TransUsername, TransTotal, TransServicePrice) " +
                               $"VALUES ('{clientId}', 2, '{descripcion}', " +
                               $"{transSubTotal.ToString(CultureInfo.InvariantCulture)}, " +
                               $"{transDiscount.ToString(CultureInfo.InvariantCulture)}, " +
                               $"1, '{DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")}', 'admin', " +
                               $"{transTotal.ToString(CultureInfo.InvariantCulture)}, " +
                               $"{transServicePrice.ToString(CultureInfo.InvariantCulture)})";

                bool transOk = ConexionSql.EjecutarAccion(queryTransactions);

                // Insertar registro en ClientComputer
                // Se registra: PcIp, ClientID, la fecha actual (GETDATE()) y el tiempo usado en minutos
                int totalTimeUsed = (TiempoHorasCalculados * 60) + TiempoMinutosCalculados;
                string queryClientComputer = $"INSERT INTO ClientComputer (CC_PcIP, CC_ClientID, CC_DateTime, CC_TimeUsed) " +
                                             $"VALUES ('{SelectedPcIp}', '{clientId}', GETDATE(), {totalTimeUsed})";
                bool ccOk = ConexionSql.EjecutarAccion(queryClientComputer);

                if (transOk && ccOk)
                {
                    MessageBox.Show("Vinculación exitosa. Transacción registrada y PC vinculada.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al vincular la computadora con el cliente.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para vincular.");
            }
        }


        private void btnAddMembership_Click(object sender, EventArgs e)
        {
            frmMemberShip Membership = new frmMemberShip("");
            Membership.idcliente = dgvAdmiClientes.CurrentRow.Cells["ClientID"].Value.ToString();
            Membership.ShowDialog();
            llenarTabla();
        }

        private void btnDeleteMembership_Click(object sender, EventArgs e)
        {

            string idcliente = dgvAdmiClientes.CurrentRow.Cells["ClientID"].Value.ToString();
            string clienteName = dgvAdmiClientes.CurrentRow.Cells["ClientName"].Value.ToString();
            DialogResult confirmacion;
            confirmacion = MessageBox.Show($"¿Está seguro que desea inhabilitar la membresía del cliente {clienteName}.?", "ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (confirmacion == DialogResult.OK)
            {
                sqlConexion ConexionSql = new sqlConexion();
                string comando = "update Clients set ClientMemStatus = 0 where ClientID = '" + idcliente + "'; " +
                                 "update ClientMembership set CMEndDate = GETDATE() where CMClientID = '" + idcliente + "'";


                if (ConexionSql.EjecutarAccion(comando))
                {
                    MessageBox.Show("Membresía inhabilitada");
                }
                else
                {
                    MessageBox.Show("Error al inhabilitar la membresía");
                }
            }
            llenarTabla();
        }

        private void btnVisorMembresias_Click(object sender, EventArgs e)
        {
            frmMemberShip Membership = new frmMemberShip("1");
            Membership.ShowDialog();
            llenarTabla();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            if (VinculacionMode)
            {
                btnAgregarCliente.Visible = false;
                btnEditarCliente.Visible = false;
                btnBorrarCliente.Visible = false;
                pnlMembership.Visible = false;
            }
            else
            {
                btnVModeCerrar.Visible = false;
                btnVincularPc.Visible = false;
            }

            verificarMembresias();
        }

        private void verificarMembresias()
        {
            string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
            string consultaCaducadas =
                "SELECT cm.CMClientID " +
                "FROM ClientMembership cm " +
                "WHERE CONVERT(date, cm.CMEndDate) = '" + fechaHoy + "'";

            DataTable dtCaducadas = ConexionSql.retornaRegistros(consultaCaducadas);

            foreach (DataRow row in dtCaducadas.Rows)
            {
                string clientId = row["CMClientID"].ToString();
                string updateQuery =
                    "UPDATE Clients " +
                    "SET ClientMemStatus = 0 " +
                    "WHERE ClientID = '" + clientId + "'";
                ConexionSql.EjecutarAccion(updateQuery);
            }
        }

        private void btnVModeCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}