﻿namespace cibernopilosos.formularios
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
            this.btnVincularPc = new System.Windows.Forms.Button();
            this.dgvAdmiClientes = new System.Windows.Forms.DataGridView();
            this.btnAddMembership = new System.Windows.Forms.Button();
            this.btnDeleteMembership = new System.Windows.Forms.Button();
            this.pnlMembership = new System.Windows.Forms.Panel();
            this.lblMemberShip = new System.Windows.Forms.Label();
            this.btnVisorMembresias = new System.Windows.Forms.Button();
            this.flwPanelCuadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiClientes)).BeginInit();
            this.pnlMembership.SuspendLayout();
            this.SuspendLayout();
            // 
            // flwPanelCuadro
            // 
            this.flwPanelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(67)))), ((int)(((byte)(80)))));
            this.flwPanelCuadro.Controls.Add(this.btnAgregarCliente);
            this.flwPanelCuadro.Controls.Add(this.btnEditarCliente);
            this.flwPanelCuadro.Controls.Add(this.btnBorrarCliente);
            this.flwPanelCuadro.Controls.Add(this.btnVincularPc);
            this.flwPanelCuadro.Controls.Add(this.pnlMembership);
            this.flwPanelCuadro.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwPanelCuadro.Location = new System.Drawing.Point(606, 0);
            this.flwPanelCuadro.Name = "flwPanelCuadro";
            this.flwPanelCuadro.Size = new System.Drawing.Size(217, 561);
            this.flwPanelCuadro.TabIndex = 1;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnAgregarCliente.FlatAppearance.BorderSize = 0;
            this.btnAgregarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarCliente.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(214, 60);
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
            this.btnEditarCliente.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditarCliente.Location = new System.Drawing.Point(3, 69);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Size = new System.Drawing.Size(214, 60);
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
            this.btnBorrarCliente.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarCliente.Location = new System.Drawing.Point(3, 135);
            this.btnBorrarCliente.Name = "btnBorrarCliente";
            this.btnBorrarCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBorrarCliente.Size = new System.Drawing.Size(214, 60);
            this.btnBorrarCliente.TabIndex = 2;
            this.btnBorrarCliente.Text = "Borrar Cliente";
            this.btnBorrarCliente.UseVisualStyleBackColor = false;
            this.btnBorrarCliente.Click += new System.EventHandler(this.btnBorrarCliente_Click);
            // 
            // btnVincularPc
            // 
            this.btnVincularPc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnVincularPc.FlatAppearance.BorderSize = 0;
            this.btnVincularPc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVincularPc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVincularPc.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVincularPc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVincularPc.Location = new System.Drawing.Point(3, 201);
            this.btnVincularPc.Name = "btnVincularPc";
            this.btnVincularPc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnVincularPc.Size = new System.Drawing.Size(214, 60);
            this.btnVincularPc.TabIndex = 4;
            this.btnVincularPc.Text = "Vincular con Pc";
            this.btnVincularPc.UseVisualStyleBackColor = false;
            this.btnVincularPc.Click += new System.EventHandler(this.btnVincularPc_Click);
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
            this.dgvAdmiClientes.MultiSelect = false;
            this.dgvAdmiClientes.Name = "dgvAdmiClientes";
            this.dgvAdmiClientes.ReadOnly = true;
            this.dgvAdmiClientes.RowHeadersVisible = false;
            this.dgvAdmiClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdmiClientes.Size = new System.Drawing.Size(823, 561);
            this.dgvAdmiClientes.TabIndex = 2;
            // 
            // btnAddMembership
            // 
            this.btnAddMembership.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnAddMembership.FlatAppearance.BorderSize = 0;
            this.btnAddMembership.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddMembership.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMembership.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddMembership.Location = new System.Drawing.Point(111, 32);
            this.btnAddMembership.Name = "btnAddMembership";
            this.btnAddMembership.Size = new System.Drawing.Size(100, 39);
            this.btnAddMembership.TabIndex = 5;
            this.btnAddMembership.Text = "+";
            this.btnAddMembership.UseVisualStyleBackColor = false;
            this.btnAddMembership.Click += new System.EventHandler(this.btnAddMembership_Click);
            // 
            // btnDeleteMembership
            // 
            this.btnDeleteMembership.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnDeleteMembership.FlatAppearance.BorderSize = 0;
            this.btnDeleteMembership.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteMembership.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMembership.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteMembership.Location = new System.Drawing.Point(5, 32);
            this.btnDeleteMembership.Name = "btnDeleteMembership";
            this.btnDeleteMembership.Size = new System.Drawing.Size(100, 39);
            this.btnDeleteMembership.TabIndex = 6;
            this.btnDeleteMembership.Text = "-";
            this.btnDeleteMembership.UseVisualStyleBackColor = false;
            this.btnDeleteMembership.Click += new System.EventHandler(this.btnDeleteMembership_Click);
            // 
            // pnlMembership
            // 
            this.pnlMembership.Controls.Add(this.btnVisorMembresias);
            this.pnlMembership.Controls.Add(this.lblMemberShip);
            this.pnlMembership.Controls.Add(this.btnDeleteMembership);
            this.pnlMembership.Controls.Add(this.btnAddMembership);
            this.pnlMembership.Location = new System.Drawing.Point(3, 267);
            this.pnlMembership.Name = "pnlMembership";
            this.pnlMembership.Size = new System.Drawing.Size(214, 118);
            this.pnlMembership.TabIndex = 7;
            // 
            // lblMemberShip
            // 
            this.lblMemberShip.AutoSize = true;
            this.lblMemberShip.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberShip.ForeColor = System.Drawing.Color.White;
            this.lblMemberShip.Location = new System.Drawing.Point(44, 7);
            this.lblMemberShip.Name = "lblMemberShip";
            this.lblMemberShip.Size = new System.Drawing.Size(118, 19);
            this.lblMemberShip.TabIndex = 7;
            this.lblMemberShip.Text = "MEMBRESÍAS";
            // 
            // btnVisorMembresias
            // 
            this.btnVisorMembresias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnVisorMembresias.FlatAppearance.BorderSize = 0;
            this.btnVisorMembresias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVisorMembresias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisorMembresias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisorMembresias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVisorMembresias.Location = new System.Drawing.Point(5, 77);
            this.btnVisorMembresias.Name = "btnVisorMembresias";
            this.btnVisorMembresias.Size = new System.Drawing.Size(206, 31);
            this.btnVisorMembresias.TabIndex = 8;
            this.btnVisorMembresias.Text = "Ver Membresías";
            this.btnVisorMembresias.UseVisualStyleBackColor = false;
            this.btnVisorMembresias.Click += new System.EventHandler(this.btnVisorMembresias_Click);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(823, 561);
            this.Controls.Add(this.flwPanelCuadro);
            this.Controls.Add(this.dgvAdmiClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            this.flwPanelCuadro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmiClientes)).EndInit();
            this.pnlMembership.ResumeLayout(false);
            this.pnlMembership.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwPanelCuadro;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnEditarCliente;
        private System.Windows.Forms.Button btnBorrarCliente;
        private System.Windows.Forms.DataGridView dgvAdmiClientes;
        private System.Windows.Forms.Button btnVincularPc;
        private System.Windows.Forms.Button btnAddMembership;
        private System.Windows.Forms.Button btnDeleteMembership;
        private System.Windows.Forms.Panel pnlMembership;
        private System.Windows.Forms.Label lblMemberShip;
        private System.Windows.Forms.Button btnVisorMembresias;
    }
}