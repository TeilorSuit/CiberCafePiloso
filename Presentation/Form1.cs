using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DataAccess;
using Domain;

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
            PopulateTreeView();
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            // Estilizar la barra de progreso
            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.ForeColor = Color.FromArgb(33, 128, 141); // Teal
            progressBar1.Height = 25; // Más grande y visible
            progressBar1.Dock = DockStyle.Top; // En la parte superior (más visible)
            progressBar1.MarqueeAnimationSpeed = 30;
        }


        private void PopulateTreeView()
        {
            treeViewReports.Nodes.Clear();

            treeViewReports.Nodes.Add(CrearNodo("Reporte de Caja", new[] { "Listado de Caja", "Gráfico de Caja" }));
            treeViewReports.Nodes.Add(CrearNodo("Reporte de Uso", new[] { "Listado de Uso", "Gráfico de Uso" }));
            treeViewReports.Nodes.Add(CrearNodo("Reporte de Clientes", new[] { "Listado de Clientes", "Gráfico de Clientes" }));
            treeViewReports.Nodes.Add(CrearNodo("Reporte de Computadoras", new[] { "Listado de Computadoras", "Gráfico de Computadoras" }));
            treeViewReports.Nodes.Add(CrearNodo("Reporte de Membresías", new[] { "Listado de Membresías", "Gráfico de Membresías" }));
            treeViewReports.Nodes.Add(CrearNodo("Reporte de Ventas", new[] { "Listado de Ventas", "Gráfico de Ventas" }));
        }

        private TreeNode CrearNodo(string categoria, string[] subReportes)
        {
            var node = new TreeNode(categoria);
            foreach (var sub in subReportes)
            {
                node.Nodes.Add(sub);
            }
            return node;
        }

        private void treeViewReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                string subReport = e.Node.Text;
                CargarSubReporte(subReport, null, null);
            }
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.Today.AddDays(-7);
            DateTime toDate = DateTime.Now;
            FiltrarReporte(fromDate, toDate);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime toDate = DateTime.Now;
            DateTime fromDate = DateTime.Today.AddDays(-30);
            FiltrarReporte(fromDate, toDate);
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            DateTime toDate = DateTime.Now;
            DateTime fromDate = DateTime.Today.AddDays(-365);
            FiltrarReporte(fromDate, toDate);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltrarReporte(DateTime fromDate, DateTime toDate)
        {
            if (treeViewReports.SelectedNode == null || treeViewReports.SelectedNode.Level != 1)
            {
                MessageBox.Show("Seleccione un subreporte en el árbol para aplicar el filtro.");
                return;
            }
            string subReport = treeViewReports.SelectedNode.Text;
            CargarSubReporte(subReport, fromDate, toDate);
        }

        private void CargarSubReporte(string subReport, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                // Mostrar progreso
                Cursor = Cursors.WaitCursor;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                Application.DoEvents();

                DateTime fDate = fromDate ?? DateTime.Today.AddDays(-7);
                DateTime tDate = toDate ?? DateTime.Now;

                // Resetear reportViewer y datasources
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();

                progressBar1.Value = 20;
                Application.DoEvents();

                // Determinar ruta y cargar datos según el subreporte
                switch (subReport)
                {
                    case "Listado de Caja":
                        CargarCajaListado(fDate, tDate);
                        break;
                    case "Gráfico de Caja":
                        CargarCajaGrafico(fDate, tDate);
                        break;
                    case "Listado de Uso":
                        CargarUsoListado(fDate, tDate);
                        break;
                    case "Gráfico de Uso":
                        CargarUsoGrafico(fDate, tDate);
                        break;
                    case "Listado de Clientes":
                        CargarClientesListado(fDate, tDate);
                        break;
                    case "Gráfico de Clientes":
                        CargarClientesGrafico(fDate, tDate);
                        break;
                    case "Listado de Computadoras":
                        CargarComputadorasListado(fDate, tDate);
                        break;
                    case "Gráfico de Computadoras":
                        CargarComputadorasGrafico(fDate, tDate);
                        break;
                    case "Listado de Membresías":
                        CargarMembresiaListado(fDate, tDate);
                        break;
                    case "Gráfico de Membresías":
                        CargarMembresiaGrafico(fDate, tDate);
                        break;
                    case "Listado de Ventas":
                        CargarVentasListado(fDate, tDate);
                        break;
                    case "Gráfico de Ventas":
                        CargarVentasGrafico(fDate, tDate);
                        break;
                    default:
                        MessageBox.Show("Reporte no implementado: " + subReport);
                        progressBar1.Visible = false;
                        Cursor = Cursors.Default;
                        return;
                }

                progressBar1.Value = 80;
                Application.DoEvents();

                reportViewer1.RefreshReport();

                progressBar1.Value = 100;
                Application.DoEvents();


                progressBar1.Visible = false;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
                Cursor = Cursors.Default;
                MessageBox.Show(
                    "Error al cargar el reporte. Verifique los datos e intente nuevamente.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine($"Excepción: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // Métodos privados para cargar cada reporte
        private void CargarCajaListado(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Caja\\ReporteCajaListado.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var cajaDao = new CajaDao();
            var listaCajas = cajaDao.getAllCajas(fDate, tDate);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("cajaListing", listaCajas));
        }

        private void CargarCajaGrafico(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Caja\\ReporteCajaGrafico.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var cajaDao = new CajaDao();
            var chartData = cajaDao.getCajaGrafico(fDate, tDate);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("cajaChart", chartData));
        }

        private void CargarClientesListado(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Clientes\\ReporteClientesListado.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var clientDao = new ClientDao();
            var clientList = clientDao.GetAllClients();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("clientListing", clientList));
        }

        private void CargarClientesGrafico(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Clientes\\ReporteClientesGrafico.rdlc";
            progressBar1.Value = 40;
            Application.DoEvents();

            var clientDao = new ClientDao();
            var allClients = clientDao.GetAllClients();

            var memStatusGroup = allClients
                .GroupBy(c => c.ClientMemStatus)
                .Select(g => new ClientsByMembership
                {
                    HasMembership = g.Key,
                    CountClients = g.Count()
                })
                .ToList();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("clientsByMembership", memStatusGroup)
            );
        }

        private void CargarComputadorasListado(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Computadoras\\ReporteComputadorasListado.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var compDao = new ComputersDao();
            var compList = compDao.GetAllComputers();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("computerListing", compList));
        }

        private void CargarComputadorasGrafico(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Computadoras\\ReporteComputadorasGrafico.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var compDao = new ComputersDao();
            var compStatusSummary = compDao.GetComputersStatusSummary();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("computerStatusSummary", compStatusSummary));
        }

        private void CargarMembresiaListado(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Membresías\\ReporteMembresiaListado.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var memDao = new MembershipDao();
            var memList = memDao.GetAllMemberships();
            var memFiltered = memList.Where(m => m.CMStartDate >= fDate && m.CMEndDate <= tDate).ToList();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("membershipListing", memFiltered));
        }

        private void CargarMembresiaGrafico(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Membresías\\ReporteMembresiaGrafico.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var memDao = new MembershipDao();
            var memList = memDao.GetAllMemberships();

            var summaryByType = memList.GroupBy(m => m.MembershipName)
                .Select(g => new MembershipSummaryByType
                {
                    MembershipName = g.Key,
                    CountMemberships = g.Count(),
                    AverageDiscount = g.Average(x => x.Discount)
                })
                .ToList();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("membershipSummary", summaryByType));
        }

        private void CargarUsoListado(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Usos\\ReporteUsoListado.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var usageDao = new UsageDao();
            var usageList = usageDao.GetUsageSessions(fDate, tDate);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("usageListing", usageList));
        }

        private void CargarUsoGrafico(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Usos\\ReporteUsoGrafico.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var usageDao = new UsageDao();
            var frequentClients = usageDao.GetFrequentClients(fDate, tDate);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("usageByClient", frequentClients));
        }

        private void CargarVentasListado(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Ventas\\ReporteVentasListado.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var transDao = new TransactionsDao();
            var salesList = transDao.GetSalesListing(fDate, tDate);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("salesListing", salesList));
        }

        private void CargarVentasGrafico(DateTime fDate, DateTime tDate)
        {
            reportViewer1.LocalReport.ReportPath = "Reporte de Ventas\\ReporteVentasGrafico.rdlc";
            SetParameters(fDate, tDate);
            progressBar1.Value = 40;
            Application.DoEvents();

            var transDao = new TransactionsDao();
            var salesList = transDao.GetSalesListing(fDate, tDate);

            var netSalesByPeriod = salesList
                .GroupBy(s => s.orderDate.Date)
                .Select(g => new NetSalesByPeriod
                {
                    datePeriod = g.Key,
                    netSales = g.Sum(x => x.totalAmount)
                })
                .OrderBy(x => x.datePeriod)
                .ToList();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("netSalesByPeriod", netSalesByPeriod)
            );
        }


        // Método auxiliar para establecer parámetros
        private void SetParameters(DateTime fDate, DateTime tDate)
        {
            var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
            var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
            var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
            reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });
        }
    }
}
