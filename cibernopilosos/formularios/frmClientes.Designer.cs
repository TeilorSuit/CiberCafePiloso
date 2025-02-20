namespace cibernopilosos.formularios
{
    partial class frmClientes
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
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.btnEditarCliente = new System.Windows.Forms.Button();
            this.btnBorrarCliente = new System.Windows.Forms.Button();
            this.btnAdminSubs = new System.Windows.Forms.Button();
            this.dgvAdmiClientes = new System.Windows.Forms.DataGridView();
            this.flwPanelCuadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // flwPanelCuadro
            // 
            this.flwPanelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(67)))), ((int)(((byte)(80)))));
            this.flwPanelCuadro.Controls.Add(this.btnAgregarCliente);
            this.flwPanelCuadro.Controls.Add(this.btnEditarCliente);
            this.flwPanelCuadro.Controls.Add(this.btnBorrarCliente);
            this.flwPanelCuadro.Controls.Add(this.btnAdminSubs);
            this.flwPanelCuadro.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwPanelCuadro.Location = new System.Drawing.Point(808, 0);
            this.flwPanelCuadro.Margin = new System.Windows.Forms.Padding(4);
            this.flwPanelCuadro.Name = "flwPanelCuadro";
            this.flwPanelCuadro.Size = new System.Drawing.Size(289, 690);
            this.flwPanelCuadro.TabIndex = 1;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnAgregarCliente.FlatAppearance.BorderSize = 0;
            this.btnAgregarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarCliente.Location = new System.Drawing.Point(4, 4);
            this.btnAgregarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(285, 74);
            this.btnAgregarCliente.TabIndex = 0;
            this.btnAgregarCliente.Text = "Agregar Cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // btnEditarCliente
            // 
            this.btnEditarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnEditarCliente.FlatAppearance.BorderSize = 0;
            this.btnEditarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditarCliente.Location = new System.Drawing.Point(4, 86);
            this.btnEditarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Size = new System.Drawing.Size(285, 74);
            this.btnEditarCliente.TabIndex = 1;
            this.btnEditarCliente.Text = "Editar Cliente";
            this.btnEditarCliente.UseVisualStyleBackColor = false;
            this.btnEditarCliente.Click += new System.EventHandler(this.btnEditarCliente_Click);
            // 
            // btnBorrarCliente
            // 
            this.btnBorrarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnBorrarCliente.FlatAppearance.BorderSize = 0;
            this.btnBorrarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBorrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarCliente.Location = new System.Drawing.Point(4, 168);
            this.btnBorrarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrarCliente.Name = "btnBorrarCliente";
            this.btnBorrarCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBorrarCliente.Size = new System.Drawing.Size(285, 74);
            this.btnBorrarCliente.TabIndex = 2;
            this.btnBorrarCliente.Text = "Borrar Cliente";
            this.btnBorrarCliente.UseVisualStyleBackColor = false;
            this.btnBorrarCliente.Click += new System.EventHandler(this.btnBorrarCliente_Click);
            // 
            // btnAdminSubs
            // 
            this.btnAdminSubs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnAdminSubs.FlatAppearance.BorderSize = 0;
            this.btnAdminSubs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdminSubs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminSubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminSubs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdminSubs.Location = new System.Drawing.Point(4, 250);
            this.btnAdminSubs.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdminSubs.Name = "btnAdminSubs";
            this.btnAdminSubs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdminSubs.Size = new System.Drawing.Size(285, 74);
            this.btnAdminSubs.TabIndex = 3;
            this.btnAdminSubs.Text = "Administrar suscripciones";
            this.btnAdminSubs.UseVisualStyleBackColor = false;
            this.btnAdminSubs.Click += new System.EventHandler(this.btnAdminSubs_Click);
            // 
            // dgvAdmiClientes
            // 
            this.dgvAdmiClientes.AllowUserToAddRows = false;
            this.dgvAdmiClientes.AllowUserToDeleteRows = false;
            this.dgvAdmiClientes.AllowUserToResizeColumns = false;
            this.dgvAdmiClientes.AllowUserToResizeRows = false;
            this.dgvAdmiClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(67)))), ((int)(((byte)(80)))));
            this.dgvAdmiClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdmiClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvAdmiClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmiClientes.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dgvAdmiClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdmiClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvAdmiClientes.Location = new System.Drawing.Point(0, 0);
            this.dgvAdmiClientes.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAdmiClientes.MultiSelect = false;
            this.dgvAdmiClientes.Name = "dgvAdmiClientes";
            this.dgvAdmiClientes.ReadOnly = true;
            this.dgvAdmiClientes.RowHeadersVisible = false;
            this.dgvAdmiClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdmiClientes.Size = new System.Drawing.Size(1097, 690);
            this.dgvAdmiClientes.TabIndex = 2;
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1097, 690);
            this.Controls.Add(this.flwPanelCuadro);
            this.Controls.Add(this.dgvAdmiClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            this.flwPanelCuadro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwPanelCuadro;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnEditarCliente;
        private System.Windows.Forms.Button btnBorrarCliente;
        private System.Windows.Forms.Button btnAdminSubs;
        private System.Windows.Forms.DataGridView dgvAdmiClientes;
    }
}