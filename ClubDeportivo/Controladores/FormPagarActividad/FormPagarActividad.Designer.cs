namespace ClubDeportivo.Controladores.FormPagarActividad
{
    partial class frmPagarActividad
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
            this.lblTituloPagarActividad = new System.Windows.Forms.Label();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.lblActividad = new System.Windows.Forms.Label();
            this.grpPagoActividad = new System.Windows.Forms.GroupBox();
            this.txtMontoCuota = new System.Windows.Forms.TextBox();
            this.lblMontoActividad = new System.Windows.Forms.Label();
            this.cmbMetodoPagoActividad = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.btnPagarActividad = new System.Windows.Forms.Button();
            this.btnCancelarActividad = new System.Windows.Forms.Button();
            this.grpPagoActividad.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloPagarActividad
            // 
            this.lblTituloPagarActividad.AutoSize = true;
            this.lblTituloPagarActividad.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPagarActividad.Location = new System.Drawing.Point(26, 58);
            this.lblTituloPagarActividad.Name = "lblTituloPagarActividad";
            this.lblTituloPagarActividad.Size = new System.Drawing.Size(187, 27);
            this.lblTituloPagarActividad.TabIndex = 1;
            this.lblTituloPagarActividad.Text = "Pagar Actividad";
            // 
            // cmbActividad
            // 
            this.cmbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActividad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbActividad.Font = new System.Drawing.Font("Arial", 11F);
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Location = new System.Drawing.Point(213, 133);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(612, 29);
            this.cmbActividad.TabIndex = 11;
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblActividad.Location = new System.Drawing.Point(46, 141);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(99, 21);
            this.lblActividad.TabIndex = 12;
            this.lblActividad.Text = "Actividad:";
            // 
            // grpPagoActividad
            // 
            this.grpPagoActividad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpPagoActividad.Controls.Add(this.txtMontoCuota);
            this.grpPagoActividad.Controls.Add(this.lblMontoActividad);
            this.grpPagoActividad.Controls.Add(this.cmbMetodoPagoActividad);
            this.grpPagoActividad.Controls.Add(this.lblMetodoPago);
            this.grpPagoActividad.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPagoActividad.Location = new System.Drawing.Point(31, 199);
            this.grpPagoActividad.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.grpPagoActividad.Name = "grpPagoActividad";
            this.grpPagoActividad.Size = new System.Drawing.Size(794, 168);
            this.grpPagoActividad.TabIndex = 15;
            this.grpPagoActividad.TabStop = false;
            this.grpPagoActividad.Text = "Detalle del pago";
            // 
            // txtMontoCuota
            // 
            this.txtMontoCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoCuota.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoCuota.Location = new System.Drawing.Point(182, 39);
            this.txtMontoCuota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoCuota.MaxLength = 100;
            this.txtMontoCuota.Name = "txtMontoCuota";
            this.txtMontoCuota.ReadOnly = true;
            this.txtMontoCuota.Size = new System.Drawing.Size(209, 30);
            this.txtMontoCuota.TabIndex = 18;
            // 
            // lblMontoActividad
            // 
            this.lblMontoActividad.AutoSize = true;
            this.lblMontoActividad.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblMontoActividad.Location = new System.Drawing.Point(15, 48);
            this.lblMontoActividad.Name = "lblMontoActividad";
            this.lblMontoActividad.Size = new System.Drawing.Size(71, 21);
            this.lblMontoActividad.TabIndex = 17;
            this.lblMontoActividad.Text = "Monto:";
            // 
            // cmbMetodoPagoActividad
            // 
            this.cmbMetodoPagoActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPagoActividad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMetodoPagoActividad.Font = new System.Drawing.Font("Arial", 11F);
            this.cmbMetodoPagoActividad.FormattingEnabled = true;
            this.cmbMetodoPagoActividad.Items.AddRange(new object[] {
            "\"Efectivo\", \"Tarjeta\""});
            this.cmbMetodoPagoActividad.Location = new System.Drawing.Point(182, 86);
            this.cmbMetodoPagoActividad.Name = "cmbMetodoPagoActividad";
            this.cmbMetodoPagoActividad.Size = new System.Drawing.Size(209, 29);
            this.cmbMetodoPagoActividad.TabIndex = 16;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 89);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(146, 21);
            this.lblMetodoPago.TabIndex = 15;
            this.lblMetodoPago.Text = "Medio de Pago:";
            // 
            // btnPagarActividad
            // 
            this.btnPagarActividad.BackColor = System.Drawing.Color.Chartreuse;
            this.btnPagarActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagarActividad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagarActividad.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagarActividad.Location = new System.Drawing.Point(462, 390);
            this.btnPagarActividad.Margin = new System.Windows.Forms.Padding(4);
            this.btnPagarActividad.Name = "btnPagarActividad";
            this.btnPagarActividad.Size = new System.Drawing.Size(165, 47);
            this.btnPagarActividad.TabIndex = 16;
            this.btnPagarActividad.Text = "Pagar";
            this.btnPagarActividad.UseVisualStyleBackColor = false;
            this.btnPagarActividad.Click += new System.EventHandler(this.btnPagarActividad_Click);
            // 
            // btnCancelarActividad
            // 
            this.btnCancelarActividad.BackColor = System.Drawing.Color.Salmon;
            this.btnCancelarActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarActividad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarActividad.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarActividad.Location = new System.Drawing.Point(660, 390);
            this.btnCancelarActividad.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarActividad.Name = "btnCancelarActividad";
            this.btnCancelarActividad.Size = new System.Drawing.Size(165, 47);
            this.btnCancelarActividad.TabIndex = 17;
            this.btnCancelarActividad.Text = "Cancelar";
            this.btnCancelarActividad.UseVisualStyleBackColor = false;
            this.btnCancelarActividad.Click += new System.EventHandler(this.btnCancelarActividad_Click);
            // 
            // frmPagarActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.btnCancelarActividad);
            this.Controls.Add(this.btnPagarActividad);
            this.Controls.Add(this.grpPagoActividad);
            this.Controls.Add(this.lblActividad);
            this.Controls.Add(this.cmbActividad);
            this.Controls.Add(this.lblTituloPagarActividad);
            this.Name = "frmPagarActividad";
            this.Text = "Club Deportivo - Pagar Actividad";
            this.Load += new System.EventHandler(this.frmPagarActividad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPagarActividad_KeyDown);
            this.grpPagoActividad.ResumeLayout(false);
            this.grpPagoActividad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPagarActividad;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.GroupBox grpPagoActividad;
        private System.Windows.Forms.ComboBox cmbMetodoPagoActividad;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.TextBox txtMontoCuota;
        private System.Windows.Forms.Label lblMontoActividad;
        private System.Windows.Forms.Button btnPagarActividad;
        private System.Windows.Forms.Button btnCancelarActividad;
    }
}