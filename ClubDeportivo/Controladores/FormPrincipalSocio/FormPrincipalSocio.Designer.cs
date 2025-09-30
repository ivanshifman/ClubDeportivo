namespace ClubDeportivo.Controladores.FormPrincipalSocio
{
    partial class frmPrincipalSocio
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
            this.btnVerCuotas = new System.Windows.Forms.Button();
            this.btnCerrarSocio = new System.Windows.Forms.Button();
            this.btnPagarCuota = new System.Windows.Forms.Button();
            this.btnVerCarnet = new System.Windows.Forms.Button();
            this.lblTituloPrincipalSocio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVerCuotas
            // 
            this.btnVerCuotas.BackColor = System.Drawing.Color.PaleGreen;
            this.btnVerCuotas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerCuotas.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCuotas.Location = new System.Drawing.Point(157, 139);
            this.btnVerCuotas.Name = "btnVerCuotas";
            this.btnVerCuotas.Size = new System.Drawing.Size(189, 67);
            this.btnVerCuotas.TabIndex = 0;
            this.btnVerCuotas.Text = "Ver Cuotas";
            this.btnVerCuotas.UseVisualStyleBackColor = false;
            // 
            // btnCerrarSocio
            // 
            this.btnCerrarSocio.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCerrarSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSocio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarSocio.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSocio.Location = new System.Drawing.Point(517, 292);
            this.btnCerrarSocio.Name = "btnCerrarSocio";
            this.btnCerrarSocio.Size = new System.Drawing.Size(189, 67);
            this.btnCerrarSocio.TabIndex = 1;
            this.btnCerrarSocio.Text = "Cerrar Sesión";
            this.btnCerrarSocio.UseVisualStyleBackColor = false;
            this.btnCerrarSocio.Click += new System.EventHandler(this.btnCerrarSocio_Click);
            // 
            // btnPagarCuota
            // 
            this.btnPagarCuota.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnPagarCuota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagarCuota.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagarCuota.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagarCuota.Location = new System.Drawing.Point(517, 139);
            this.btnPagarCuota.Name = "btnPagarCuota";
            this.btnPagarCuota.Size = new System.Drawing.Size(189, 67);
            this.btnPagarCuota.TabIndex = 2;
            this.btnPagarCuota.Text = "Pagar Cuota";
            this.btnPagarCuota.UseVisualStyleBackColor = false;
            this.btnPagarCuota.Click += new System.EventHandler(this.btnPagarCuota_Click);
            // 
            // btnVerCarnet
            // 
            this.btnVerCarnet.BackColor = System.Drawing.Color.Aquamarine;
            this.btnVerCarnet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerCarnet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerCarnet.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCarnet.Location = new System.Drawing.Point(157, 292);
            this.btnVerCarnet.Name = "btnVerCarnet";
            this.btnVerCarnet.Size = new System.Drawing.Size(189, 67);
            this.btnVerCarnet.TabIndex = 3;
            this.btnVerCarnet.Text = "Ver Carnet";
            this.btnVerCarnet.UseVisualStyleBackColor = false;
            // 
            // lblTituloPrincipalSocio
            // 
            this.lblTituloPrincipalSocio.AutoSize = true;
            this.lblTituloPrincipalSocio.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipalSocio.Location = new System.Drawing.Point(209, 46);
            this.lblTituloPrincipalSocio.Name = "lblTituloPrincipalSocio";
            this.lblTituloPrincipalSocio.Size = new System.Drawing.Size(463, 44);
            this.lblTituloPrincipalSocio.TabIndex = 4;
            this.lblTituloPrincipalSocio.Text = "Pantalla Principal - Socio";
            // 
            // frmPrincipalSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.lblTituloPrincipalSocio);
            this.Controls.Add(this.btnVerCarnet);
            this.Controls.Add(this.btnPagarCuota);
            this.Controls.Add(this.btnCerrarSocio);
            this.Controls.Add(this.btnVerCuotas);
            this.Name = "frmPrincipalSocio";
            this.Text = "Club Deportivo - Pantalla principal Socio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerCuotas;
        private System.Windows.Forms.Button btnCerrarSocio;
        private System.Windows.Forms.Button btnPagarCuota;
        private System.Windows.Forms.Button btnVerCarnet;
        private System.Windows.Forms.Label lblTituloPrincipalSocio;
    }
}