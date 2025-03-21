using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace cibernopilosos.Recibo
{
    public partial class frmReport: Form
    {
        sqlConexion conexion = new sqlConexion();
        private string nombreReport, dataSetReporte, consulta;
        public frmReport(string nombreReport, string dataSetReporte, string consulta)
        {
            this.nombreReport = nombreReport;
            this.dataSetReporte = dataSetReporte;
            this.consulta = consulta;
            InitializeComponent();
        }

        private void frmRecibo_Load(object sender, EventArgs e)
        {
            DataTable dt = conexion.retornaRegistros(consulta);
            rvwVisorReporte.LocalReport.ReportEmbeddedResource = nombreReport;
            rvwVisorReporte.LocalReport.DataSources.Clear();
            rvwVisorReporte.LocalReport.DataSources.Add(new ReportDataSource(dataSetReporte, dt));
            this.rvwVisorReporte.RefreshReport();
        }
    }
}
