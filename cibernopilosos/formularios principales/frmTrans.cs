using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (dt.Columns.Contains("TransPaidMoney"))
                dgvTransactions.Columns["TransPaidMoney"].HeaderText = "Monto Pagado";
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

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
