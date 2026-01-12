using cibernopilosos.formularios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace cibernopilosos.formularios_de_registro
{
    public partial class frmMemberShip : Form
    {
        sqlConexion ConexionSql = new sqlConexion();
        public string idcliente;
        private string modo = "";

        public frmMemberShip(string modo)
        {
            InitializeComponent();
            this.modo = modo;
        }

        private void llenarTabla()
        {
            DataTable tabla = new DataTable();
            string consulta = "";
            dgvMembership.DataSource = null;

            if (modo == "1")
            {
                consulta = "Select c.ClientID, c.ClientName, cm.CMStartDate, cm.CMEndDate from ClientMembership as CM " +
                           "inner join Clients as C on CM.CMClientID=C.ClientID " +
                           "where cm.CMEndDate > GETDATE() " +
                           "group by ClientID, ClientName, CMStartDate, CMEndDate";
                tabla = ConexionSql.retornaRegistros(consulta);
            }
            else
            {
                tabla = ConexionSql.retornaRegistros("Select * from Membership");
            }

            // Validar si hay datos
            if (tabla == null || tabla.Rows.Count == 0)
            {
                MostrarEstadoVacio();
            }
            else
            {
                dgvMembership.DataSource = tabla;
                OcultarEstadoVacio();
            }
        }

        private void MostrarEstadoVacio()
        {
            dgvMembership.DataSource = null;
            dgvMembership.Visible = false;

            // Crear un label que indique el estado vacío
            Label lblVacio = new Label();
            lblVacio.Name = "lblEstadoVacio";
            lblVacio.Text = "No hay membresías disponibles.";
            lblVacio.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblVacio.ForeColor = Color.Gray;
            lblVacio.TextAlign = ContentAlignment.MiddleCenter;
            lblVacio.Dock = DockStyle.Fill;

            // Si ya existe el label, no lo agregues de nuevo
            if (this.Controls.Find("lblEstadoVacio", false).Length == 0)
            {
                this.Controls.Add(lblVacio);
                lblVacio.BringToFront();
            }
        }

        private void OcultarEstadoVacio()
        {
            dgvMembership.Visible = true;

            // Remover el label de estado vacío si existe
            Control[] controls = this.Controls.Find("lblEstadoVacio", false);
            if (controls.Length > 0)
            {
                this.Controls.Remove(controls[0]);
                controls[0].Dispose();
            }
        }


        private void frmMemberShip_Load(object sender, EventArgs e)
        {
            this.Font = new Font("Segoe UI", 9F); // Guideline #8: Fuentes consistentes

            if (modo == "1")
            {
                btnConfirmacion.Visible = false;
                lblValorCobrar.Visible = false;
                lbltextcobro.Visible = false;
                lblMemberShip.Text = "Membresías activas";
                lblMemberShip.Location = new Point(this.Size.Width / 4, this.Size.Height / 10);
                dgvMembership.SelectionChanged -= dgvMembership_SelectionChanged;
            }

            llenarTabla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            if (dgvMembership.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una membresía antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idmembresia = dgvMembership.CurrentRow.Cells["MembershipID"].Value.ToString();
            if (insertarClientMem(idmembresia))
            {
                string activarmem = $"update Clients set ClientMemStatus = 1 where ClientID = '{idcliente}'";
                ConexionSql.EjecutarAccion(activarmem);
                MessageBox.Show("Membresía activada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Membresía no activada. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool insertarClientMem(string idmembresia)
        {
            try
            {
                // Verificar si hay una caja abierta
                string consultaCajaAbierta = "SELECT TOP 1 IdCaja FROM Caja WHERE Estado = 1 ORDER BY FechaApertura DESC";
                int idCaja = ConexionSql.DevuelveValorEntero(consultaCajaAbierta);
                if (idCaja == 0)
                {
                    MessageBox.Show("No hay una caja abierta para registrar la transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Insertar en ClientMembership
                string consult = "INSERT INTO ClientMembership (CMClientID, CMMembershipID, CMStartDate, CMEndDate) SELECT " +
                                 "c.ClientID, m.MembershipID, GETDATE(), " +
                                 "DATEADD(day, COALESCE(m.MemDay, 0) + (COALESCE(m.MemMonth, 0) * 30) + (COALESCE(m.MemYear, 0) * 365), GETDATE()) " +
                                 "FROM Clients AS c, Membership AS m WHERE " +
                                 $"c.ClientID = '{idcliente}' AND m.MembershipID = {idmembresia};";
                if (!ConexionSql.EjecutarAccion(consult))
                {
                    MessageBox.Show("Error al registrar la membresía. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Obtener el ServiceID
                string consultaID = "SELECT s.ServiceID FROM Services_Products AS s " +
                                    "INNER JOIN Membership AS m ON s.ServiceName = m.MembershipName " +
                                    $"WHERE m.MembershipID = {idmembresia}";
                int serviceId = ConexionSql.DevuelveValorEntero(consultaID);

                // Obtener el precio
                string consultaPrecio = "SELECT s.ServicePrice FROM Services_Products AS s " +
                                        "INNER JOIN Membership AS m ON s.ServiceName = m.MembershipName " +
                                        $"WHERE m.MembershipID = {idmembresia}";
                decimal precio = ConexionSql.DevuelveValorDecimal(consultaPrecio);

                if (precio == 0)
                {
                    MessageBox.Show("No se encontró un precio válido para la membresía seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int idUsuario = frmLogin.UserIdActual;
                string precioSql = precio.ToString().Replace(',', '.');

                // Insertar en Transactions
                string sentencia = "INSERT INTO Transactions (IdCaja, TransClientID, TransServiceID, TransType, TransDescrip, " +
                                   "TransSUBTOTAL, TransDiscount, TransQuantity, TransDateTime, TransUserID, TransTOTAL, TransServicePrice) " +
                                   $"VALUES ({idCaja}, '{idcliente}', {serviceId}, 'ingreso', 'Membresía', {precioSql}, 0, 1, " +
                                   $"'{DateTime.Now:yyyy-MM-dd HH:mm:ss}', {idUsuario}, {precioSql}, {precioSql})";

                if (!ConexionSql.EjecutarAccion(sentencia))
                {
                    MessageBox.Show("Error al registrar la transacción. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvMembership_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembership.CurrentCell != null && dgvMembership.CurrentRow != null)
            {
                string idmembresia = dgvMembership.CurrentRow.Cells["MembershipID"].Value.ToString();
                string consulta = $"select s.ServicePrice from Services_Products as s " +
                                  $"inner join Membership as m on s.ServiceName=m.MembershipName " +
                                  $"where m.MembershipID = {idmembresia}";
                decimal precio = Math.Round(ConexionSql.DevuelveValorDecimal(consulta), 2);
                lblValorCobrar.Text = precio.ToString("C2"); // Formato moneda
            }
        }
    }
}
