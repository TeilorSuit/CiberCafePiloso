namespace Presentation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        // Botones y panel
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelLogo;
        private FontAwesome.Sharp.IconButton btnThisMonth;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnLast7Days;
        private FontAwesome.Sharp.IconButton btnThisYear;

        // Un iconMenuItem (si lo usas)
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.btnThisYear = new FontAwesome.Sharp.IconButton();
            this.btnThisMonth = new FontAwesome.Sharp.IconButton();
            this.btnLast7Days = new FontAwesome.Sharp.IconButton();
            this.treeViewReports = new System.Windows.Forms.TreeView();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(150, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(650, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // PanelLogo
            // 
            this.PanelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Enabled = false;
            this.PanelLogo.ForeColor = System.Drawing.Color.Black;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(150, 63);
            this.PanelLogo.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnThisYear);
            this.panel1.Controls.Add(this.btnThisMonth);
            this.panel1.Controls.Add(this.btnLast7Days);
            this.panel1.Controls.Add(this.treeViewReports);
            this.panel1.Controls.Add(this.PanelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 450);
            this.panel1.TabIndex = 1;
            // 
            // btnMenu
            // 
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMenu.IconColor = System.Drawing.Color.Black;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.Location = new System.Drawing.Point(0, 405);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(150, 45);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Volver al Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnThisYear
            // 
            this.btnThisYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThisYear.FlatAppearance.BorderSize = 0;
            this.btnThisYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThisYear.ForeColor = System.Drawing.Color.White;
            this.btnThisYear.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThisYear.IconColor = System.Drawing.Color.Black;
            this.btnThisYear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThisYear.Location = new System.Drawing.Point(0, 344);
            this.btnThisYear.Name = "btnThisYear";
            this.btnThisYear.Size = new System.Drawing.Size(150, 45);
            this.btnThisYear.TabIndex = 3;
            this.btnThisYear.Text = "Este Año";
            this.btnThisYear.UseVisualStyleBackColor = true;
            this.btnThisYear.Click += new System.EventHandler(this.btnThisYear_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThisMonth.FlatAppearance.BorderSize = 0;
            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThisMonth.IconColor = System.Drawing.Color.Black;
            this.btnThisMonth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThisMonth.Location = new System.Drawing.Point(0, 299);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(150, 45);
            this.btnThisMonth.TabIndex = 0;
            this.btnThisMonth.Text = "Últimos 30 días";
            this.btnThisMonth.UseVisualStyleBackColor = true;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnLast7Days
            // 
            this.btnLast7Days.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLast7Days.FlatAppearance.BorderSize = 0;
            this.btnLast7Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast7Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLast7Days.ForeColor = System.Drawing.Color.White;
            this.btnLast7Days.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnLast7Days.IconColor = System.Drawing.Color.Black;
            this.btnLast7Days.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLast7Days.Location = new System.Drawing.Point(0, 254);
            this.btnLast7Days.Name = "btnLast7Days";
            this.btnLast7Days.Size = new System.Drawing.Size(150, 45);
            this.btnLast7Days.TabIndex = 4;
            this.btnLast7Days.Text = "Últimos 7 días";
            this.btnLast7Days.UseVisualStyleBackColor = true;
            this.btnLast7Days.Click += new System.EventHandler(this.btnLast7Days_Click);
            // 
            // treeViewReports
            // 
            this.treeViewReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeViewReports.Location = new System.Drawing.Point(0, 63);
            this.treeViewReports.Name = "treeViewReports";
            this.treeViewReports.Size = new System.Drawing.Size(150, 191);
            this.treeViewReports.TabIndex = 3;
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.iconMenuItem1.Text = "iconMenuItem1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TreeView treeViewReports;
    }
}
