using System;
using System.Data;
using System.Windows.Forms;

namespace cibernopilosos.formularios
{
    partial class frmTrans
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTransactions;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.pnlBotonesAbajo = new System.Windows.Forms.Panel();
            this.btnNuevoIngresoEgreso = new System.Windows.Forms.Button();
            this.lblMontoApertura = new System.Windows.Forms.Label();
            this.txtMontoApertura = new System.Windows.Forms.TextBox();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtFiltrado = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnRecibo = new System.Windows.Forms.Button();
            this.lblTextoPrecioActual = new System.Windows.Forms.Label();
            this.lblDineroCaja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlBotonesAbajo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AllowUserToResizeColumns = false;
            this.dgvTransactions.AllowUserToResizeRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.Location = new System.Drawing.Point(0, 34);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTransactions.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(822, 469);
            this.dgvTransactions.TabIndex = 0;
            // 
            // pnlBotonesAbajo
            // 
            this.pnlBotonesAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotonesAbajo.Controls.Add(this.btnNuevoIngresoEgreso);
            this.pnlBotonesAbajo.Controls.Add(this.lblMontoApertura);
            this.pnlBotonesAbajo.Controls.Add(this.txtMontoApertura);
            this.pnlBotonesAbajo.Controls.Add(this.btnCerrarCaja);
            this.pnlBotonesAbajo.Controls.Add(this.btnAbrirCaja);
            this.pnlBotonesAbajo.Controls.Add(this.btnDelete);
            this.pnlBotonesAbajo.Location = new System.Drawing.Point(13, 510);
            this.pnlBotonesAbajo.Name = "pnlBotonesAbajo";
            this.pnlBotonesAbajo.Size = new System.Drawing.Size(798, 39);
            this.pnlBotonesAbajo.TabIndex = 9;
            // 
            // btnNuevoIngresoEgreso
            // 
            this.btnNuevoIngresoEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevoIngresoEgreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.btnNuevoIngresoEgreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoIngresoEgreso.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoIngresoEgreso.ForeColor = System.Drawing.Color.White;
            this.btnNuevoIngresoEgreso.Location = new System.Drawing.Point(0, 9);
            this.btnNuevoIngresoEgreso.Name = "btnNuevoIngresoEgreso";
            this.btnNuevoIngresoEgreso.Size = new System.Drawing.Size(162, 30);
            this.btnNuevoIngresoEgreso.TabIndex = 19;
            this.btnNuevoIngresoEgreso.Text = "Nuevo ";
            this.btnNuevoIngresoEgreso.UseVisualStyleBackColor = false;
            this.btnNuevoIngresoEgreso.Click += new System.EventHandler(this.btnNuevoIngresoEgreso_Click);
            // 
            // lblMontoApertura
            // 
            this.lblMontoApertura.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMontoApertura.AutoSize = true;
            this.lblMontoApertura.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoApertura.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMontoApertura.Location = new System.Drawing.Point(374, -1);
            this.lblMontoApertura.Name = "lblMontoApertura";
            this.lblMontoApertura.Size = new System.Drawing.Size(131, 16);
            this.lblMontoApertura.TabIndex = 18;
            this.lblMontoApertura.Text = "Monto Apertura:";
            // 
            // txtMontoApertura
            // 
            this.txtMontoApertura.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMontoApertura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoApertura.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoApertura.Location = new System.Drawing.Point(374, 19);
            this.txtMontoApertura.MaxLength = 20;
            this.txtMontoApertura.Name = "txtMontoApertura";
            this.txtMontoApertura.Size = new System.Drawing.Size(136, 20);
            this.txtMontoApertura.TabIndex = 17;
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarCaja.BackColor = System.Drawing.Color.Maroon;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(663, 9);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(136, 30);
            this.btnCerrarCaja.TabIndex = 16;
            this.btnCerrarCaja.Text = "Cerrar caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCaja.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCaja.Location = new System.Drawing.Point(516, 9);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(136, 30);
            this.btnAbrirCaja.TabIndex = 15;
            this.btnAbrirCaja.Text = "Abrir Caja";
            this.btnAbrirCaja.UseVisualStyleBackColor = false;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(168, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(189, 30);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Borrar Transacción";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(290, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 26);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtFiltrado
            // 
            this.txtFiltrado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltrado.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrado.Location = new System.Drawing.Point(87, 8);
            this.txtFiltrado.MaxLength = 20;
            this.txtFiltrado.Name = "txtFiltrado";
            this.txtFiltrado.Size = new System.Drawing.Size(162, 20);
            this.txtFiltrado.TabIndex = 3;
            this.txtFiltrado.TextChanged += new System.EventHandler(this.txtFiltrado_TextChanged);
            this.txtFiltrado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltrado_KeyPress);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBuscar.Location = new System.Drawing.Point(8, 9);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(77, 20);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.BackgroundImage = global::cibernopilosos.Properties.Resources.filtro;
            this.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiltrar.Location = new System.Drawing.Point(253, 8);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(23, 20);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnRecibo
            // 
            this.btnRecibo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.btnRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibo.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecibo.ForeColor = System.Drawing.Color.White;
            this.btnRecibo.Location = new System.Drawing.Point(420, 4);
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Size = new System.Drawing.Size(155, 26);
            this.btnRecibo.TabIndex = 6;
            this.btnRecibo.Text = "Generar Recibo";
            this.btnRecibo.UseVisualStyleBackColor = false;
            this.btnRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
            // 
            // lblTextoPrecioActual
            // 
            this.lblTextoPrecioActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextoPrecioActual.AutoSize = true;
            this.lblTextoPrecioActual.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoPrecioActual.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTextoPrecioActual.Location = new System.Drawing.Point(585, 8);
            this.lblTextoPrecioActual.Name = "lblTextoPrecioActual";
            this.lblTextoPrecioActual.Size = new System.Drawing.Size(124, 16);
            this.lblTextoPrecioActual.TabIndex = 7;
            this.lblTextoPrecioActual.Text = "Dinero en Caja:";
            // 
            // lblDineroCaja
            // 
            this.lblDineroCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDineroCaja.AutoSize = true;
            this.lblDineroCaja.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDineroCaja.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDineroCaja.Location = new System.Drawing.Point(732, 8);
            this.lblDineroCaja.Name = "lblDineroCaja";
            this.lblDineroCaja.Size = new System.Drawing.Size(25, 16);
            this.lblDineroCaja.TabIndex = 10;
            this.lblDineroCaja.Text = "...";
            // 
            // frmTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(823, 561);
            this.Controls.Add(this.lblDineroCaja);
            this.Controls.Add(this.pnlBotonesAbajo);
            this.Controls.Add(this.lblTextoPrecioActual);
            this.Controls.Add(this.btnRecibo);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtFiltrado);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTrans";
            this.Text = "Transacciones";
            this.Load += new System.EventHandler(this.frmTrans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlBotonesAbajo.ResumeLayout(false);
            this.pnlBotonesAbajo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlBotonesAbajo;
        private Button btnNuevoIngresoEgreso;
        private Label lblMontoApertura;
        private TextBox txtMontoApertura;
        private Button btnCerrarCaja;
        private Button btnAbrirCaja;
        private Button btnDelete;
        private Button btnRefresh;
        private TextBox txtFiltrado;
        private Label lblBuscar;
        private Button btnFiltrar;
        private Button btnRecibo;
        private Label lblTextoPrecioActual;
        private Label lblDineroCaja;
    }
}