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
    public partial class frmComputadoras : Form
    {
       
        public frmComputadoras()
        {
            InitializeComponent();
            AgregarPCsExistentes();
        }

        private void AgregarPCsExistentes()
        {
            sqlConexion conexionsql = new sqlConexion();
            string consulta = "Select PcID from Computers";
            DataTable dt = conexionsql.retornaRegistros(consulta);
            int[] computadoresExistentes = new int[dt.Rows.Count];
            for (int i = 1; i <= computadoresExistentes.Length; i++)
            {
                AgregarPC();
            }
        }

        #region AgregarPC's
        int pcsID = 1;
        int x = 10, y = 10;

        private void TimerSecundero_Tick(object sender, EventArgs e)
        {

        }


        private void AgregarPC()
        {
            PictureBox nuevaPc = new PictureBox();
            Label lblTiempo = new Label();
            Label lblNombrePC = new Label();

            nuevaPc.Image = imgListaPC.Images[0];
            nuevaPc.Name = $"imgPC{pcsID}";
            nuevaPc.SizeMode = PictureBoxSizeMode.Zoom; 
            nuevaPc.Location = new Point(x, y); 
            nuevaPc.Size = new Size(100, 100);

            lblTiempo.Location = new Point(x, y + 120);
            lblTiempo.Text = "TEST TIEMPO";
            lblNombrePC.Name = $"lblTiempo{pcsID}";

            lblNombrePC.Text = pcsID.ToString();
            lblNombrePC.Location = new Point(x+40, y + 100);
            lblNombrePC.Name = $"lblPC{pcsID}";

            pnlContenedor.Controls.Add(lblNombrePC);
            pnlContenedor.Controls.Add(lblTiempo);
            pnlContenedor.Controls.Add(nuevaPc);

            pcsID++;
            if (x > pnlContenedor.Width-200)
            {
                x = 10;
                y += 150;
            }
            else x += 100;
        }
        #endregion
    }
}
