using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DataAccess;  // Para tus DAOs (CajaDao, UsageDao, etc.)
using Domain;      // Para tus clases POCO (CajaListing, ComputerUsageListing, etc.)

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
            // Ajusta el modo de zoom según prefieras
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
        }

        // 1) Llena el TreeView con las categorías y dos subnodos (Listado, Gráfico)
        private void PopulateTreeView()
        {
            treeViewReports.Nodes.Clear();

            // --- Categoría: Reporte de Caja ---
            var cajaNode = new TreeNode("Reporte de Caja");
            cajaNode.Nodes.Add("Listado de Caja");     // => ReporteCajaListado.rdlc
            cajaNode.Nodes.Add("Gráfico de Caja");     // => ReporteCajaGrafico.rdlc
            treeViewReports.Nodes.Add(cajaNode);

            // --- Categoría: Reporte de Uso ---
            var usoNode = new TreeNode("Reporte de Uso");
            usoNode.Nodes.Add("Listado de Uso");       // => ReporteUsoListado.rdlc
            usoNode.Nodes.Add("Gráfico de Uso");       // => ReporteUsoGrafico.rdlc
            treeViewReports.Nodes.Add(usoNode);

            // --- Categoría: Reporte de Clientes ---
            var clientesNode = new TreeNode("Reporte de Clientes");
            clientesNode.Nodes.Add("Listado de Clientes");   // => ReporteClientesListado.rdlc
            clientesNode.Nodes.Add("Gráfico de Clientes");   // => ReporteClientesGrafico.rdlc
            treeViewReports.Nodes.Add(clientesNode);

            // --- Categoría: Reporte de Computadoras ---
            var compNode = new TreeNode("Reporte de Computadoras");
            compNode.Nodes.Add("Listado de Computadoras");   // => ReporteComputadorasListado.rdlc
            compNode.Nodes.Add("Gráfico de Computadoras");   // => ReporteComputadorasGrafico.rdlc
            treeViewReports.Nodes.Add(compNode);

            // --- Categoría: Reporte de Membresías ---
            var membresiaNode = new TreeNode("Reporte de Membresías");
            membresiaNode.Nodes.Add("Listado de Membresías"); // => ReporteMembresiaListado.rdlc
            membresiaNode.Nodes.Add("Gráfico de Membresías"); // => ReporteMembresiaGrafico.rdlc
            treeViewReports.Nodes.Add(membresiaNode);

            // --- Categoría: Reporte de Ventas ---
            var ventasNode = new TreeNode("Reporte de Ventas");
            ventasNode.Nodes.Add("Listado de Ventas");  // => ReporteVentasListado.rdlc
            ventasNode.Nodes.Add("Gráfico de Ventas");  // => ReporteVentasGrafico.rdlc
            treeViewReports.Nodes.Add(ventasNode);
        }

        // Al seleccionar un subnodo, se carga el reporte
        private void treeViewReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                string subReport = e.Node.Text;
                // Carga sin rango de fechas por defecto
                CargarSubReporte(subReport, null, null);
            }
        }

        // Botones para filtrar por rango de fechas
        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            // Si hoy es 22/03/2025, el rango será de 15/03/2025 a 22/03/2025.
            DateTime fromDate = DateTime.Today.AddDays(-7);
            DateTime toDate = DateTime.Now;
            FiltrarReporte(fromDate, toDate);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            // Rango: último mes (ejemplo: últimos 30 días)
            // Si deseas "desde el 1 de este mes hasta hoy", ver la variante más abajo
            DateTime toDate = DateTime.Now;
            DateTime fromDate = DateTime.Today.AddDays(-30);
            FiltrarReporte(fromDate, toDate);
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            // Rango: último año (ejemplo: últimos 365 días)
            // Si deseas "desde el 1 de enero hasta hoy", ver la variante más abajo
            DateTime toDate = DateTime.Now;
            DateTime fromDate = DateTime.Today.AddDays(-365);
            FiltrarReporte(fromDate, toDate);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Aplica el filtro y vuelve a cargar el reporte
        private void FiltrarReporte(DateTime fromDate, DateTime toDate)
        {
            if (treeViewReports.SelectedNode == null || treeViewReports.SelectedNode.Level != 1)
            {
                MessageBox.Show("Seleccione un subreporte en el TreeView para aplicar el filtro.");
                return;
            }
            string subReport = treeViewReports.SelectedNode.Text;
            CargarSubReporte(subReport, fromDate, toDate);
        }

        // 2) Carga el subreporte (con o sin filtro de fechas)
        private void CargarSubReporte(string subReport, DateTime? fromDate, DateTime? toDate)
        {
            // Convertir a valores no nulos
            DateTime fDate = fromDate ?? DateTime.Today.AddDays(-7);
            DateTime tDate = toDate ?? DateTime.Now;

            // Según el subreporte, asignamos el RDLC y la data
            switch (subReport)
            {
                // ------------------ REPORTE DE CAJA ------------------
                case "Listado de Caja":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Caja\\ReporteCajaListado.rdlc";

                        // Asignar parámetros
                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        // Llamar al DAO
                        var cajaDao = new CajaDao();
                        var listaCajas = cajaDao.getAllCajas(fDate, tDate); // Ahora pasamos el rango de fechas
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("cajaListing", listaCajas));
                        break;
                    }
                case "Gráfico de Caja":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Caja\\ReporteCajaGrafico.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var cajaDao = new CajaDao();
                        var chartData = cajaDao.getCajaGrafico(fDate, tDate);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("cajaChart", chartData));
                        break;
                    }

                // ------------------ REPORTE DE USO ------------------
                case "Listado de Uso":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Usos\\ReporteUsoListado.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var usageDao = new UsageDao();
                        var usageList = usageDao.GetUsageSessions(fDate, tDate);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("usageListing", usageList));
                        break;
                    }
                case "Gráfico de Uso":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Usos\\ReporteUsoGrafico.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var usageDao = new UsageDao();
                        var frequentClients = usageDao.GetFrequentClients(fDate, tDate);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("usageByClient", frequentClients));
                        break;
                    }

                // ------------------ REPORTE DE CLIENTES ------------------
                case "Listado de Clientes":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Clientes\\ReporteClientesListado.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var clientDao = new ClientDao();
                        var clientList = clientDao.GetAllClients();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("clientListing", clientList));
                        break;
                    }
                case "Gráfico de Clientes":
                    {
                        reportViewer1.LocalReport.ReportPath = "Reporte de Clientes\\ReporteClientesGrafico.rdlc";

                        var clientDao = new ClientDao();
                        var allClients = clientDao.GetAllClients(); // => List<ClientListing>

                        // Agrupamos por ClientMemStatus (true/false)
                        var memStatusGroup = allClients
                            .GroupBy(c => c.ClientMemStatus)
                            .Select(g => new ClientsByMembership
                            {
                                HasMembership = g.Key,         // true o false
                                CountClients = g.Count()
                            })
                            .ToList();

                        // Asignamos este grupo al DataSource "clientsByMembership"
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("clientsByMembership", memStatusGroup)
                        );

                        break;
                    }

                // ------------------ REPORTE DE COMPUTADORAS ------------------
                case "Listado de Computadoras":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Computadoras\\ReporteComputadorasListado.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var compDao = new ComputersDao();
                        var compList = compDao.GetAllComputers();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("computerListing", compList));
                        break;
                    }
                case "Gráfico de Computadoras":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Computadoras\\ReporteComputadorasGrafico.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var compDao = new ComputersDao();
                        var compStatusSummary = compDao.GetComputersStatusSummary();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("computerStatusSummary", compStatusSummary));
                        break;
                    }

                // ------------------ REPORTE DE MEMBRESÍAS ------------------
                case "Listado de Membresías":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Membresías\\ReporteMembresiaListado.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var memDao = new MembershipDao();
                        var memList = memDao.GetAllMemberships();
                        var memFiltered = memList.Where(m => m.CMStartDate >= fDate && m.CMEndDate <= tDate).ToList();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("membershipListing", memFiltered));
                        break;
                    }
                case "Gráfico de Membresías":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Membresías\\ReporteMembresiaGrafico.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var memDao = new MembershipDao();
                        var memList = memDao.GetAllMemberships();
                        // Agrupar por tipo de membresía
                        var summaryByType = memList.GroupBy(m => m.MembershipName)
                            .Select(g => new MembershipSummaryByType
                            {
                                MembershipName = g.Key,
                                CountMemberships = g.Count(),
                                AverageDiscount = g.Average(x => x.Discount)
                            })
                            .ToList();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("membershipSummary", summaryByType));
                        break;
                    }

                // ------------------ REPORTE DE VENTAS ------------------
                case "Listado de Ventas":
                    {
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "Reporte de Ventas\\ReporteVentasListado.rdlc";

                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));
                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        var transDao = new TransactionsDao();
                        var salesList = transDao.GetSalesListing(fDate, tDate);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("salesListing", salesList));
                        break;
                    }
                case "Gráfico de Ventas":
                    {
                        // 1) Definir la ruta del informe
                        reportViewer1.LocalReport.ReportPath = "Reporte de Ventas\\ReporteVentasGrafico.rdlc";

                        // 2) Limpiar datasources previos
                        reportViewer1.LocalReport.DataSources.Clear();

                        // 3) Obtener datos
                        var transDao = new TransactionsDao();
                        var salesList = transDao.GetSalesListing(fDate, tDate);

                        // Agrupar las ventas por día
                        var netSalesByPeriod = salesList
    .GroupBy(s => s.orderDate.Date)
    .Select(g => new NetSalesByPeriod
    {
        // Asegúrate de usar un DateTime real
        datePeriod = g.Key,                  // g.Key es un DateTime (solo la parte de la fecha)
        netSales = g.Sum(x => x.totalAmount) // Suma de totalAmount
    })
    .OrderBy(x => x.datePeriod)
    .ToList();
                        Console.WriteLine("Registros en netSalesByPeriod: " + netSalesByPeriod.Count);
                        foreach (var item in netSalesByPeriod)
                        {
                            Console.WriteLine($"{item.datePeriod:yyyy-MM-dd} => {item.netSales}");
                        }

                        // 4) Agregar el DataSet con el nombre EXACTO que espera el .rdlc
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("netSalesByPeriod", netSalesByPeriod)
                        );

                        // 5) (Opcional) Crear parámetros si tu .rdlc los define
                        var paramReportDate = new ReportParameter("ReportDateParam", DateTime.Now.ToString("yyyy-MM-dd"));
                        var paramStartDate = new ReportParameter("StartDateParam", fDate.ToString("yyyy-MM-dd"));
                        var paramEndDate = new ReportParameter("EndDateParam", tDate.ToString("yyyy-MM-dd"));

                        reportViewer1.LocalReport.SetParameters(new[] { paramReportDate, paramStartDate, paramEndDate });

                        // 6) Refrescar
                        reportViewer1.RefreshReport();
                        break;
                    }

                default:
                    {
                        MessageBox.Show("Reporte no implementado: " + subReport);
                        break;
                    }
            }

            // Refrescamos el reporte una sola vez tras el switch
            reportViewer1.RefreshReport();
        }

        // (Opcional) Método auxiliar para filtrar cumpleaños en un rango
        private List<ClientListing> getBirthdaysInRange(List<ClientListing> allClients, DateTime fromDate, DateTime toDate)
        {
            var result = new List<ClientListing>();
            foreach (var c in allClients)
            {
                try
                {
                    DateTime birthdayThisYear = new DateTime(fromDate.Year, c.ClientBirthDate.Month, c.ClientBirthDate.Day);
                    if (birthdayThisYear >= fromDate && birthdayThisYear <= toDate)
                        result.Add(c);
                }
                catch
                {
                    // Manejo de excepciones, por ejemplo, 29-feb en años no bisiestos
                }
            }
            return result;
        }
    }
}
