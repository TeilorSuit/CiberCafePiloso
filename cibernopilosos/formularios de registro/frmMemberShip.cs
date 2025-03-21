using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cibernopilosos.formularios_de_registro
{
    public partial class frmMemberShip: Form
    {
        sqlConexion ConexionSql = new sqlConexion();
        public string idcliente;
        private string modo="";
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
                lblMemberShip.Location = new Point(this.Size.Width/4, this.Size.Height/10);
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
            insertarClientMem(idmembresia);
            string activarmem = "update Clients set ClientMemStatus = 1 where ClientID = " + idcliente;
            ConexionSql.EjecutarAccion(activarmem); ;
            MessageBox.Show("Membresía activada con éxito");
            this.Close();
        }

        private void insertarClientMem(string idmembresia)
        {
            string consult =
                "INSERT INTO ClientMembership (CMClientID, CMMembershipID, CMStartDate, CMEndDate) SELECT " +
                " c.ClientID, m.MembershipID, GETDATE(), " +
                "DATEADD(day, COALESCE(m.MemDay, 0) + (COALESCE(m.MemMonth, 0) * 30) + (COALESCE(m.MemYear, 0) * 365)," +
                " GETDATE()) FROM Clients AS c, Membership AS m WHERE " +
                $"c.ClientID = {idcliente} AND m.MembershipID = {idmembresia};";
            ConexionSql.EjecutarAccion(consult);
        }

        private void dgvMembership_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembership.CurrentCell != null )
            {
                string idmembresia = dgvMembership.CurrentRow.Cells["MembershipID"].Value.ToString();
                string consulta = $"select s.ServicePrice from Services_Products as s inner join Membership as m on s.ServiceName=m.MembershipName where m.MembershipID = {idmembresia}";
                decimal precio = Math.Round(ConexionSql.DevuelveValorDecimal(consulta), 2);
                lblValorCobrar.Text = precio.ToString();
            }
        }

    }
}
