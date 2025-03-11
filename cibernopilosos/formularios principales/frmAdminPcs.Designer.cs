namespace cibernopilosos.formularios
{
    partial class frmAdminPcs
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
            this.flwPanelCuadro = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregarPC = new System.Windows.Forms.Button();
            this.btnEditarPC = new System.Windows.Forms.Button();
            this.btnBorrarPC = new System.Windows.Forms.Button();
            this.dgvAdmiPCs = new System.Windows.Forms.DataGridView();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.pnlPrecio = new System.Windows.Forms.Panel();
            this.lblTextoPrecioActual = new System.Windows.Forms.Label();
            this.lblPrecioActual = new System.Windows.Forms.Label();
            this.lblTextNuevoPrecio = new System.Windows.Forms.Label();
            this.btnNuevoPrecio = new System.Windows.Forms.Button();
            this.numDolares = new System.Windows.Forms.NumericUpDown();
            this.numCentavos = new System.Windows.Forms.NumericUpDown();
            this.lblDolares = new System.Windows.Forms.Label();
            this.lblCentavos = new System.Windows.Forms.Label();
            this.flwPanelCuadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiPCs)).BeginInit();
            this.pnlDgv.SuspendLayout();
            this.pnlPrecio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCentavos)).BeginInit();
            this.SuspendLayout();
            // 
            // flwPanelCuadro
            // 
            this.flwPanelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.flwPanelCuadro.Controls.Add(this.btnAgregarPC);
            this.flwPanelCuadro.Controls.Add(this.btnEditarPC);
            this.flwPanelCuadro.Controls.Add(this.btnBorrarPC);
            this.flwPanelCuadro.Controls.Add(this.pnlPrecio);
            this.flwPanelCuadro.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwPanelCuadro.Location = new System.Drawing.Point(606, 0);
            this.flwPanelCuadro.Name = "flwPanelCuadro";
            this.flwPanelCuadro.Size = new System.Drawing.Size(217, 561);
            this.flwPanelCuadro.TabIndex = 0;
            // 
            // btnAgregarPC
            // 
            this.btnAgregarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnAgregarPC.FlatAppearance.BorderSize = 0;
            this.btnAgregarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPC.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarPC.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarPC.Name = "btnAgregarPC";
            this.btnAgregarPC.Size = new System.Drawing.Size(214, 60);
            this.btnAgregarPC.TabIndex = 0;
            this.btnAgregarPC.Text = "Agregar Computadora";
            this.btnAgregarPC.UseVisualStyleBackColor = false;
            this.btnAgregarPC.Click += new System.EventHandler(this.btnAgregarPC_Click);
            // 
            // btnEditarPC
            // 
            this.btnEditarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnEditarPC.FlatAppearance.BorderSize = 0;
            this.btnEditarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarPC.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditarPC.Location = new System.Drawing.Point(3, 69);
            this.btnEditarPC.Name = "btnEditarPC";
            this.btnEditarPC.Size = new System.Drawing.Size(214, 60);
            this.btnEditarPC.TabIndex = 1;
            this.btnEditarPC.Text = "Editar Selección";
            this.btnEditarPC.UseVisualStyleBackColor = false;
            this.btnEditarPC.Click += new System.EventHandler(this.btnEditarPC_Click);
            // 
            // btnBorrarPC
            // 
            this.btnBorrarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnBorrarPC.FlatAppearance.BorderSize = 0;
            this.btnBorrarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarPC.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarPC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarPC.Location = new System.Drawing.Point(3, 135);
            this.btnBorrarPC.Name = "btnBorrarPC";
            this.btnBorrarPC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBorrarPC.Size = new System.Drawing.Size(214, 60);
            this.btnBorrarPC.TabIndex = 2;
            this.btnBorrarPC.Text = "Borrar Computadora";
            this.btnBorrarPC.UseVisualStyleBackColor = false;
            this.btnBorrarPC.Click += new System.EventHandler(this.btnBorrarPC_Click);
            // 
            // dgvAdmiPCs
            // 
            this.dgvAdmiPCs.AllowUserToAddRows = false;
            this.dgvAdmiPCs.AllowUserToDeleteRows = false;
            this.dgvAdmiPCs.AllowUserToResizeColumns = false;
            this.dgvAdmiPCs.AllowUserToResizeRows = false;
            this.dgvAdmiPCs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(227)))));
            this.dgvAdmiPCs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdmiPCs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvAdmiPCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmiPCs.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dgvAdmiPCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdmiPCs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(70)))), ((int)(((byte)(21)))));
            this.dgvAdmiPCs.Location = new System.Drawing.Point(0, 0);
            this.dgvAdmiPCs.MultiSelect = false;
            this.dgvAdmiPCs.Name = "dgvAdmiPCs";
            this.dgvAdmiPCs.ReadOnly = true;
            this.dgvAdmiPCs.RowHeadersVisible = false;
            this.dgvAdmiPCs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdmiPCs.Size = new System.Drawing.Size(606, 561);
            this.dgvAdmiPCs.TabIndex = 0;
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.Thistle;
            this.pnlDgv.Controls.Add(this.dgvAdmiPCs);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(0, 0);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(606, 561);
            this.pnlDgv.TabIndex = 1;
            // 
            // pnlPrecio
            // 
            this.pnlPrecio.Controls.Add(this.lblCentavos);
            this.pnlPrecio.Controls.Add(this.lblDolares);
            this.pnlPrecio.Controls.Add(this.numCentavos);
            this.pnlPrecio.Controls.Add(this.numDolares);
            this.pnlPrecio.Controls.Add(this.btnNuevoPrecio);
            this.pnlPrecio.Controls.Add(this.lblTextNuevoPrecio);
            this.pnlPrecio.Controls.Add(this.lblPrecioActual);
            this.pnlPrecio.Controls.Add(this.lblTextoPrecioActual);
            this.pnlPrecio.Location = new System.Drawing.Point(3, 201);
            this.pnlPrecio.Name = "pnlPrecio";
            this.pnlPrecio.Size = new System.Drawing.Size(214, 167);
            this.pnlPrecio.TabIndex = 4;
            // 
            // lblTextoPrecioActual
            // 
            this.lblTextoPrecioActual.AutoSize = true;
            this.lblTextoPrecioActual.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoPrecioActual.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTextoPrecioActual.Location = new System.Drawing.Point(12, 12);
            this.lblTextoPrecioActual.Name = "lblTextoPrecioActual";
            this.lblTextoPrecioActual.Size = new System.Drawing.Size(114, 16);
            this.lblTextoPrecioActual.TabIndex = 0;
            this.lblTextoPrecioActual.Text = "Precio Actual:";
            // 
            // lblPrecioActual
            // 
            this.lblPrecioActual.AutoSize = true;
            this.lblPrecioActual.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioActual.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPrecioActual.Location = new System.Drawing.Point(132, 12);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new System.Drawing.Size(25, 16);
            this.lblPrecioActual.TabIndex = 1;
            this.lblPrecioActual.Text = "...";
            // 
            // lblTextNuevoPrecio
            // 
            this.lblTextNuevoPrecio.AutoSize = true;
            this.lblTextNuevoPrecio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextNuevoPrecio.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTextNuevoPrecio.Location = new System.Drawing.Point(12, 49);
            this.lblTextNuevoPrecio.Name = "lblTextNuevoPrecio";
            this.lblTextNuevoPrecio.Size = new System.Drawing.Size(118, 16);
            this.lblTextNuevoPrecio.TabIndex = 2;
            this.lblTextNuevoPrecio.Text = "Cambiar Precio";
            // 
            // btnNuevoPrecio
            // 
            this.btnNuevoPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNuevoPrecio.FlatAppearance.BorderSize = 0;
            this.btnNuevoPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPrecio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPrecio.Location = new System.Drawing.Point(104, 87);
            this.btnNuevoPrecio.Name = "btnNuevoPrecio";
            this.btnNuevoPrecio.Size = new System.Drawing.Size(85, 66);
            this.btnNuevoPrecio.TabIndex = 4;
            this.btnNuevoPrecio.Text = "Cambiar";
            this.btnNuevoPrecio.UseVisualStyleBackColor = false;
            this.btnNuevoPrecio.Click += new System.EventHandler(this.btnNuevoPrecio_Click);
            // 
            // numDolares
            // 
            this.numDolares.Location = new System.Drawing.Point(17, 90);
            this.numDolares.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numDolares.Name = "numDolares";
            this.numDolares.Size = new System.Drawing.Size(52, 20);
            this.numDolares.TabIndex = 5;
            // 
            // numCentavos
            // 
            this.numCentavos.Location = new System.Drawing.Point(17, 133);
            this.numCentavos.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numCentavos.Name = "numCentavos";
            this.numCentavos.Size = new System.Drawing.Size(52, 20);
            this.numCentavos.TabIndex = 6;
            // 
            // lblDolares
            // 
            this.lblDolares.AutoSize = true;
            this.lblDolares.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDolares.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDolares.Location = new System.Drawing.Point(14, 71);
            this.lblDolares.Name = "lblDolares";
            this.lblDolares.Size = new System.Drawing.Size(69, 16);
            this.lblDolares.TabIndex = 7;
            this.lblDolares.Text = "Dolares:";
            // 
            // lblCentavos
            // 
            this.lblCentavos.AutoSize = true;
            this.lblCentavos.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentavos.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblCentavos.Location = new System.Drawing.Point(14, 114);
            this.lblCentavos.Name = "lblCentavos";
            this.lblCentavos.Size = new System.Drawing.Size(84, 16);
            this.lblCentavos.TabIndex = 8;
            this.lblCentavos.Text = "Centavos:";
            // 
            // frmAdminPcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(823, 561);
            this.Controls.Add(this.pnlDgv);
            this.Controls.Add(this.flwPanelCuadro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminPcs";
            this.Text = "frmAdministrarComputadoras";
            this.Load += new System.EventHandler(this.frmAdminPcs_Load);
            this.flwPanelCuadro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiPCs)).EndInit();
            this.pnlDgv.ResumeLayout(false);
            this.pnlPrecio.ResumeLayout(false);
            this.pnlPrecio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCentavos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAdmiPCs;
        private System.Windows.Forms.Button btnAgregarPC;
        private System.Windows.Forms.Button btnBorrarPC;
        private System.Windows.Forms.Panel pnlDgv;
        public System.Windows.Forms.Button btnEditarPC;
        public System.Windows.Forms.FlowLayoutPanel flwPanelCuadro;
        private System.Windows.Forms.Panel pnlPrecio;
        private System.Windows.Forms.Label lblTextoPrecioActual;
        private System.Windows.Forms.Label lblPrecioActual;
        private System.Windows.Forms.Label lblTextNuevoPrecio;
        private System.Windows.Forms.Button btnNuevoPrecio;
        private System.Windows.Forms.Label lblCentavos;
        private System.Windows.Forms.Label lblDolares;
        private System.Windows.Forms.NumericUpDown numCentavos;
        private System.Windows.Forms.NumericUpDown numDolares;
    }
}