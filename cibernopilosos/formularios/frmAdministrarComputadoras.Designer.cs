namespace cibernopilosos.formularios
{
    partial class frmAdministrarComputadoras
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
            this.btnAjustarPrecios = new System.Windows.Forms.Button();
            this.dgvAdmiPCs = new System.Windows.Forms.DataGridView();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.flwPanelCuadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiPCs)).BeginInit();
            this.pnlDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // flwPanelCuadro
            // 
            this.flwPanelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(227)))));
            this.flwPanelCuadro.Controls.Add(this.btnAgregarPC);
            this.flwPanelCuadro.Controls.Add(this.btnEditarPC);
            this.flwPanelCuadro.Controls.Add(this.btnBorrarPC);
            this.flwPanelCuadro.Controls.Add(this.btnAjustarPrecios);
            this.flwPanelCuadro.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwPanelCuadro.Location = new System.Drawing.Point(606, 0);
            this.flwPanelCuadro.Name = "flwPanelCuadro";
            this.flwPanelCuadro.Size = new System.Drawing.Size(217, 561);
            this.flwPanelCuadro.TabIndex = 0;
            this.flwPanelCuadro.Paint += new System.Windows.Forms.PaintEventHandler(this.flwPanelCuadro_Paint);
            // 
            // btnAgregarPC
            // 
            this.btnAgregarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(153)))), ((int)(((byte)(120)))));
            this.btnAgregarPC.FlatAppearance.BorderSize = 0;
            this.btnAgregarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnEditarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(153)))), ((int)(((byte)(120)))));
            this.btnEditarPC.FlatAppearance.BorderSize = 0;
            this.btnEditarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnBorrarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(153)))), ((int)(((byte)(120)))));
            this.btnBorrarPC.FlatAppearance.BorderSize = 0;
            this.btnBorrarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnAjustarPrecios
            // 
            this.btnAjustarPrecios.BackColor = System.Drawing.Color.Gray;
            this.btnAjustarPrecios.FlatAppearance.BorderSize = 0;
            this.btnAjustarPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustarPrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustarPrecios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAjustarPrecios.Location = new System.Drawing.Point(3, 201);
            this.btnAjustarPrecios.Name = "btnAjustarPrecios";
            this.btnAjustarPrecios.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAjustarPrecios.Size = new System.Drawing.Size(214, 60);
            this.btnAjustarPrecios.TabIndex = 3;
            this.btnAjustarPrecios.Text = "Editar precio";
            this.btnAjustarPrecios.UseVisualStyleBackColor = false;
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
            // frmAdministrarComputadoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(823, 561);
            this.Controls.Add(this.pnlDgv);
            this.Controls.Add(this.flwPanelCuadro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdministrarComputadoras";
            this.Text = "frmAdministrarComputadoras";
            this.flwPanelCuadro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiPCs)).EndInit();
            this.pnlDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAdmiPCs;
        private System.Windows.Forms.Button btnAgregarPC;
        private System.Windows.Forms.Button btnBorrarPC;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.Button btnAjustarPrecios;
        public System.Windows.Forms.Button btnEditarPC;
        public System.Windows.Forms.FlowLayoutPanel flwPanelCuadro;
    }
}