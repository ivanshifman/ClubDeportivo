namespace ClubDeportivo.Controladores.FormListadoCuotasVencidas
{
    partial class frmListadoCuotasVencidas
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
            this.lblTituloVerCuotas = new System.Windows.Forms.Label();
            this.dgvCuotasVencidas = new System.Windows.Forms.DataGridView();
            this.btnVolverListadoCuotasVencidas = new System.Windows.Forms.Button();
            this.Promocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedioPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotasVencidas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloVerCuotas
            // 
            this.lblTituloVerCuotas.AutoSize = true;
            this.lblTituloVerCuotas.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVerCuotas.Location = new System.Drawing.Point(24, 49);
            this.lblTituloVerCuotas.Name = "lblTituloVerCuotas";
            this.lblTituloVerCuotas.Size = new System.Drawing.Size(413, 27);
            this.lblTituloVerCuotas.TabIndex = 1;
            this.lblTituloVerCuotas.Text = "Ver Listado Cuotas vencidas - Socio";
            // 
            // dgvCuotasVencidas
            // 
            this.dgvCuotasVencidas.AllowUserToAddRows = false;
            this.dgvCuotasVencidas.AllowUserToDeleteRows = false;
            this.dgvCuotasVencidas.AllowUserToOrderColumns = true;
            this.dgvCuotasVencidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuotasVencidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotasVencidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.FechaPago,
            this.FechaVencimiento,
            this.Monto,
            this.MedioPago,
            this.Promocion});
            this.dgvCuotasVencidas.Location = new System.Drawing.Point(29, 150);
            this.dgvCuotasVencidas.Name = "dgvCuotasVencidas";
            this.dgvCuotasVencidas.ReadOnly = true;
            this.dgvCuotasVencidas.RowHeadersWidth = 51;
            this.dgvCuotasVencidas.RowTemplate.Height = 24;
            this.dgvCuotasVencidas.Size = new System.Drawing.Size(796, 270);
            this.dgvCuotasVencidas.TabIndex = 2;
            // 
            // btnVolverListadoCuotasVencidas
            // 
            this.btnVolverListadoCuotasVencidas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnVolverListadoCuotasVencidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolverListadoCuotasVencidas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolverListadoCuotasVencidas.FlatAppearance.BorderSize = 3;
            this.btnVolverListadoCuotasVencidas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVolverListadoCuotasVencidas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVolverListadoCuotasVencidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolverListadoCuotasVencidas.Font = new System.Drawing.Font("Arial Narrow", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnVolverListadoCuotasVencidas.Location = new System.Drawing.Point(695, 42);
            this.btnVolverListadoCuotasVencidas.Name = "btnVolverListadoCuotasVencidas";
            this.btnVolverListadoCuotasVencidas.Size = new System.Drawing.Size(130, 44);
            this.btnVolverListadoCuotasVencidas.TabIndex = 21;
            this.btnVolverListadoCuotasVencidas.Text = "Volver";
            this.btnVolverListadoCuotasVencidas.UseVisualStyleBackColor = false;
            this.btnVolverListadoCuotasVencidas.Click += new System.EventHandler(this.btnVolverListadoCuotasVencidas_Click);
            // 
            // Promocion
            // 
            this.Promocion.HeaderText = "En Cuotas";
            this.Promocion.MinimumWidth = 6;
            this.Promocion.Name = "Promocion";
            this.Promocion.ReadOnly = true;
            // 
            // MedioPago
            // 
            this.MedioPago.HeaderText = "Medio de pago";
            this.MedioPago.MinimumWidth = 6;
            this.MedioPago.Name = "MedioPago";
            this.MedioPago.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 6;
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "Fecha de vencimiento";
            this.FechaVencimiento.MinimumWidth = 6;
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            // 
            // FechaPago
            // 
            this.FechaPago.HeaderText = "Fecha de pago";
            this.FechaPago.MinimumWidth = 6;
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.MaxInputLength = 8;
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // frmListadoCuotasVencidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.btnVolverListadoCuotasVencidas);
            this.Controls.Add(this.dgvCuotasVencidas);
            this.Controls.Add(this.lblTituloVerCuotas);
            this.Name = "frmListadoCuotasVencidas";
            this.Text = "Club Deportivo - Listado Cuotas vencidas (Administrador)";
            this.Load += new System.EventHandler(this.frmListadoCuotasVencidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotasVencidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloVerCuotas;
        private System.Windows.Forms.DataGridView dgvCuotasVencidas;
        private System.Windows.Forms.Button btnVolverListadoCuotasVencidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedioPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocion;
    }
}