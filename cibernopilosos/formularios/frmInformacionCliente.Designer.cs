namespace cibernopilosos.formularios
{
    partial class frmInformacionCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformacionCliente));
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientBirthDate = new System.Windows.Forms.Label();
            this.txtClientPhone = new System.Windows.Forms.TextBox();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.lblClientAddress = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConfirmacion = new System.Windows.Forms.Button();
            this.dtClientBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(22, 89);
            this.txtClientID.MaxLength = 10;
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(362, 20);
            this.txtClientID.TabIndex = 7;
            this.txtClientID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientID_KeyPress);
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClientID.Location = new System.Drawing.Point(21, 62);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(86, 25);
            this.lblClientID.TabIndex = 6;
            this.lblClientID.Text = "Cédula";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(20, 149);
            this.txtClientName.MaxLength = 20;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(362, 20);
            this.txtClientName.TabIndex = 11;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClientName.Location = new System.Drawing.Point(19, 121);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(105, 25);
            this.lblClientName.TabIndex = 10;
            this.lblClientName.Text = "Nombres";
            // 
            // lblClientBirthDate
            // 
            this.lblClientBirthDate.AutoSize = true;
            this.lblClientBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientBirthDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClientBirthDate.Location = new System.Drawing.Point(19, 184);
            this.lblClientBirthDate.Name = "lblClientBirthDate";
            this.lblClientBirthDate.Size = new System.Drawing.Size(231, 25);
            this.lblClientBirthDate.TabIndex = 12;
            this.lblClientBirthDate.Text = "Fecha de nacimiento";
            // 
            // txtClientPhone
            // 
            this.txtClientPhone.Location = new System.Drawing.Point(20, 275);
            this.txtClientPhone.MaxLength = 10;
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.Size = new System.Drawing.Size(362, 20);
            this.txtClientPhone.TabIndex = 15;
            this.txtClientPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientPhone_KeyPress);
            // 
            // lblClientPhone
            // 
            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientPhone.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClientPhone.Location = new System.Drawing.Point(19, 247);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.Size = new System.Drawing.Size(216, 25);
            this.lblClientPhone.TabIndex = 14;
            this.lblClientPhone.Text = "Teléfono (opcional)";
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Location = new System.Drawing.Point(20, 335);
            this.txtClientAddress.MaxLength = 30;
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(362, 20);
            this.txtClientAddress.TabIndex = 17;
            // 
            // lblClientAddress
            // 
            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientAddress.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClientAddress.Location = new System.Drawing.Point(19, 307);
            this.lblClientAddress.Name = "lblClientAddress";
            this.lblClientAddress.Size = new System.Drawing.Size(223, 25);
            this.lblClientAddress.TabIndex = 16;
            this.lblClientAddress.Text = "Dirección (opcional)";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(200, 378);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(166, 26);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConfirmacion
            // 
            this.btnConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmacion.Location = new System.Drawing.Point(35, 378);
            this.btnConfirmacion.Name = "btnConfirmacion";
            this.btnConfirmacion.Size = new System.Drawing.Size(166, 26);
            this.btnConfirmacion.TabIndex = 18;
            this.btnConfirmacion.Text = "Agregar";
            this.btnConfirmacion.UseVisualStyleBackColor = true;
            this.btnConfirmacion.Click += new System.EventHandler(this.btnConfirmacion_Click);
            // 
            // dtClientBirthDate
            // 
            this.dtClientBirthDate.Location = new System.Drawing.Point(20, 214);
            this.dtClientBirthDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtClientBirthDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtClientBirthDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtClientBirthDate.Name = "dtClientBirthDate";
            this.dtClientBirthDate.Size = new System.Drawing.Size(182, 20);
            this.dtClientBirthDate.TabIndex = 20;
            this.dtClientBirthDate.Value = new System.DateTime(2001, 9, 11, 0, 0, 0, 0);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(58, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 39);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Información del usuario";
            // 
            // frmInformacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(403, 430);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dtClientBirthDate);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmacion);
            this.Controls.Add(this.txtClientAddress);
            this.Controls.Add(this.lblClientAddress);
            this.Controls.Add(this.txtClientPhone);
            this.Controls.Add(this.lblClientPhone);
            this.Controls.Add(this.lblClientBirthDate);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.lblClientID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(419, 469);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 469);
            this.Name = "frmInformacionCliente";
            this.Text = "frmInformacionCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblClientBirthDate;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.Label lblClientAddress;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtClientID;
        public System.Windows.Forms.TextBox txtClientName;
        public System.Windows.Forms.TextBox txtClientPhone;
        public System.Windows.Forms.TextBox txtClientAddress;
        public System.Windows.Forms.Button btnConfirmacion;
        public System.Windows.Forms.DateTimePicker dtClientBirthDate;
    }
}