namespace cibernopilosos.formularios
{
    partial class frmInformacionPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformacionPC));
            this.lblPcNumber = new System.Windows.Forms.Label();
            this.lblPcInfo = new System.Windows.Forms.Label();
            this.txtPcNumber = new System.Windows.Forms.TextBox();
            this.txtPcInfo = new System.Windows.Forms.TextBox();
            this.btnConfirmacion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtPcIP = new System.Windows.Forms.TextBox();
            this.lblPCIP = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPcNumber
            // 
            this.lblPcNumber.AutoSize = true;
            this.lblPcNumber.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPcNumber.Location = new System.Drawing.Point(32, 35);
            this.lblPcNumber.Name = "lblPcNumber";
            this.lblPcNumber.Size = new System.Drawing.Size(220, 20);
            this.lblPcNumber.TabIndex = 0;
            this.lblPcNumber.Text = "Número de computador";
            // 
            // lblPcInfo
            // 
            this.lblPcInfo.AutoSize = true;
            this.lblPcInfo.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPcInfo.Location = new System.Drawing.Point(32, 159);
            this.lblPcInfo.Name = "lblPcInfo";
            this.lblPcInfo.Size = new System.Drawing.Size(179, 20);
            this.lblPcInfo.TabIndex = 1;
            this.lblPcInfo.Text = "Información del pc";
            // 
            // txtPcNumber
            // 
            this.txtPcNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPcNumber.Location = new System.Drawing.Point(34, 57);
            this.txtPcNumber.MaxLength = 3;
            this.txtPcNumber.Name = "txtPcNumber";
            this.txtPcNumber.Size = new System.Drawing.Size(331, 20);
            this.txtPcNumber.TabIndex = 5;
            this.txtPcNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPcNumber_KeyPress);
            // 
            // txtPcInfo
            // 
            this.txtPcInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPcInfo.Location = new System.Drawing.Point(35, 185);
            this.txtPcInfo.MaxLength = 100;
            this.txtPcInfo.Multiline = true;
            this.txtPcInfo.Name = "txtPcInfo";
            this.txtPcInfo.Size = new System.Drawing.Size(331, 58);
            this.txtPcInfo.TabIndex = 6;
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConfirmacion.Enabled = false;
            this.btnConfirmacion.FlatAppearance.BorderSize = 0;
            this.btnConfirmacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmacion.Location = new System.Drawing.Point(35, 300);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(166, 26);
            this.btnConfirmacion.TabIndex = 10;
            this.btnConfirmacion.Text = "Agregar";
            this.btnConfirmacion.UseVisualStyleBackColor = false;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(199, 300);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(166, 26);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtPcIP
            // 
            this.txtPcIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPcIP.Location = new System.Drawing.Point(34, 119);
            this.txtPcIP.MaxLength = 15;
            this.txtPcIP.Name = "txtPcIP";
            this.txtPcIP.Size = new System.Drawing.Size(331, 20);
            this.txtPcIP.TabIndex = 13;
            // 
            // lblPCIP
            // 
            this.lblPCIP.AutoSize = true;
            this.lblPCIP.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCIP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPCIP.Location = new System.Drawing.Point(32, 97);
            this.lblPCIP.Name = "lblPCIP";
            this.lblPCIP.Size = new System.Drawing.Size(269, 20);
            this.lblPCIP.TabIndex = 12;
            this.lblPCIP.Text = "Dirección IP del Computador";
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnValidar.FlatAppearance.BorderSize = 0;
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(34, 259);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(332, 35);
            this.btnValidar.TabIndex = 14;
            this.btnValidar.Text = "Probar";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // frmInformacionPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(60)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(403, 354);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.txtPcIP);
            this.Controls.Add(this.lblPCIP);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.txtPcInfo);
            this.Controls.Add(this.txtPcNumber);
            this.Controls.Add(this.lblPcInfo);
            this.Controls.Add(this.lblPcNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(419, 393);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 393);
            this.Name = "frmInformacionPC";
            this.Text = "Administrar";
            this.Load += new System.EventHandler(this.frmInformacionPC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPcNumber;
        private System.Windows.Forms.Label lblPcInfo;
        public System.Windows.Forms.Button btnConfirmacion;
        public System.Windows.Forms.TextBox txtPcNumber;
        public System.Windows.Forms.TextBox txtPcInfo;
        public System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.TextBox txtPcIP;
        private System.Windows.Forms.Label lblPCIP;
        public System.Windows.Forms.Button btnValidar;
    }
}