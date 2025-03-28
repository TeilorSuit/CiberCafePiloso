using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cibernopilosos.formularios_de_registro; // Por si usas frmEgresosIngresos
using cibernopilosos.Recibo;                  // Por si usas frmReport

namespace cibernopilosos.formularios
{
    public partial class frmTrans : Form
    {
        // Usa tu clase sqlConexion para consultas simples
        private sqlConexion conexion = new sqlConexion();
        private DateTime fechaAperturaCaja;
        private decimal dineroCaja;

        public frmTrans()
        {
            InitializeComponent();
        }

        private void frmTrans_Load(object sender, EventArgs e)
        {
            cargarTabla();
            ActualizarDineroCaja();
            VerificarEstadoCaja();
        }

        // --------------------------------------------------------------------------
        // Métodos relacionados con la Caja
        // --------------------------------------------------------------------------

        /// <summary>
        /// Verifica si hay alguna caja con Estado = 1 (abierta).
        /// </summary>
        private bool HayCajaAbierta()
        {
            string consulta = "SELECT COUNT(*) FROM Caja WHERE Estado = 1";
            return (conexion.DevuelveValorEntero(consulta) > 0);
        }

        /// <summary>
        /// Obtiene la DataRow de la caja abierta más reciente (o null si no hay).
        /// </summary>
        private DataRow ObtenerCajaAbierta()
        {
            string consulta = @"
                SELECT TOP 1 *
                FROM Caja
                WHERE Estado = 1
                ORDER BY FechaApertura DESC
            ";
            DataTable dt = conexion.retornaRegistros(consulta);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        /// <summary>
        /// Habilita o deshabilita txtMontoApertura según haya o no caja abierta.
        /// </summary>
        private void VerificarEstadoCaja()
        {
            txtMontoApertura.Enabled = !HayCajaAbierta();
        }

        /// <summary>
        /// Inserta una nueva caja con parámetros, evitando problemas de formato de fecha.
        /// </summary>
        private bool AbrirCajaConParametros(decimal montoApertura, int idUsuarioApertura)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO Caja
                    (
                        FechaApertura,
                        MontoApertura,
                        IdUsuarioApertura,
                        Estado,
                        TotalIngresos,
                        TotalGastos
                    )
                    VALUES
                    (
                        @fechaApertura,
                        @montoApertura,
                        @idUsuarioApertura,
                        1,
                        0,
                        0
                    );
                ";

                // Creamos conexión manualmente usando la propiedad Cadena
                using (var conn = new SqlConnection(conexion.Cadena))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Parámetros
                        cmd.Parameters.Add("@fechaApertura", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@montoApertura", SqlDbType.Decimal).Value = montoApertura;
                        cmd.Parameters.Add("@idUsuarioApertura", SqlDbType.Int).Value = idUsuarioApertura;

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la caja (con parámetros): " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Actualiza (cierra) una caja con parámetros (FechaCierre, MontoCierre, etc.).
        /// </summary>
        private bool CerrarCajaConParametros(int idCaja,
                                             DateTime fechaCierre,
                                             decimal montoCierre,
                                             int idUsuarioCierre,
                                             decimal totalIngresos,
                                             decimal totalGastos)
        {
            try
            {
                string updateQuery = @"
                    UPDATE Caja
                    SET FechaCierre   = @fechaCierre,
                        MontoCierre   = @montoCierre,
                        IdUsuarioCierre = @idUsuarioCierre,
                        Estado        = 0,
                        TotalIngresos = @totalIngresos,
                        TotalGastos   = @totalGastos
                    WHERE IdCaja = @idCaja;
                ";

                using (var conn = new SqlConnection(conexion.Cadena))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add("@fechaCierre", SqlDbType.DateTime).Value = fechaCierre;
                        cmd.Parameters.Add("@montoCierre", SqlDbType.Decimal).Value = montoCierre;
                        cmd.Parameters.Add("@idUsuarioCierre", SqlDbType.Int).Value = idUsuarioCierre;
                        cmd.Parameters.Add("@totalIngresos", SqlDbType.Decimal).Value = totalIngresos;
                        cmd.Parameters.Add("@totalGastos", SqlDbType.Decimal).Value = totalGastos;
                        cmd.Parameters.Add("@idCaja", SqlDbType.Int).Value = idCaja;

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la caja (con parámetros): " + ex.Message);
                return false;
            }
        }

        // --------------------------------------------------------------------------
        // Botones para abrir/cerrar caja
        // --------------------------------------------------------------------------

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (HayCajaAbierta())
            {
                MessageBox.Show("Ya hay una caja abierta. Por favor, cierre la caja actual antes de abrir una nueva.");
                return;
            }

            if (!decimal.TryParse(txtMontoApertura.Text, out decimal montoApertura))
            {
                MessageBox.Show("Ingrese un monto de apertura válido.");
                return;
            }

            int idUsuarioApertura = frmLogin.UserIdActual;

            // Usamos el método con parámetros
            if (AbrirCajaConParametros(montoApertura, idUsuarioApertura))
            {
                MessageBox.Show("Caja abierta con éxito.");
                fechaAperturaCaja = DateTime.Now;
                txtMontoApertura.Enabled = false;
                ActualizarDineroCaja();
            }
            else
            {
                MessageBox.Show("Error al abrir la caja.");
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            DataRow cajaAbierta = ObtenerCajaAbierta();
            if (cajaAbierta == null)
            {
                MessageBox.Show("No hay una caja abierta para cerrar.");
                return;
            }

            int idCaja = Convert.ToInt32(cajaAbierta["IdCaja"]);
            decimal montoApertura = Convert.ToDecimal(cajaAbierta["MontoApertura"]);

            // Calculamos total de ingresos y gastos
            string consultaIngresos = $"SELECT COALESCE(SUM(TransTOTAL), 0) FROM Transactions WHERE IdCaja = {idCaja} AND TransType = 'ingreso'";
            decimal totalIngresos = conexion.DevuelveValorDecimal(consultaIngresos);
            string consultaGastos = $"SELECT COALESCE(SUM(TransTOTAL), 0) FROM Transactions WHERE IdCaja = {idCaja} AND TransType = 'egreso'";
            decimal totalGastos = conexion.DevuelveValorDecimal(consultaGastos);

            decimal montoCierre = montoApertura + totalIngresos - totalGastos;
            int idUsuarioCierre = frmLogin.UserIdActual;
            DateTime fechaCierre = DateTime.Now;

            // Usamos el método con parámetros
            bool exito = CerrarCajaConParametros(
                idCaja,
                fechaCierre,
                montoCierre,
                idUsuarioCierre,
                totalIngresos,
                totalGastos
            );

            if (exito)
            {
                MessageBox.Show($"Caja cerrada con éxito. Monto de cierre: {montoCierre}");
                lblDineroCaja.Text = "0";
                txtMontoApertura.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al cerrar la caja.");
            }
        }

        // --------------------------------------------------------------------------
        // Lógica para mostrar Transactions en el DataGridView
        // --------------------------------------------------------------------------

        private void cargarTabla()
        {
            string sentencia = "SELECT * FROM Transactions";
            DataTable dt = conexion.retornaRegistros(sentencia);
            dgvTransactions.DataSource = dt;
            cambiarNombreColumnas(dt);
        }

        private void cambiarNombreColumnas(DataTable dt)
        {
            if (dt.Columns.Contains("TransID"))
                dgvTransactions.Columns["TransID"].HeaderText = "ID";
            if (dt.Columns.Contains("IdCaja"))
                dgvTransactions.Columns["IdCaja"].HeaderText = "ID Caja";
            if (dt.Columns.Contains("TransClientID"))
                dgvTransactions.Columns["TransClientID"].HeaderText = "ID Cliente";
            if (dt.Columns.Contains("TransServiceID"))
                dgvTransactions.Columns["TransServiceID"].HeaderText = "ID Servicio";
            if (dt.Columns.Contains("TransType"))
                dgvTransactions.Columns["TransType"].HeaderText = "Tipo";
            if (dt.Columns.Contains("TransDescrip"))
                dgvTransactions.Columns["TransDescrip"].HeaderText = "Descripción";
            if (dt.Columns.Contains("TransSUBTOTAL"))
                dgvTransactions.Columns["TransSUBTOTAL"].HeaderText = "Sub total";
            if (dt.Columns.Contains("TransDiscount"))
                dgvTransactions.Columns["TransDiscount"].HeaderText = "Descuento";
            if (dt.Columns.Contains("TransQuantity"))
                dgvTransactions.Columns["TransQuantity"].HeaderText = "Cantidad";
            if (dt.Columns.Contains("TransDateTime"))
                dgvTransactions.Columns["TransDateTime"].HeaderText = "Fecha y Hora";
            if (dt.Columns.Contains("TransUserID"))
                dgvTransactions.Columns["TransUserID"].HeaderText = "ID Usuario";
            if (dt.Columns.Contains("TransTOTAL"))
                dgvTransactions.Columns["TransTOTAL"].HeaderText = "Total";
            if (dt.Columns.Contains("TransServicePrice"))
                dgvTransactions.Columns["TransServicePrice"].HeaderText = "Precio del servicio";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string buscar = txtFiltrado.Text;
            string sentencia = $@"
                SELECT *
                FROM Transactions
                WHERE TransClientID LIKE '%{buscar}%'
                   OR TransID LIKE '%{buscar}%'
                   OR TransServiceID LIKE '%{buscar}%'
            ";

            DataTable dt = conexion.retornaRegistros(sentencia);
            dgvTransactions.DataSource = dt;
            cambiarNombreColumnas(dt);
        }

        private void txtFiltrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ejemplo: si quieres solo dígitos
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
                string sentencia = $@"
                    SELECT *
                    FROM Transactions
                    WHERE TransClientID LIKE '%{buscar}%'
                       OR TransID LIKE '%{buscar}%'
                       OR TransServiceID LIKE '%{buscar}%'
                ";
                DataTable dt = conexion.retornaRegistros(sentencia);
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
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para generar el recibo.");
                return;
            }

            string idtrans = dgvTransactions.SelectedRows[0].Cells["TransID"].Value.ToString();
            string consulta = @"
                SELECT 
                    t.TransID,
                    t.TransClientID,
                    t.TransServiceID,
                    t.TransDescrip,
                    t.TransServicePrice,
                    t.TransDiscount,
                    t.TransSUBTOTAL,
                    t.TransTOTAL,
                    t.TransQuantity,
                    t.TransDateTime,
                    c.ClientName
                FROM Transactions AS t
                INNER JOIN Clients AS c ON t.TransClientID = c.ClientID
                WHERE t.TransID = " + idtrans;

            string reporte = "cibernopilosos.Recibo.rptRecibo.rdlc";
            frmReport recibo = new frmReport(reporte, "TransaccionesTabla", consulta);
            recibo.ShowDialog();
        }

