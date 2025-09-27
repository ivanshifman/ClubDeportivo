namespace ClubDeportivo.Controladores.FormPrincipalNoSocio
{
    partial class frmPrincipalNoSocio
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
            this.lblTituloPrincipalNoSocio = new System.Windows.Forms.Label();
            this.btnPagarActividad = new System.Windows.Forms.Button();
            this.btnCerrarNoSocio = new System.Windows.Forms.Button();
            this.btnVerActividadesDisponibles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloPrincipalNoSocio
            // 
            this.lblTituloPrincipalNoSocio.AutoSize = true;
            this.lblTituloPrincipalNoSocio.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipalNoSocio.Location = new System.Drawing.Point(173, 44);
            this.lblTituloPrincipalNoSocio.Name = "lblTituloPrincipalNoSocio";
            this.lblTituloPrincipalNoSocio.Size = new System.Drawing.Size(523, 44);
            this.lblTituloPrincipalNoSocio.TabIndex = 9;
            this.lblTituloPrincipalNoSocio.Text = "Pantalla Principal - No Socio";
            // 
            // btnPagarActividad
            // 
            this.btnPagarActividad.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnPagarActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagarActividad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagarActividad.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagarActividad.Location = new System.Drawing.Point(516, 138);
            this.btnPagarActividad.Name = "btnPagarActividad";
            this.btnPagarActividad.Size = new System.Drawing.Size(189, 67);
            this.btnPagarActividad.TabIndex = 7;
            this.btnPagarActividad.Text = "Pagar Actividad";
            this.btnPagarActividad.UseVisualStyleBackColor = false;
            // 
            // btnCerrarNoSocio
            // 
            this.btnCerrarNoSocio.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCerrarNoSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarNoSocio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarNoSocio.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarNoSocio.Location = new System.Drawing.Point(516, 291);
            this.btnCerrarNoSocio.Name = "btnCerrarNoSocio";
            this.btnCerrarNoSocio.Size = new System.Drawing.Size(189, 67);
            this.btnCerrarNoSocio.TabIndex = 6;
            this.btnCerrarNoSocio.Text = "Cerrar Sesión";
            this.btnCerrarNoSocio.UseVisualStyleBackColor = false;
            // 
            // btnVerActividadesDisponibles
            // 
            this.btnVerActividadesDisponibles.BackColor = System.Drawing.Color.PaleGreen;
            this.btnVerActividadesDisponibles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerActividadesDisponibles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerActividadesDisponibles.Font = new System.Drawing.Font("Arial", 12.8F, System.Drawing.FontStyle.Bold);
            this.btnVerActividadesDisponibles.Location = new System.Drawing.Point(156, 138);
            this.btnVerActividadesDisponibles.Name = "btnVerActividadesDisponibles";
            this.btnVerActividadesDisponibles.Size = new System.Drawing.Size(189, 67);
            this.btnVerActividadesDisponibles.TabIndex = 5;
            this.btnVerActividadesDisponibles.Text = "Ver Actividades disponibles";
            this.btnVerActividadesDisponibles.UseVisualStyleBackColor = false;
            // 
            // frmPrincipalNoSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.lblTituloPrincipalNoSocio);
            this.Controls.Add(this.btnPagarActividad);
            this.Controls.Add(this.btnCerrarNoSocio);
            this.Controls.Add(this.btnVerActividadesDisponibles);
            this.Name = "frmPrincipalNoSocio";
            this.Text = "Club Deportivo - Pantalla principal No Socio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPrincipalNoSocio;
        private System.Windows.Forms.Button btnPagarActividad;
        private System.Windows.Forms.Button btnCerrarNoSocio;
        private System.Windows.Forms.Button btnVerActividadesDisponibles;
    }
}