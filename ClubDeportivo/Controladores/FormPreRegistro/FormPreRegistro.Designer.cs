namespace ClubDeportivo.Controladores.FormPreRegistro
{
    partial class frmPreRegistro
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
            this.btnPreRegistroSocio = new System.Windows.Forms.Button();
            this.btnPreRegistroNoSocio = new System.Windows.Forms.Button();
            this.lblTituloPreRegistro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPreRegistroSocio
            // 
            this.btnPreRegistroSocio.BackColor = System.Drawing.Color.PaleGreen;
            this.btnPreRegistroSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreRegistroSocio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreRegistroSocio.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreRegistroSocio.Location = new System.Drawing.Point(137, 212);
            this.btnPreRegistroSocio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreRegistroSocio.Name = "btnPreRegistroSocio";
            this.btnPreRegistroSocio.Size = new System.Drawing.Size(223, 86);
            this.btnPreRegistroSocio.TabIndex = 0;
            this.btnPreRegistroSocio.Text = "Registro Socio";
            this.btnPreRegistroSocio.UseVisualStyleBackColor = false;
            this.btnPreRegistroSocio.Click += new System.EventHandler(this.btnPreRegistroSocio_Click);
            // 
            // btnPreRegistroNoSocio
            // 
            this.btnPreRegistroNoSocio.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPreRegistroNoSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreRegistroNoSocio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreRegistroNoSocio.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreRegistroNoSocio.Location = new System.Drawing.Point(451, 212);
            this.btnPreRegistroNoSocio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreRegistroNoSocio.Name = "btnPreRegistroNoSocio";
            this.btnPreRegistroNoSocio.Size = new System.Drawing.Size(248, 86);
            this.btnPreRegistroNoSocio.TabIndex = 1;
            this.btnPreRegistroNoSocio.Text = "Registro No Socio";
            this.btnPreRegistroNoSocio.UseVisualStyleBackColor = false;
            this.btnPreRegistroNoSocio.Click += new System.EventHandler(this.btnPreRegistroNoSocio_Click);
            // 
            // lblTituloPreRegistro
            // 
            this.lblTituloPreRegistro.AutoSize = true;
            this.lblTituloPreRegistro.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPreRegistro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTituloPreRegistro.Location = new System.Drawing.Point(129, 90);
            this.lblTituloPreRegistro.Name = "lblTituloPreRegistro";
            this.lblTituloPreRegistro.Size = new System.Drawing.Size(505, 38);
            this.lblTituloPreRegistro.TabIndex = 2;
            this.lblTituloPreRegistro.Text = "Seleccionar método de registro";
            this.lblTituloPreRegistro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPreRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTituloPreRegistro);
            this.Controls.Add(this.btnPreRegistroNoSocio);
            this.Controls.Add(this.btnPreRegistroSocio);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPreRegistro";
            this.Text = "Club Deportivo - Seleccionar registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreRegistroSocio;
        private System.Windows.Forms.Button btnPreRegistroNoSocio;
        private System.Windows.Forms.Label lblTituloPreRegistro;
    }
}