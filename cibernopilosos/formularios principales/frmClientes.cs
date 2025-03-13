using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cibernopilosos.formularios_de_registro;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cibernopilosos.formularios
{
    public partial class frmClientes : Form
    {
        public int TiempoHorasCalculados { get; set; }
        public int TiempoMinutosCalculados { get; set; }
        public bool VinculacionMode { get; set; } = false;
        public string SelectedPcIp { get; set; } = "";

        public frmClientes()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void llenarTabla()
        {
            sqlConexion ConexionSql = new sqlConexion();
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

        private void btnAdminSubs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }

        // Evento que se ejecuta al cargar el formulario
        private void frmClientes_Load(object sender, EventArgs e)
        {
            // Llenar la tabla ya se llamó en el constructor; 
            // Se ajusta la visibilidad de los botones según el modo de apertura
            if (VinculacionMode)
            {
                // Si se abrió desde BotonAddClientePc, ocultar todos menos btnVincularPc
                btnAgregarCliente.Visible = false;
                btnEditarCliente.Visible = false;
                btnBorrarCliente.Visible = false;
                btnVincularPc.Visible = true;
            }
            else
            {
                // Si se abrió de otra forma, ocultar el botón de vinculación
                btnVincularPc.Visible = false;
            }
        }

        // Evento para vincular la computadora con el cliente seleccionado
        private void btnVincularPc_Click(object sender, EventArgs e)
        {
            if (dgvAdmiClientes.CurrentRow != null)
            {
                // aquí sacamos lo del clientee
                string clientId = dgvAdmiClientes.CurrentRow.Cells["ClientID"].Value.ToString();
                string clientName = dgvAdmiClientes.CurrentRow.Cells["ClientName"].Value.ToString();

                // Verificar lo de  la IP 
                if (string.IsNullOrEmpty(SelectedPcIp))
                {
                    MessageBox.Show("No se ha seleccionado una computadora.");
                    return;
                }

                // descripcion trans
                string descripcion = $"Vinculación de PC {SelectedPcIp} con Cliente {clientName}";

                // Consulta el precio por hora de la PC
                sqlConexion ConexionSql = new sqlConexion();
                string consultaPrecio = "SELECT ServicePrice FROM Services_Products WHERE ServiceID = 2";
                decimal precioHora = ConexionSql.DevuelveValorDecimal(consultaPrecio);

                // tiempo total en horas 
                decimal tiempoTotal = TiempoHorasCalculados + ((decimal)TiempoMinutosCalculados / 60m);
                //  precio final
                decimal totalPrice = tiempoTotal * precioHora;

                // Construir la consultaaaa
                string query = $"INSERT INTO Transactions (TransClientID, TransServicesID, TransDescrip, TransPaidMoney, TransDiscount, TransQuantity, TransDateTime, TransUsername) " +
                               $"VALUES ('{clientId}', 2, '{descripcion}', {totalPrice}, 0, 1, '{DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")}', 'admin')";

                if (ConexionSql.EjecutarAccion(query))
                {
                    MessageBox.Show("Vinculación exitosa. Transacción registrada.");
                    this.Close(); // Se cierra el formulario tras la vinculación
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
                string comando = "update Clients set ClientMemStatus = 0 where ClientID = " + idcliente+
                    "update ClientMembership set CMEndDate=GETDATE() where CMClientID =" + idcliente;

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
    }
}