        /// <summary>
        /// Recalcula y muestra el dinero en caja (label lblDineroCaja).
        /// </summary>
        private void ActualizarDineroCaja()
        {
            DataRow cajaAbierta = ObtenerCajaAbierta();
            if (cajaAbierta == null)
            {
                lblDineroCaja.Text = "...";
                return;
            }

            int idCaja = Convert.ToInt32(cajaAbierta["IdCaja"]);
            decimal montoApertura = Convert.ToDecimal(cajaAbierta["MontoApertura"]);

            string consultaIngresos = $"SELECT COALESCE(SUM(TransTOTAL), 0) FROM Transactions WHERE IdCaja = {idCaja} AND TransType = 'ingreso'";
            decimal totalIngresos = conexion.DevuelveValorDecimal(consultaIngresos);

            string consultaGastos = $"SELECT COALESCE(SUM(TransTOTAL), 0) FROM Transactions WHERE IdCaja = {idCaja} AND TransType = 'egreso'";
            decimal totalGastos = conexion.DevuelveValorDecimal(consultaGastos);

            dineroCaja = montoApertura + totalIngresos - totalGastos;
            lblDineroCaja.Text = dineroCaja.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                int transID = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells["TransID"].Value);
                DialogResult dr = MessageBox.Show("¿Está seguro de borrar la transacción seleccionada?",
                                                  "Confirmar",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Transactions WHERE TransID = " + transID;
                    if (conexion.EjecutarAccion(deleteQuery))
                    {
                        MessageBox.Show("Transacción borrada con éxito.");
                        cargarTabla();
                        ActualizarDineroCaja();
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

        // --------------------------------------------------------------------------
        // Métodos FALTANTES que pedían tus errores de compilación
        // --------------------------------------------------------------------------

        /// <summary>
        /// Método que existía con el nombre "ActualizarDineroGaja". 
        /// Ahora simplemente llama a ActualizarDineroCaja().
        /// </summary>
        private void ActualizarDineroGaja()
        {
            // Llamamos al método real
            ActualizarDineroCaja();
        }

        /// <summary>
        /// Método para el evento Click del botón "NuevoIngresoEgreso", 
        /// que en tu caso mostraba el formulario frmEgresosIngresos 
        /// y luego actualizaba la caja.
        /// </summary>
        private void btnNuevoIngresoEgreso_Click(object sender, EventArgs e)
        {
            frmEgresosIngresos frm = new frmEgresosIngresos();
            frm.ShowDialog();
            // Al cerrar, volvemos a recalcular la caja
            ActualizarDineroGaja();
        }
    }
}
