using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cibernopilosos.Recibo;

namespace cibernopilosos.formularios
{
    public partial class frmTrans: Form
    {
        private sqlConexion conexion = new sqlConexion();

        public frmTrans()
        {
            InitializeComponent();
        }

        private void frmTrans_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void cargarTabla()
        {
            string sentencia = "SELECT * FROM Transactions";
            DataTable dt = conexion.retornaRegistros(sentencia);
            dgvTransactions.DataSource = "";
            dgvTransactions.DataSource = dt;
            cambiarNombreColumnas(dt);
        }

        private void cambiarNombreColumnas(DataTable dt)
        {
            if (dt.Columns.Contains("TransID"))
                dgvTransactions.Columns["TransID"].HeaderText = "ID";
            if (dt.Columns.Contains("TransUsername"))
                dgvTransactions.Columns["TransUsername"].HeaderText = "Usuario";
            if (dt.Columns.Contains("TransClientID"))
                dgvTransactions.Columns["TransClientID"].HeaderText = "ID Cliente";
            if (dt.Columns.Contains("TransServicesID"))
                dgvTransactions.Columns["TransServicesID"].HeaderText = "ID Servicio";
            if (dt.Columns.Contains("TransDescrip"))
                dgvTransactions.Columns["TransDescrip"].HeaderText = "Descripción";
            if (dt.Columns.Contains("TransSubTotal"))
                dgvTransactions.Columns["TransSubTotal"].HeaderText = "Sub total";
            if (dt.Columns.Contains("TransTotal"))
                dgvTransactions.Columns["TransTotal"].HeaderText = "Total";
            if (dt.Columns.Contains("TransServicePrice"))
                dgvTransactions.Columns["TransServicePrice"].HeaderText = "Precio del servicio";
            if (dt.Columns.Contains("TransDiscount"))
                dgvTransactions.Columns["TransDiscount"].HeaderText = "Descuento";
            if (dt.Columns.Contains("TransQuantity"))
                dgvTransactions.Columns["TransQuantity"].HeaderText = "Cantidad";
            if (dt.Columns.Contains("TransDateTime"))
                dgvTransactions.Columns["TransDateTime"].HeaderText = "Fecha y Hora";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                int transID = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells["TransID"].Value);
                DialogResult dr = MessageBox.Show("¿Está seguro de borrar la transacción seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Transactions WHERE TransID = " + transID;
                    if (conexion.EjecutarAccion(deleteQuery))
                    {
                        MessageBox.Show("Transacción borrada con éxito.");
                        cargarTabla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar la transacción.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una transacción para borrar.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string buscar = txtFiltrado.Text;
            string sentencia = $"SELECT * FROM Transactions WHERE TransClientID LIKE '%{buscar}%' OR TransID LIKE '%{buscar}%' OR TransServicesID LIKE '%{buscar}%'";

            DataTable dt = conexion.retornaRegistros(sentencia);
            dgvTransactions.DataSource = "";
            dgvTransactions.DataSource = dt;
            cambiarNombreColumnas(dt);
        }

        private void txtFiltrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFiltrado_TextChanged(object sender, EventArgs e)
        {
            string buscar = txtFiltrado.Text;
            if (buscar.Length > 2)
            {
                string sentencia = $"SELECT * FROM Transactions WHERE TransClientID LIKE '%{buscar}%' OR TransID LIKE '%{buscar}%' OR TransServicesID LIKE '%{buscar}%'";
                DataTable dt = conexion.retornaRegistros(sentencia);
                dgvTransactions.DataSource = "";
                dgvTransactions.DataSource = dt;
                cambiarNombreColumnas(dt);
            }
            else
            {
                cargarTabla();
            }
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            string idtrans = dgvTransactions.SelectedRows[0].Cells["TransID"].Value.ToString();
            string consulta =
                "Select t.TransID, t.TransClientID, t.TransServicesID, t.TransDescrip, t.TransServicePrice, t.TransDiscount, t.TransSubTotal, t.TransTotal, t.TransQuantity, t.TransDateTime, c.ClientName " +
                $"from Transactions as T inner join Clients as C on T.TransClientID = C.ClientID where t.TransID = {idtrans}";
            string reporte = "cibernopilosos.Recibo.rptRecibo.rdlc";
            frmReport recibo = new frmReport(reporte, "TransaccionesTabla", consulta);
            recibo.ShowDialog();
        }
    }
}
