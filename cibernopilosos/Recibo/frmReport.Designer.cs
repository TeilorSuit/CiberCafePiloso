namespace cibernopilosos.Recibo
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rvwVisorReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvwVisorReporte
            // 
            this.rvwVisorReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvwVisorReporte.LocalReport.ReportEmbeddedResource = "cibernopilosos.Recibo.Recibo.rdlc";
            this.rvwVisorReporte.Location = new System.Drawing.Point(0, 0);
            this.rvwVisorReporte.Name = "rvwVisorReporte";
            this.rvwVisorReporte.ServerReport.BearerToken = null;
            this.rvwVisorReporte.Size = new System.Drawing.Size(800, 450);
            this.rvwVisorReporte.TabIndex = 0;
            // 
            // frmRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvwVisorReporte);
            this.Name = "frmRecibo";
            this.Text = "frmRecibo";
            this.Load += new System.EventHandler(this.frmRecibo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwVisorReporte;
    }
}