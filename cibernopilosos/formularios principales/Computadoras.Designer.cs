namespace cibernopilosos.formularios_principales
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Computadoras));
            this.btnCerrarApp = new System.Windows.Forms.Button();
            this.btnAgregarTiempo = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            this.numMinutos = new System.Windows.Forms.NumericUpDown();
            this.txtboxMensajes = new System.Windows.Forms.TextBox();
            this.flwPanelContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOpcionesText = new System.Windows.Forms.Panel();
            this.lblOpciones = new System.Windows.Forms.Label();
            this.pblContadores = new System.Windows.Forms.Panel();
            this.lblTiempoRestante = new System.Windows.Forms.Label();
            this.lblMinutosAdd = new System.Windows.Forms.Label();
            this.lblHorasAdd = new System.Windows.Forms.Label();
            this.lblTiempoAdd = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.lblEnviarMensaje = new System.Windows.Forms.Label();
            this.BotonAddClientePc = new System.Windows.Forms.Button();
            this.fpnlComputadoras = new System.Windows.Forms.FlowLayoutPanel();
            this.imglestadoscomputadora = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutos)).BeginInit();
            this.flwPanelContenedor.SuspendLayout();
            this.pnlOpcionesText.SuspendLayout();
            this.pblContadores.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrarApp
            // 
            this.btnCerrarApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnCerrarApp.FlatAppearance.BorderSize = 0;
            this.btnCerrarApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarApp.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarApp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarApp.Location = new System.Drawing.Point(3, 265);
            this.btnCerrarApp.Name = "btnCerrarApp";
            this.btnCerrarApp.Size = new System.Drawing.Size(197, 66);
            this.btnCerrarApp.TabIndex = 4;
            this.btnCerrarApp.Text = "Cerrar App";
            this.btnCerrarApp.UseVisualStyleBackColor = false;
            this.btnCerrarApp.Click += new System.EventHandler(this.btnCerrarApp_Click);
            // 
            // btnAgregarTiempo
            // 
            this.btnAgregarTiempo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.btnAgregarTiempo.FlatAppearance.BorderSize = 0;
            this.btnAgregarTiempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTiempo.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTiempo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarTiempo.Location = new System.Drawing.Point(3, 185);
            this.btnAgregarTiempo.Name = "btnAgregarTiempo";
            this.btnAgregarTiempo.Size = new System.Drawing.Size(197, 74);
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
            this.btnIniciar.Location = new System.Drawing.Point(3, 114);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(197, 65);
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
            this.txtboxMensajes.Location = new System.Drawing.Point(3, 379);
            this.txtboxMensajes.Multiline = true;
            this.txtboxMensajes.Name = "txtboxMensajes";
            this.txtboxMensajes.Size = new System.Drawing.Size(196, 76);
            this.txtboxMensajes.TabIndex = 10;
            this.txtboxMensajes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtboxMensajes_KeyDown);
            // 
            // flwPanelContenedor
            // 
            this.flwPanelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.flwPanelContenedor.Controls.Add(this.pnlOpcionesText);
            this.flwPanelContenedor.Controls.Add(this.pblContadores);
            this.flwPanelContenedor.Controls.Add(this.btnIniciar);
            this.flwPanelContenedor.Controls.Add(this.btnAgregarTiempo);
            this.flwPanelContenedor.Controls.Add(this.btnCerrarApp);
            this.flwPanelContenedor.Controls.Add(this.panel3);
            this.flwPanelContenedor.Controls.Add(this.txtboxMensajes);
            this.flwPanelContenedor.Controls.Add(this.BotonAddClientePc);
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
            this.pblContadores.Controls.Add(this.lblTiempoRestante);
            this.pblContadores.Controls.Add(this.lblMinutosAdd);
            this.pblContadores.Controls.Add(this.lblHorasAdd);
            this.pblContadores.Controls.Add(this.numMinutos);
            this.pblContadores.Controls.Add(this.lblTiempoAdd);
            this.pblContadores.Controls.Add(this.numHoras);
            this.pblContadores.Location = new System.Drawing.Point(3, 53);
            this.pblContadores.Name = "pblContadores";
            this.pblContadores.Size = new System.Drawing.Size(197, 55);
            this.pblContadores.TabIndex = 8;
            // 
            // lblTiempoRestante
            // 
            this.lblTiempoRestante.AutoSize = true;
            this.lblTiempoRestante.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTiempoRestante.Location = new System.Drawing.Point(12, 32);
            this.lblTiempoRestante.Name = "lblTiempoRestante";
            this.lblTiempoRestante.Size = new System.Drawing.Size(19, 13);
            this.lblTiempoRestante.TabIndex = 16;
            this.lblTiempoRestante.Text = "----";
            // 
            // lblMinutosAdd
            // 
            this.lblMinutosAdd.AutoSize = true;
            this.lblMinutosAdd.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutosAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMinutosAdd.Location = new System.Drawing.Point(130, 31);
            this.lblMinutosAdd.Name = "lblMinutosAdd";
            this.lblMinutosAdd.Size = new System.Drawing.Size(57, 15);
            this.lblMinutosAdd.TabIndex = 15;
            this.lblMinutosAdd.Text = "Minutos";
            // 
            // lblHorasAdd
            // 
            this.lblHorasAdd.AutoSize = true;
            this.lblHorasAdd.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHorasAdd.Location = new System.Drawing.Point(72, 31);
            this.lblHorasAdd.Name = "lblHorasAdd";
            this.lblHorasAdd.Size = new System.Drawing.Size(45, 15);
            this.lblHorasAdd.TabIndex = 14;
            this.lblHorasAdd.Text = "Horas";
            // 
            // lblTiempoAdd
            // 
            this.lblTiempoAdd.AutoSize = true;
            this.lblTiempoAdd.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTiempoAdd.Location = new System.Drawing.Point(9, 8);
            this.lblTiempoAdd.Name = "lblTiempoAdd";
            this.lblTiempoAdd.Size = new System.Drawing.Size(57, 16);
            this.lblTiempoAdd.TabIndex = 10;
            this.lblTiempoAdd.Text = "tiempo";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.panel3.Controls.Add(this.btnEnviarMensaje);
            this.panel3.Controls.Add(this.lblEnviarMensaje);
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Location = new System.Drawing.Point(3, 337);
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
            // lblEnviarMensaje
            // 
            this.lblEnviarMensaje.AutoSize = true;
            this.lblEnviarMensaje.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnviarMensaje.Location = new System.Drawing.Point(5, 9);
            this.lblEnviarMensaje.Name = "lblEnviarMensaje";
            this.lblEnviarMensaje.Size = new System.Drawing.Size(147, 20);
            this.lblEnviarMensaje.TabIndex = 13;
            this.lblEnviarMensaje.Text = "Enviar Mensaje";
            // 
            // BotonAddClientePc
            // 
            this.BotonAddClientePc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BotonAddClientePc.FlatAppearance.BorderSize = 0;
            this.BotonAddClientePc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonAddClientePc.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonAddClientePc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BotonAddClientePc.Location = new System.Drawing.Point(3, 461);
            this.BotonAddClientePc.Name = "BotonAddClientePc";
            this.BotonAddClientePc.Size = new System.Drawing.Size(197, 56);
            this.BotonAddClientePc.TabIndex = 15;
            this.BotonAddClientePc.Text = "Vincular con cliente";
            this.BotonAddClientePc.UseVisualStyleBackColor = false;
            this.BotonAddClientePc.Click += new System.EventHandler(this.BotonAddClientePc_Click);
            // 
            // fpnlComputadoras
            // 
            this.fpnlComputadoras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.fpnlComputadoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlComputadoras.Location = new System.Drawing.Point(0, 0);
            this.fpnlComputadoras.Name = "fpnlComputadoras";
            this.fpnlComputadoras.Size = new System.Drawing.Size(604, 522);
            this.fpnlComputadoras.TabIndex = 13;
            // 
            // imglestadoscomputadora
            // 
            this.imglestadoscomputadora.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglestadoscomputadora.ImageStream")));
            this.imglestadoscomputadora.TransparentColor = System.Drawing.Color.Transparent;
            this.imglestadoscomputadora.Images.SetKeyName(0, "monitor.png");
            this.imglestadoscomputadora.Images.SetKeyName(1, "monitorOn.png");
            this.imglestadoscomputadora.Images.SetKeyName(2, "monitorOff.png");
            // 
            // Computadoras
            // 
            this.ClientSize = new System.Drawing.Size(807, 522);
            this.Controls.Add(this.fpnlComputadoras);
            this.Controls.Add(this.flwPanelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Computadoras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Computadoras_FormClosing);
            this.Load += new System.EventHandler(this.Computadoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutos)).EndInit();
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

        private System.Windows.Forms.Button btnCerrarApp;
        private System.Windows.Forms.Button btnAgregarTiempo;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.NumericUpDown numHoras;
        private System.Windows.Forms.NumericUpDown numMinutos;
        private System.Windows.Forms.TextBox txtboxMensajes;
        private System.Windows.Forms.FlowLayoutPanel flwPanelContenedor;
        private System.Windows.Forms.Panel pnlOpcionesText;
        private System.Windows.Forms.Label lblOpciones;
        private System.Windows.Forms.Panel pblContadores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEnviarMensaje;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.Label lblTiempoAdd;
        public System.Windows.Forms.Button BotonAddClientePc;
        private System.Windows.Forms.Label lblMinutosAdd;
        private System.Windows.Forms.Label lblHorasAdd;
        private System.Windows.Forms.FlowLayoutPanel fpnlComputadoras;
        private System.Windows.Forms.ImageList imglestadoscomputadora;
        private System.Windows.Forms.Label lblTiempoRestante;
    }
}