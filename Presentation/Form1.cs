using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Domain;       // Para SalesReport, ComputerUsageReport, etc.
using DataAccess;   // Si necesitas OrderDao, ComputerUsageDao, etc.

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Opcional: podrías llamar aquí a getCombinedReport(...) con un rango predeterminado
            // Ejemplo: getCombinedReport(DateTime.Today.AddDays(-7), DateTime.Now);
        }

        /// <summary>
        /// Llama a los reportes de ventas y uso de computadoras, asigna los DataSources al ReportViewer
        /// </summary>
        private void getCombinedReport(DateTime startDate, DateTime endDate)
        {
            // 1. Generar reporte de VENTAS
            var salesModel = new SalesReport();
            // Llenar salesListing y netSalesByPeriod según tus datos
            salesModel.createSalesOrderReport(startDate, endDate);

            // 2. Generar reporte de USO DE COMPUTADORAS
            var usageModel = new ComputerUsageReport();
            // createComputerUsageReport devuelve la cantidad de registros
            int usageCount = usageModel.createComputerUsageReport(startDate, endDate);

            // 3. Mostrar cuántos registros de uso obtuviste (depuración)
            MessageBox.Show(
                "Registros de uso obtenidos: " + usageCount,
                "Debug - Uso de Computadoras"
            );

            // 4. Limpiar fuentes de datos previas en el ReportViewer
            reportViewer1.LocalReport.DataSources.Clear();

            // 5. Asignar fuentes de datos (DataSets) para VENTAS
            //    Ajusta el nombre del DataSet a lo que tengas en el RDLC{
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("usageByClient", usageModel.usageByClient)
            );
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("usageByHour", usageModel.usageByHour)
            );
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("salesReport", new List<SalesReport> { salesModel })
            );
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("salesListing", salesModel.salesListing)
            );
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("netSalesByPeriod", salesModel.netSalesByPeriod)
            );

            // 6. Asignar fuentes de datos (DataSets) para USO DE COMPUTADORAS
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("computerUsageReport", new List<ComputerUsageReport> { usageModel })
            );
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("computerUsageListing", usageModel.usageListings)
            );

            // 7. Indicar la ruta del .rdlc
            //    Ajusta si tu archivo se llama distinto o está en otra carpeta
            reportViewer1.LocalReport.ReportPath = "Reportes1\\SalesReport.rdlc";

            // 8. Refrescar el reporte
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Al presionar el botón "Este Mes", filtra desde el primer día del mes actual hasta el último día
        /// </summary>
        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            // Calcular primer día del mes
            var now = DateTime.Now;  // Si tu PC está en 2025-03, usará esa fecha
            int lastDay = DateTime.DaysInMonth(now.Year, now.Month);

            var fromDate = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            var toDate = new DateTime(now.Year, now.Month, lastDay, 23, 59, 59);

            Console.WriteLine("Desde: " + fromDate.ToString("yyyyMMdd HH:mm:ss"));
            Console.WriteLine("Hasta: " + toDate.ToString("yyyyMMdd HH:mm:ss"));

            // Llama a getCombinedReport con ese rango
            getCombinedReport(fromDate, toDate);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // Ajustar el zoom inicial
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnThisYear_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, 1, 1);
            var toDate = DateTime.Now;
            getCombinedReport(fromDate, toDate);
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
  
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Now.AddDays(-7);
            var toDate = DateTime.Now;
            getCombinedReport(fromDate, toDate);
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            // Cierras Form1
            this.Close();
            // El menú estaba oculto, no cerrado. 
            // Al cerrarse Form1, se re-muestra frmMenu si no la cerraste.
        }
    }
}
