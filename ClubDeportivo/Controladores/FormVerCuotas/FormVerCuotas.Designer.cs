namespace ClubDeportivo.Controladores.FormVerCuotas
{
    partial class frmVerCuotas
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
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedioPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolverCuota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloVerCuotas
            // 
            this.lblTituloVerCuotas.AutoSize = true;
            this.lblTituloVerCuotas.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVerCuotas.Location = new System.Drawing.Point(21, 46);
            this.lblTituloVerCuotas.Name = "lblTituloVerCuotas";
            this.lblTituloVerCuotas.Size = new System.Drawing.Size(262, 27);
            this.lblTituloVerCuotas.TabIndex = 0;
            this.lblTituloVerCuotas.Text = "Ver mis Cuotas - Socio";
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.AllowUserToOrderColumns = true;
            this.dgvCuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaPago,
            this.FechaVencimiento,
            this.Monto,
            this.MedioPago,
            this.Promocion});
            this.dgvCuotas.Location = new System.Drawing.Point(26, 131);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.ReadOnly = true;
            this.dgvCuotas.RowHeadersWidth = 51;
            this.dgvCuotas.RowTemplate.Height = 24;
            this.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotas.Size = new System.Drawing.Size(802, 292);
            this.dgvCuotas.TabIndex = 1;
            // 
            // FechaPago
            // 
            this.FechaPago.HeaderText = "Fecha de Pago";
            this.FechaPago.MinimumWidth = 6;
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "Fecha de Vencimiento";
            this.FechaVencimiento.MinimumWidth = 6;
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 6;
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // MedioPago
            // 
            this.MedioPago.HeaderText = "Medio de Pago";
            this.MedioPago.MinimumWidth = 6;
            this.MedioPago.Name = "MedioPago";
            this.MedioPago.ReadOnly = true;
            // 
            // Promocion
            // 
            this.Promocion.HeaderText = "Promoción";
            this.Promocion.MinimumWidth = 6;
            this.Promocion.Name = "Promocion";
            this.Promocion.ReadOnly = true;
            // 
            // btnVolverCuota
            // 
            this.btnVolverCuota.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnVolverCuota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolverCuota.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolverCuota.FlatAppearance.BorderSize = 3;
            this.btnVolverCuota.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVolverCuota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVolverCuota.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolverCuota.Font = new System.Drawing.Font("Arial Narrow", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnVolverCuota.Location = new System.Drawing.Point(698, 39);
            this.btnVolverCuota.Name = "btnVolverCuota";
            this.btnVolverCuota.Size = new System.Drawing.Size(130, 44);
            this.btnVolverCuota.TabIndex = 20;
            this.btnVolverCuota.Text = "Volver";
            this.btnVolverCuota.UseVisualStyleBackColor = false;
            // 
            // frmVerCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.btnVolverCuota);
            this.Controls.Add(this.dgvCuotas);
            this.Controls.Add(this.lblTituloVerCuotas);
            this.Name = "frmVerCuotas";
            this.Text = "Club Deportivo - Ver Cuotas Socio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloVerCuotas;
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedioPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocion;
        private System.Windows.Forms.Button btnVolverCuota;
    }
}