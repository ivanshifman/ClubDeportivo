namespace ClubDeportivo.Controladores.FormPrincipalAdmin
{
    partial class frmPrincipalAdmin
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
            this.lblTituloPrincipalAdmin = new System.Windows.Forms.Label();
            this.btnListarCuotasVencidas = new System.Windows.Forms.Button();
            this.btnCerrarAdmin = new System.Windows.Forms.Button();
            this.btnVerUsuarios = new System.Windows.Forms.Button();
            this.btnAgregarActividad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloPrincipalAdmin
            // 
            this.lblTituloPrincipalAdmin.AutoSize = true;
            this.lblTituloPrincipalAdmin.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipalAdmin.Location = new System.Drawing.Point(137, 45);
            this.lblTituloPrincipalAdmin.Name = "lblTituloPrincipalAdmin";
            this.lblTituloPrincipalAdmin.Size = new System.Drawing.Size(614, 44);
            this.lblTituloPrincipalAdmin.TabIndex = 9;
            this.lblTituloPrincipalAdmin.Text = "Pantalla Principal - Administrador";
            // 
            // btnListarCuotasVencidas
            // 
            this.btnListarCuotasVencidas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnListarCuotasVencidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListarCuotasVencidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListarCuotasVencidas.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnListarCuotasVencidas.Location = new System.Drawing.Point(527, 140);
            this.btnListarCuotasVencidas.Name = "btnListarCuotasVencidas";
            this.btnListarCuotasVencidas.Size = new System.Drawing.Size(189, 67);
            this.btnListarCuotasVencidas.TabIndex = 7;
            this.btnListarCuotasVencidas.Text = "Listado de Cuotas vencidas";
            this.btnListarCuotasVencidas.UseVisualStyleBackColor = false;
            this.btnListarCuotasVencidas.Click += new System.EventHandler(this.btnListarCuotasVencidas_Click);
            // 
            // btnCerrarAdmin
            // 
            this.btnCerrarAdmin.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCerrarAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarAdmin.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarAdmin.Location = new System.Drawing.Point(527, 293);
            this.btnCerrarAdmin.Name = "btnCerrarAdmin";
            this.btnCerrarAdmin.Size = new System.Drawing.Size(189, 67);
            this.btnCerrarAdmin.TabIndex = 6;
            this.btnCerrarAdmin.Text = "Cerrar Sesión";
            this.btnCerrarAdmin.UseVisualStyleBackColor = false;
            this.btnCerrarAdmin.Click += new System.EventHandler(this.btnCerrarAdmin_Click);
            // 
            // btnVerUsuarios
            // 
            this.btnVerUsuarios.BackColor = System.Drawing.Color.PaleGreen;
            this.btnVerUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerUsuarios.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerUsuarios.Location = new System.Drawing.Point(167, 140);
            this.btnVerUsuarios.Name = "btnVerUsuarios";
            this.btnVerUsuarios.Size = new System.Drawing.Size(189, 67);
            this.btnVerUsuarios.TabIndex = 5;
            this.btnVerUsuarios.Text = "Ver Usuarios";
            this.btnVerUsuarios.UseVisualStyleBackColor = false;
            this.btnVerUsuarios.Click += new System.EventHandler(this.btnVerUsuarios_Click);
            // 
            // btnAgregarActividad
            // 
            this.btnAgregarActividad.BackColor = System.Drawing.Color.Aquamarine;
            this.btnAgregarActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarActividad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarActividad.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarActividad.Location = new System.Drawing.Point(167, 293);
            this.btnAgregarActividad.Name = "btnAgregarActividad";
            this.btnAgregarActividad.Size = new System.Drawing.Size(189, 67);
            this.btnAgregarActividad.TabIndex = 10;
            this.btnAgregarActividad.Text = "Agregar Actividad";
            this.btnAgregarActividad.UseVisualStyleBackColor = false;
            this.btnAgregarActividad.Click += new System.EventHandler(this.btnAgregarActividad_Click);
            // 
            // frmPrincipalAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.btnAgregarActividad);
            this.Controls.Add(this.lblTituloPrincipalAdmin);
            this.Controls.Add(this.btnListarCuotasVencidas);
            this.Controls.Add(this.btnCerrarAdmin);
            this.Controls.Add(this.btnVerUsuarios);
            this.Name = "frmPrincipalAdmin";
            this.Text = "Club Deportivo - Pantalla principal Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPrincipalAdmin;
        private System.Windows.Forms.Button btnListarCuotasVencidas;
        private System.Windows.Forms.Button btnCerrarAdmin;
        private System.Windows.Forms.Button btnVerUsuarios;
        private System.Windows.Forms.Button btnAgregarActividad;
    }
}