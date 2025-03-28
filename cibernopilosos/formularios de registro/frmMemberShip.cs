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
            dgvMembership.DataSource = "";
            if (modo == "1")
            {
                consulta =
                    "Select c.ClientID,c.ClientName,cm.CMStartDate,cm.CMEndDate from ClientMembership as CM inner join Clients as C on CM.CMClientID=C.ClientID where cm.CMEndDate>GETDATE() group by ClientID, ClientName,CMStartDate,CMEndDate";
                tabla = ConexionSql.retornaRegistros(consulta);
                dgvMembership.DataSource = tabla;
            }
            else
            {
                tabla = ConexionSql.retornaRegistros("Select * from Membership");
                dgvMembership.DataSource = tabla;
            }
        }

        private void frmMemberShip_Load(object sender, EventArgs e)
        {
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
            string idmembresia = dgvMembership.CurrentRow.Cells["MembershipID"].Value.ToString();
            if (insertarClientMem(idmembresia))
            {
                string activarmem = $"update Clients set ClientMemStatus = 1 where ClientID = '{idcliente}'";
                ConexionSql.EjecutarAccion(activarmem);
                MessageBox.Show("Membresía activada con éxito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Membresía no activada, error.");
            }
        }

        private bool insertarClientMem(string idmembresia)
        {
            // Verificar si hay una caja abierta
            string consultaCajaAbierta = "SELECT TOP 1 IdCaja FROM Caja WHERE Estado = 1 ORDER BY FechaApertura DESC";
            int idCaja = ConexionSql.DevuelveValorEntero(consultaCajaAbierta);
            if (idCaja == 0)
            {
                MessageBox.Show("No hay una caja abierta para registrar la transacción.");
                return false;
            }

            // Insertar en ClientMembership
            string consult =
                "INSERT INTO ClientMembership (CMClientID, CMMembershipID, CMStartDate, CMEndDate) SELECT " +
                " c.ClientID, m.MembershipID, GETDATE(), " +
                "DATEADD(day, COALESCE(m.MemDay, 0) + (COALESCE(m.MemMonth, 0) * 30) + (COALESCE(m.MemYear, 0) * 365), GETDATE()) " +
                "FROM Clients AS c, Membership AS m WHERE " +
                $"c.ClientID = '{idcliente}' AND m.MembershipID = {idmembresia};";
            if (!ConexionSql.EjecutarAccion(consult))
            {
                MessageBox.Show("Error al insertar en ClientMembership.");
                return false;
            }

            // Obtener el ServiceID de la membresía
            string consultaID = "SELECT s.ServiceID FROM Services_Products AS s " +
                                "INNER JOIN Membership AS m ON s.ServiceName = m.MembershipName " +
                                $"WHERE m.MembershipID = {idmembresia}";
            int serviceId = ConexionSql.DevuelveValorEntero(consultaID);

            // Obtener el precio de la membresía
            string consultaPrecio = "SELECT s.ServicePrice FROM Services_Products AS s " +
                                    "INNER JOIN Membership AS m ON s.ServiceName = m.MembershipName " +
                                    $"WHERE m.MembershipID = {idmembresia}";

            decimal precio = ConexionSql.DevuelveValorDecimal(consultaPrecio);
            if (precio == 0)
            {
                MessageBox.Show("No se encontró un precio válido para la membresía seleccionada.");
                return false;
            }

            int idUsuario = frmLogin.UserIdActual;

            string precioSql = precio.ToString().Replace(',', '.');

            // Insertar en Transactions
            string sentencia = "INSERT INTO Transactions (IdCaja, TransClientID, TransServiceID, TransType, TransDescrip, " +
                                "TransSUBTOTAL, TransDiscount, TransQuantity, TransDateTime, TransUserID, TransTOTAL, TransServicePrice) " +
                                $"VALUES ({idCaja}, '{idcliente}', {serviceId}, 'ingreso', 'Membresía', {precioSql}, 0, 1, " +
                                $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {idUsuario}, {precioSql}, {precioSql})";

            if (!ConexionSql.EjecutarAccion(sentencia))
            {
                MessageBox.Show("Error al insertar la transacción.");
                return false;
            }

            return true;
        }

        private void dgvMembership_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembership.CurrentCell != null)
            {
                string idmembresia = dgvMembership.CurrentRow.Cells["MembershipID"].Value.ToString();
                string consulta = $"select s.ServicePrice from Services_Products as s inner join Membership as m on s.ServiceName=m.MembershipName where m.MembershipID = {idmembresia}";
                decimal precio = Math.Round(ConexionSql.DevuelveValorDecimal(consulta), 2);
                lblValorCobrar.Text = precio.ToString();
            }
        }
    }
}