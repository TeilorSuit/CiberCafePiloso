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
    public partial class frmAdministrarComputadoras : Form
    {
        public frmAdministrarComputadoras()
        {
            InitializeComponent();
            llenarTabla();
        }
        //Agregar PCS
        //Editar PCS
        //Borrar PCS

        private void llenarTabla()
        {
            sqlConexion ConexionSql = new sqlConexion();
            string consulta = "select * from Computers";
            DataTable tabla = ConexionSql.retornaRegistros(consulta);
            dgvAdmiPCs.DataSource = "";
            dgvAdmiPCs.DataSource = tabla;
        }
        private void btnAgregarPC_Click(object sender, EventArgs e)
        {
            frmInformacionPC PcInfo = new frmInformacionPC();
            PcInfo.ShowDialog();
            llenarTabla();
        }

    }
}
