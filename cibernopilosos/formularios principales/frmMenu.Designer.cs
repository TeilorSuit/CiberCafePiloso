namespace cibernopilosos.formularios
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pnlChildForms = new System.Windows.Forms.Panel();
            this.pctMainLogo = new System.Windows.Forms.PictureBox();
            this.flwSideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAmpliarMenu = new System.Windows.Forms.Panel();
            this.btnAmpliarMenu = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.pnlComputadoras = new System.Windows.Forms.Panel();
            this.btnComputadoras = new System.Windows.Forms.Button();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnAdministrarPcs = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.tmrSideBar = new System.Windows.Forms.Timer(this.components);
            this.pnlTransacciones = new System.Windows.Forms.Panel();
            this.btnTransacciones = new System.Windows.Forms.Button();
            this.pnlChildForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMainLogo)).BeginInit();
            this.flwSideBar.SuspendLayout();
            this.pnlAmpliarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.pnlComputadoras.SuspendLayout();
            this.pnlClientes.SuspendLayout();
            this.pnlTransacciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChildForms
            // 
            this.pnlChildForms.BackColor = System.Drawing.Color.White;
            this.pnlChildForms.Controls.Add(this.pctMainLogo);
            this.pnlChildForms.Controls.Add(this.flwSideBar);
            this.pnlChildForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForms.Location = new System.Drawing.Point(0, 0);
            this.pnlChildForms.Name = "pnlChildForms";
            this.pnlChildForms.Size = new System.Drawing.Size(1084, 561);
            this.pnlChildForms.TabIndex = 1;
            // 
            // pctMainLogo
            // 
            this.pctMainLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pctMainLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctMainLogo.Image = global::cibernopilosos.Properties.Resources.CiberPilosoLogoNegro;
            this.pctMainLogo.Location = new System.Drawing.Point(261, 0);
            this.pctMainLogo.Name = "pctMainLogo";
            this.pctMainLogo.Size = new System.Drawing.Size(823, 561);
            this.pctMainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctMainLogo.TabIndex = 3;
            this.pctMainLogo.TabStop = false;
            // 
            // flwSideBar
            // 
            this.flwSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.flwSideBar.Controls.Add(this.pnlAmpliarMenu);
            this.flwSideBar.Controls.Add(this.pnlComputadoras);
            this.flwSideBar.Controls.Add(this.pnlClientes);
            this.flwSideBar.Controls.Add(this.pnlTransacciones);
            this.flwSideBar.Controls.Add(this.pnlSeparador);
            this.flwSideBar.Controls.Add(this.btnUsuarios);
            this.flwSideBar.Controls.Add(this.btnAdministrarPcs);
            this.flwSideBar.Controls.Add(this.btnReportes);
            this.flwSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.flwSideBar.Location = new System.Drawing.Point(0, 0);
            this.flwSideBar.MaximumSize = new System.Drawing.Size(261, 1625);
            this.flwSideBar.MinimumSize = new System.Drawing.Size(90, 561);
            this.flwSideBar.Name = "flwSideBar";
            this.flwSideBar.Size = new System.Drawing.Size(261, 561);
            this.flwSideBar.TabIndex = 0;
            // 
            // pnlAmpliarMenu
            // 
            this.pnlAmpliarMenu.Controls.Add(this.btnAmpliarMenu);
            this.pnlAmpliarMenu.Controls.Add(this.pctLogo);
            this.pnlAmpliarMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAmpliarMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlAmpliarMenu.Name = "pnlAmpliarMenu";
            this.pnlAmpliarMenu.Size = new System.Drawing.Size(200, 74);
            this.pnlAmpliarMenu.TabIndex = 2;
            // 
            // btnAmpliarMenu
            // 
            this.btnAmpliarMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAmpliarMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAmpliarMenu.FlatAppearance.BorderSize = 0;
            this.btnAmpliarMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAmpliarMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAmpliarMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmpliarMenu.ForeColor = System.Drawing.Color.Transparent;
            this.btnAmpliarMenu.ImageIndex = 3;
            this.btnAmpliarMenu.ImageList = this.imgList;
            this.btnAmpliarMenu.Location = new System.Drawing.Point(14, 15);
            this.btnAmpliarMenu.Name = "btnAmpliarMenu";
            this.btnAmpliarMenu.Size = new System.Drawing.Size(59, 46);
            this.btnAmpliarMenu.TabIndex = 2;
            this.btnAmpliarMenu.UseVisualStyleBackColor = true;
            this.btnAmpliarMenu.Click += new System.EventHandler(this.btnAmpliarMenu_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "CiberPilosoLogoBlanco.png");
            this.imgList.Images.SetKeyName(1, "monitorMini.png");
            this.imgList.Images.SetKeyName(2, "clientesmini.png");
            this.imgList.Images.SetKeyName(3, "menu.png");
            this.imgList.Images.SetKeyName(4, "transmoney.png");
            // 
            // pctLogo
            // 
            this.pctLogo.Image = global::cibernopilosos.Properties.Resources.CiberPilosoLogoBlanco;
            this.pctLogo.Location = new System.Drawing.Point(97, 9);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(86, 56);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLogo.TabIndex = 0;
            this.pctLogo.TabStop = false;
            // 
            // pnlComputadoras
            // 
            this.pnlComputadoras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.pnlComputadoras.Controls.Add(this.btnComputadoras);
            this.pnlComputadoras.Location = new System.Drawing.Point(3, 83);
            this.pnlComputadoras.Name = "pnlComputadoras";
            this.pnlComputadoras.Size = new System.Drawing.Size(261, 66);
            this.pnlComputadoras.TabIndex = 5;
            // 
            // btnComputadoras
            // 
            this.btnComputadoras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnComputadoras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnComputadoras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputadoras.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComputadoras.ForeColor = System.Drawing.Color.White;
            this.btnComputadoras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputadoras.ImageIndex = 1;
            this.btnComputadoras.ImageList = this.imgList;
            this.btnComputadoras.Location = new System.Drawing.Point(-9, -9);
            this.btnComputadoras.Name = "btnComputadoras";
            this.btnComputadoras.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnComputadoras.Size = new System.Drawing.Size(293, 85);
            this.btnComputadoras.TabIndex = 0;
            this.btnComputadoras.Text = "             Computadoras";
            this.btnComputadoras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputadoras.UseVisualStyleBackColor = false;
            this.btnComputadoras.Click += new System.EventHandler(this.btnComputadoras_Click);
            // 
            // pnlClientes
            // 
            this.pnlClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.pnlClientes.Controls.Add(this.btnClientes);
            this.pnlClientes.Location = new System.Drawing.Point(3, 155);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(261, 66);
            this.pnlClientes.TabIndex = 5;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.ImageIndex = 2;
            this.btnClientes.ImageList = this.imgList;
            this.btnClientes.Location = new System.Drawing.Point(-9, -9);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(281, 85);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "             Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.pnlSeparador.Location = new System.Drawing.Point(3, 306);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(261, 2);
            this.pnlSeparador.TabIndex = 5;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 314);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(258, 28);
            this.btnUsuarios.TabIndex = 8;
            this.btnUsuarios.Text = "Administrar Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnAdministrarPcs
            // 
            this.btnAdministrarPcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnAdministrarPcs.FlatAppearance.BorderSize = 0;
            this.btnAdministrarPcs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnAdministrarPcs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarPcs.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarPcs.ForeColor = System.Drawing.Color.White;
            this.btnAdministrarPcs.Location = new System.Drawing.Point(3, 348);
            this.btnAdministrarPcs.Name = "btnAdministrarPcs";
            this.btnAdministrarPcs.Size = new System.Drawing.Size(258, 28);
            this.btnAdministrarPcs.TabIndex = 6;
            this.btnAdministrarPcs.Text = "Administrar PCs";
            this.btnAdministrarPcs.UseVisualStyleBackColor = false;
            this.btnAdministrarPcs.Click += new System.EventHandler(this.btnAdministrarPcs_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(3, 382);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(258, 28);
            this.btnReportes.TabIndex = 7;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // tmrSideBar
            // 
            this.tmrSideBar.Interval = 10;
            this.tmrSideBar.Tick += new System.EventHandler(this.tmrSideBar_Tick);
            // 
            // pnlTransacciones
            // 
            this.pnlTransacciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.pnlTransacciones.Controls.Add(this.btnTransacciones);
            this.pnlTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTransacciones.Location = new System.Drawing.Point(3, 227);
            this.pnlTransacciones.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.pnlTransacciones.Name = "pnlTransacciones";
            this.pnlTransacciones.Size = new System.Drawing.Size(261, 66);
            this.pnlTransacciones.TabIndex = 4;
            // 
            // btnTransacciones
            // 
            this.btnTransacciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnTransacciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnTransacciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransacciones.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransacciones.ForeColor = System.Drawing.Color.White;
            this.btnTransacciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransacciones.ImageIndex = 4;
            this.btnTransacciones.ImageList = this.imgList;
            this.btnTransacciones.Location = new System.Drawing.Point(-10, -9);
            this.btnTransacciones.Name = "btnTransacciones";
            this.btnTransacciones.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTransacciones.Size = new System.Drawing.Size(281, 85);
            this.btnTransacciones.TabIndex = 1;
            this.btnTransacciones.Text = "             Transacciones";
            this.btnTransacciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransacciones.UseVisualStyleBackColor = false;
            this.btnTransacciones.Click += new System.EventHandler(this.btnTransacciones_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.pnlChildForms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "frmMenu";
            this.Text = "CiberCafe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.pnlChildForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMainLogo)).EndInit();
            this.flwSideBar.ResumeLayout(false);
            this.pnlAmpliarMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.pnlComputadoras.ResumeLayout(false);
            this.pnlClientes.ResumeLayout(false);
            this.pnlTransacciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlChildForms;
        private System.Windows.Forms.FlowLayoutPanel flwSideBar;
        private System.Windows.Forms.Panel pnlAmpliarMenu;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Button btnAmpliarMenu;
        private System.Windows.Forms.Panel pnlComputadoras;
        private System.Windows.Forms.Button btnComputadoras;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Timer tmrSideBar;
        private System.Windows.Forms.Button btnAdministrarPcs;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.PictureBox pctMainLogo;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Panel pnlTransacciones;
        private System.Windows.Forms.Button btnTransacciones;
    }
}