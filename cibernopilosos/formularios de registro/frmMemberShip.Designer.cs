namespace cibernopilosos.formularios_de_registro
{
    partial class frmMemberShip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMembership = new System.Windows.Forms.Panel();
            this.dgvMembership = new System.Windows.Forms.DataGridView();
            this.lblMemberShip = new System.Windows.Forms.Label();
            this.btnConfirmacion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lbltextcobro = new System.Windows.Forms.Label();
            this.lblValorCobrar = new System.Windows.Forms.Label();
            this.pnlMembership.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembership)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMembership
            // 
            this.pnlMembership.Controls.Add(this.dgvMembership);
            this.pnlMembership.Location = new System.Drawing.Point(12, 92);
            this.pnlMembership.Name = "pnlMembership";
            this.pnlMembership.Size = new System.Drawing.Size(497, 146);
            this.pnlMembership.TabIndex = 9;
            // 
            // dgvMembership
            // 
            this.dgvMembership.AllowUserToAddRows = false;
            this.dgvMembership.AllowUserToDeleteRows = false;
            this.dgvMembership.AllowUserToResizeRows = false;
            this.dgvMembership.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(67)))), ((int)(((byte)(80)))));
            this.dgvMembership.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvMembership.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembership.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMembership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembership.EnableHeadersVisualStyles = false;
            this.dgvMembership.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            this.dgvMembership.Location = new System.Drawing.Point(0, 0);
            this.dgvMembership.MultiSelect = false;
            this.dgvMembership.Name = "dgvMembership";
            this.dgvMembership.ReadOnly = true;
            this.dgvMembership.RowHeadersVisible = false;
            this.dgvMembership.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(72)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMembership.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMembership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembership.Size = new System.Drawing.Size(497, 146);
            this.dgvMembership.TabIndex = 0;
            this.dgvMembership.SelectionChanged += new System.EventHandler(this.dgvMembership_SelectionChanged);
            // 
            // lblMemberShip
            // 
            this.lblMemberShip.AutoSize = true;
            this.lblMemberShip.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberShip.ForeColor = System.Drawing.Color.White;
            this.lblMemberShip.Location = new System.Drawing.Point(179, 24);
            this.lblMemberShip.Name = "lblMemberShip";
            this.lblMemberShip.Size = new System.Drawing.Size(163, 26);
            this.lblMemberShip.TabIndex = 8;
            this.lblMemberShip.Text = "MEMBRESÍAS";
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnConfirmacion.FlatAppearance.BorderSize = 0;
            this.btnConfirmacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirmacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmacion.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmacion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmacion.Location = new System.Drawing.Point(12, 257);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnConfirmacion.Size = new System.Drawing.Size(250, 54);
            this.btnConfirmacion.TabIndex = 10;
            this.btnConfirmacion.Text = "Aceptar";
            this.btnConfirmacion.UseVisualStyleBackColor = false;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.Location = new System.Drawing.Point(259, 257);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSalir.Size = new System.Drawing.Size(250, 54);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lbltextcobro
            // 
            this.lbltextcobro.AutoSize = true;
            this.lbltextcobro.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltextcobro.ForeColor = System.Drawing.Color.White;
            this.lbltextcobro.Location = new System.Drawing.Point(8, 60);
            this.lbltextcobro.Name = "lbltextcobro";
            this.lbltextcobro.Size = new System.Drawing.Size(145, 20);
            this.lbltextcobro.TabIndex = 12;
            this.lbltextcobro.Text = "Valor a cobrar:";
            // 
            // lblValorCobrar
            // 
            this.lblValorCobrar.AutoSize = true;
            this.lblValorCobrar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCobrar.ForeColor = System.Drawing.Color.White;
            this.lblValorCobrar.Location = new System.Drawing.Point(149, 61);
            this.lblValorCobrar.Name = "lblValorCobrar";
            this.lblValorCobrar.Size = new System.Drawing.Size(60, 20);
            this.lblValorCobrar.TabIndex = 13;
            this.lblValorCobrar.Text = "00.00";
            // 
            // frmMemberShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(67)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(521, 324);
            this.Controls.Add(this.lblValorCobrar);
            this.Controls.Add(this.lbltextcobro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.pnlMembership);
            this.Controls.Add(this.lblMemberShip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(537, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(537, 363);
            this.Name = "frmMemberShip";
            this.ShowIcon = false;
            this.Text = "Membresías";
            this.Load += new System.EventHandler(this.frmMemberShip_Load);
            this.pnlMembership.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembership)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMembership;
        private System.Windows.Forms.Label lblMemberShip;
        private System.Windows.Forms.DataGridView dgvMembership;
        private System.Windows.Forms.Button btnConfirmacion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lbltextcobro;
        private System.Windows.Forms.Label lblValorCobrar;
    }
}