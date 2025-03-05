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
            this.SuspendLayout();
            // 
            // lblPcNumber
            // 
            this.lblPcNumber.AutoSize = true;
            this.lblPcNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPcNumber.Location = new System.Drawing.Point(32, 29);
            this.lblPcNumber.Name = "lblPcNumber";
            this.lblPcNumber.Size = new System.Drawing.Size(256, 25);
            this.lblPcNumber.TabIndex = 0;
            this.lblPcNumber.Text = "Número de computador";
            // 
            // lblPcInfo
            // 
            this.lblPcInfo.AutoSize = true;
            this.lblPcInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPcInfo.Location = new System.Drawing.Point(31, 97);
            this.lblPcInfo.Name = "lblPcInfo";
            this.lblPcInfo.Size = new System.Drawing.Size(317, 25);
            this.lblPcInfo.TabIndex = 1;
            this.lblPcInfo.Text = "Información del pc (opcional)";
            // 
            // txtPcNumber
            // 
            this.txtPcNumber.Location = new System.Drawing.Point(34, 57);
            this.txtPcNumber.MaxLength = 3;
            this.txtPcNumber.Name = "txtPcNumber";
            this.txtPcNumber.Size = new System.Drawing.Size(331, 20);
            this.txtPcNumber.TabIndex = 5;
            this.txtPcNumber.TextChanged += new System.EventHandler(this.txtPcNumber_TextChanged);
            // 
            // txtPcInfo
            // 
            this.txtPcInfo.Location = new System.Drawing.Point(34, 129);
            this.txtPcInfo.MaxLength = 100;
            this.txtPcInfo.Multiline = true;
            this.txtPcInfo.Name = "txtPcInfo";
            this.txtPcInfo.Size = new System.Drawing.Size(331, 58);
            this.txtPcInfo.TabIndex = 6;
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmacion.Location = new System.Drawing.Point(34, 201);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(166, 26);
            this.btnConfirmacion.TabIndex = 10;
            this.btnConfirmacion.Text = "Agregar";
            this.btnConfirmacion.UseVisualStyleBackColor = true;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(198, 201);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(166, 26);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmInformacionPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(153)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(403, 267);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.txtPcInfo);
            this.Controls.Add(this.txtPcNumber);
            this.Controls.Add(this.lblPcInfo);
            this.Controls.Add(this.lblPcNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(419, 306);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 306);
            this.Name = "frmInformacionPC";
            this.Text = "Administrar";
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
    }
}