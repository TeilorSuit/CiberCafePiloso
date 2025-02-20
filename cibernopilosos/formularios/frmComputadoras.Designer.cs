namespace cibernopilosos.formularios
{
    partial class frmComputadoras
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComputadoras));
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.imgListaPC = new System.Windows.Forms.ImageList(this.components);
            this.TimerSecundero = new System.Windows.Forms.Timer(this.components);
            this.pnlBotonesContenedor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBorrarPC = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlBotonesContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.AutoScroll = true;
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1097, 690);
            this.pnlContenedor.TabIndex = 1;
            // 
            // imgListaPC
            // 
            this.imgListaPC.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListaPC.ImageStream")));
            this.imgListaPC.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListaPC.Images.SetKeyName(0, "monitorMini.png");
            // 
            // TimerSecundero
            // 
            this.TimerSecundero.Interval = 1000;
            this.TimerSecundero.Tick += new System.EventHandler(this.TimerSecundero_Tick);
            // 
            // pnlBotonesContenedor
            // 
            this.pnlBotonesContenedor.Controls.Add(this.button1);
            this.pnlBotonesContenedor.Controls.Add(this.button4);
            this.pnlBotonesContenedor.Controls.Add(this.button3);
            this.pnlBotonesContenedor.Controls.Add(this.btnBorrarPC);
            this.pnlBotonesContenedor.Controls.Add(this.button2);
            this.pnlBotonesContenedor.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotonesContenedor.Location = new System.Drawing.Point(838, 0);
            this.pnlBotonesContenedor.Name = "pnlBotonesContenedor";
            this.pnlBotonesContenedor.Size = new System.Drawing.Size(259, 690);
            this.pnlBotonesContenedor.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(9, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 50);
            this.button1.TabIndex = 18;
            this.button1.Text = "Terminar turno";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(9, 62);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(243, 50);
            this.button4.TabIndex = 17;
            this.button4.Text = "Bloquear";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(9, 120);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(243, 50);
            this.button3.TabIndex = 16;
            this.button3.Text = "Establecer Estado";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnBorrarPC
            // 
            this.btnBorrarPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.btnBorrarPC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBorrarPC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBorrarPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarPC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrarPC.Location = new System.Drawing.Point(9, 578);
            this.btnBorrarPC.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrarPC.Name = "btnBorrarPC";
            this.btnBorrarPC.Size = new System.Drawing.Size(243, 50);
            this.btnBorrarPC.TabIndex = 14;
            this.btnBorrarPC.Text = "Agregar Tiempo";
            this.btnBorrarPC.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(77)))), ((int)(((byte)(90)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(9, 636);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 50);
            this.button2.TabIndex = 15;
            this.button2.Text = "Pausar Tiempo";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // frmComputadoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1097, 690);
            this.Controls.Add(this.pnlBotonesContenedor);
            this.Controls.Add(this.pnlContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmComputadoras";
            this.Text = "frmComputadoras";
            this.pnlBotonesContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.ImageList imgListaPC;
        private System.Windows.Forms.Timer TimerSecundero;
        private System.Windows.Forms.Panel pnlBotonesContenedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnBorrarPC;
        private System.Windows.Forms.Button button2;
    }
}