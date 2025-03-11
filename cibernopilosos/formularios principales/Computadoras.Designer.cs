namespace cibernopilosos
{
    partial class Computadoras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnCerrarApp = new System.Windows.Forms.Button();
            this.btnBloqueoPc = new System.Windows.Forms.Button();
            this.btnAgregarTiempo = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            this.numMinutos = new System.Windows.Forms.NumericUpDown();
            this.txtboxMensajes = new System.Windows.Forms.TextBox();
            this.dgvComputadoras = new System.Windows.Forms.DataGridView();
            this.flwPanelContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOpcionesText = new System.Windows.Forms.Panel();
            this.lblOpciones = new System.Windows.Forms.Label();
            this.pblContadores = new System.Windows.Forms.Panel();
            this.lblTiempoRestante = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDgv = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadoras)).BeginInit();
            this.flwPanelContenedor.SuspendLayout();
            this.pnlOpcionesText.SuspendLayout();
            this.pblContadores.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApagar
            // 
            this.btnApagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnApagar.FlatAppearance.BorderSize = 0;
            this.btnApagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApagar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApagar.Location = new System.Drawing.Point(3, 209);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(197, 40);
            this.btnApagar.TabIndex = 2;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = false;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReiniciar.Location = new System.Drawing.Point(3, 255);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(197, 40);
            this.btnReiniciar.TabIndex = 3;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnCerrarApp
            // 
            this.btnCerrarApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnCerrarApp.FlatAppearance.BorderSize = 0;
            this.btnCerrarApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarApp.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarApp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarApp.Location = new System.Drawing.Point(3, 301);
            this.btnCerrarApp.Name = "btnCerrarApp";
            this.btnCerrarApp.Size = new System.Drawing.Size(197, 43);
            this.btnCerrarApp.TabIndex = 4;
            this.btnCerrarApp.Text = "Cerrar App";
            this.btnCerrarApp.UseVisualStyleBackColor = false;
            this.btnCerrarApp.Click += new System.EventHandler(this.btnCerrarApp_Click);
            // 
            // btnBloqueoPc
            // 
            this.btnBloqueoPc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnBloqueoPc.FlatAppearance.BorderSize = 0;
            this.btnBloqueoPc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBloqueoPc.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBloqueoPc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBloqueoPc.Location = new System.Drawing.Point(3, 350);
            this.btnBloqueoPc.Name = "btnBloqueoPc";
            this.btnBloqueoPc.Size = new System.Drawing.Size(197, 48);
            this.btnBloqueoPc.TabIndex = 5;
            this.btnBloqueoPc.Text = "Bloquear PC";
            this.btnBloqueoPc.UseVisualStyleBackColor = false;
            this.btnBloqueoPc.Click += new System.EventHandler(this.btnBloqueoPc_Click);
            // 
            // btnAgregarTiempo
            // 
            this.btnAgregarTiempo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnAgregarTiempo.FlatAppearance.BorderSize = 0;
            this.btnAgregarTiempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTiempo.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTiempo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarTiempo.Location = new System.Drawing.Point(3, 155);
            this.btnAgregarTiempo.Name = "btnAgregarTiempo";
            this.btnAgregarTiempo.Size = new System.Drawing.Size(197, 48);
            this.btnAgregarTiempo.TabIndex = 6;
            this.btnAgregarTiempo.Text = "Agregar Tiempo";
            this.btnAgregarTiempo.UseVisualStyleBackColor = false;
            this.btnAgregarTiempo.Click += new System.EventHandler(this.btnAgregarTiempo_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIniciar.Location = new System.Drawing.Point(3, 98);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(197, 51);
            this.btnIniciar.TabIndex = 7;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // numHoras
            // 
            this.numHoras.Location = new System.Drawing.Point(75, 8);
            this.numHoras.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHoras.Name = "numHoras";
            this.numHoras.Size = new System.Drawing.Size(60, 20);
            this.numHoras.TabIndex = 8;
            // 
            // numMinutos
            // 
            this.numMinutos.Location = new System.Drawing.Point(133, 8);
            this.numMinutos.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutos.Name = "numMinutos";
            this.numMinutos.Size = new System.Drawing.Size(55, 20);
            this.numMinutos.TabIndex = 9;
            // 
            // txtboxMensajes
            // 
            this.txtboxMensajes.Location = new System.Drawing.Point(3, 446);
            this.txtboxMensajes.Multiline = true;
            this.txtboxMensajes.Name = "txtboxMensajes";
            this.txtboxMensajes.Size = new System.Drawing.Size(196, 76);
            this.txtboxMensajes.TabIndex = 10;
            this.txtboxMensajes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtboxMensajes_KeyDown);
            // 
            // dgvComputadoras
            // 
            this.dgvComputadoras.AllowUserToAddRows = false;
            this.dgvComputadoras.AllowUserToDeleteRows = false;
            this.dgvComputadoras.AllowUserToResizeColumns = false;
            this.dgvComputadoras.AllowUserToResizeRows = false;
            this.dgvComputadoras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.dgvComputadoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComputadoras.ColumnHeadersVisible = false;
            this.dgvComputadoras.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dgvComputadoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComputadoras.Location = new System.Drawing.Point(0, 0);
            this.dgvComputadoras.MultiSelect = false;
            this.dgvComputadoras.Name = "dgvComputadoras";
            this.dgvComputadoras.ReadOnly = true;
            this.dgvComputadoras.RowHeadersVisible = false;
            this.dgvComputadoras.RowHeadersWidth = 40;
            this.dgvComputadoras.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvComputadoras.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.dgvComputadoras.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComputadoras.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvComputadoras.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvComputadoras.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvComputadoras.RowTemplate.Height = 100;
            this.dgvComputadoras.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComputadoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComputadoras.Size = new System.Drawing.Size(604, 522);
            this.dgvComputadoras.TabIndex = 11;
            // 
            // flwPanelContenedor
            // 
            this.flwPanelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.flwPanelContenedor.Controls.Add(this.pnlOpcionesText);
            this.flwPanelContenedor.Controls.Add(this.pblContadores);
            this.flwPanelContenedor.Controls.Add(this.btnIniciar);
            this.flwPanelContenedor.Controls.Add(this.btnAgregarTiempo);
            this.flwPanelContenedor.Controls.Add(this.btnApagar);
            this.flwPanelContenedor.Controls.Add(this.btnReiniciar);
            this.flwPanelContenedor.Controls.Add(this.btnCerrarApp);
            this.flwPanelContenedor.Controls.Add(this.btnBloqueoPc);
            this.flwPanelContenedor.Controls.Add(this.panel3);
            this.flwPanelContenedor.Controls.Add(this.txtboxMensajes);
            this.flwPanelContenedor.Dock = System.Windows.Forms.DockStyle.Right;
            this.flwPanelContenedor.Location = new System.Drawing.Point(604, 0);
            this.flwPanelContenedor.Name = "flwPanelContenedor";
            this.flwPanelContenedor.Size = new System.Drawing.Size(203, 522);
            this.flwPanelContenedor.TabIndex = 12;
            // 
            // pnlOpcionesText
            // 
            this.pnlOpcionesText.Controls.Add(this.lblOpciones);
            this.pnlOpcionesText.Location = new System.Drawing.Point(3, 3);
            this.pnlOpcionesText.Name = "pnlOpcionesText";
            this.pnlOpcionesText.Size = new System.Drawing.Size(197, 44);
            this.pnlOpcionesText.TabIndex = 0;
            // 
            // lblOpciones
            // 
            this.lblOpciones.AutoSize = true;
            this.lblOpciones.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpciones.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOpciones.Location = new System.Drawing.Point(29, 9);
            this.lblOpciones.Name = "lblOpciones";
            this.lblOpciones.Size = new System.Drawing.Size(133, 26);
            this.lblOpciones.TabIndex = 13;
            this.lblOpciones.Text = "OPCIONES";
            // 
            // pblContadores
            // 
            this.pblContadores.Controls.Add(this.numMinutos);
            this.pblContadores.Controls.Add(this.lblTiempoRestante);
            this.pblContadores.Controls.Add(this.numHoras);
            this.pblContadores.Location = new System.Drawing.Point(3, 53);
            this.pblContadores.Name = "pblContadores";
            this.pblContadores.Size = new System.Drawing.Size(197, 39);
            this.pblContadores.TabIndex = 8;
            // 
            // lblTiempoRestante
            // 
            this.lblTiempoRestante.AutoSize = true;
            this.lblTiempoRestante.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoRestante.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTiempoRestante.Location = new System.Drawing.Point(9, 8);
            this.lblTiempoRestante.Name = "lblTiempoRestante";
            this.lblTiempoRestante.Size = new System.Drawing.Size(57, 16);
            this.lblTiempoRestante.TabIndex = 10;
            this.lblTiempoRestante.Text = "tiempo";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.panel3.Controls.Add(this.btnEnviarMensaje);
            this.panel3.Controls.Add(this.label2);
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Location = new System.Drawing.Point(3, 404);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 36);
            this.panel3.TabIndex = 14;
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnviarMensaje.FlatAppearance.BorderSize = 0;
            this.btnEnviarMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarMensaje.Location = new System.Drawing.Point(159, 7);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(29, 23);
            this.btnEnviarMensaje.TabIndex = 14;
            this.btnEnviarMensaje.UseVisualStyleBackColor = false;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enviar Mensaje";
            // 
            // pnlDgv
            // 
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(0, 0);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(604, 522);
            this.pnlDgv.TabIndex = 13;
            // 
            // Computadoras
            // 
            this.ClientSize = new System.Drawing.Size(807, 522);
            this.Controls.Add(this.dgvComputadoras);
            this.Controls.Add(this.pnlDgv);
            this.Controls.Add(this.flwPanelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Computadoras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Computadoras_FormClosing);
            this.Load += new System.EventHandler(this.Computadoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadoras)).EndInit();
            this.flwPanelContenedor.ResumeLayout(false);
            this.flwPanelContenedor.PerformLayout();
            this.pnlOpcionesText.ResumeLayout(false);
            this.pnlOpcionesText.PerformLayout();
            this.pblContadores.ResumeLayout(false);
            this.pblContadores.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnCerrarApp;
        private System.Windows.Forms.Button btnBloqueoPc;
        private System.Windows.Forms.Button btnAgregarTiempo;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.NumericUpDown numHoras;
        private System.Windows.Forms.NumericUpDown numMinutos;
        private System.Windows.Forms.TextBox txtboxMensajes;
        private System.Windows.Forms.DataGridView dgvComputadoras;
        private System.Windows.Forms.FlowLayoutPanel flwPanelContenedor;
        private System.Windows.Forms.Panel pnlOpcionesText;
        private System.Windows.Forms.Label lblOpciones;
        private System.Windows.Forms.Panel pblContadores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.Label lblTiempoRestante;
    }
}