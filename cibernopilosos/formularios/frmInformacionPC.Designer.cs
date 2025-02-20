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
            this.lblPcNumber.Location = new System.Drawing.Point(43, 36);
            this.lblPcNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.lblPcInfo.Location = new System.Drawing.Point(41, 119);
            this.lblPcInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPcInfo.Name = "lblPcInfo";
            this.lblPcInfo.Size = new System.Drawing.Size(317, 25);
            this.lblPcInfo.TabIndex = 1;
            this.lblPcInfo.Text = "Información del pc (opcional)";
            // 
            // txtPcNumber
            // 
            this.txtPcNumber.Location = new System.Drawing.Point(45, 70);
            this.txtPcNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPcNumber.MaxLength = 3;
            this.txtPcNumber.Name = "txtPcNumber";
            this.txtPcNumber.Size = new System.Drawing.Size(440, 22);
            this.txtPcNumber.TabIndex = 5;
            // 
            // txtPcInfo
            // 
            this.txtPcInfo.Location = new System.Drawing.Point(45, 159);
            this.txtPcInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPcInfo.MaxLength = 100;
            this.txtPcInfo.Multiline = true;
            this.txtPcInfo.Name = "txtPcInfo";
            this.txtPcInfo.Size = new System.Drawing.Size(440, 71);
            this.txtPcInfo.TabIndex = 6;
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmacion.Location = new System.Drawing.Point(45, 247);
            this.btnConfirmacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(221, 32);
            this.btnConfirmacion.TabIndex = 10;
            this.btnConfirmacion.Text = "Agregar";
            this.btnConfirmacion.UseVisualStyleBackColor = true;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(264, 247);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(221, 32);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmInfoNuevaPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(153)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(537, 329);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.txtPcInfo);
            this.Controls.Add(this.txtPcNumber);
            this.Controls.Add(this.lblPcInfo);
            this.Controls.Add(this.lblPcNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(553, 368);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(553, 368);
            this.Name = "frmInfoNuevaPC";
            this.Text = "Administrar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPcNumber;
        private System.Windows.Forms.Label lblPcInfo;
        private System.Windows.Forms.TextBox txtPcNumber;
        private System.Windows.Forms.TextBox txtPcInfo;
        private System.Windows.Forms.Button btnConfirmacion;
        private System.Windows.Forms.Button btnSalir;
    }
}