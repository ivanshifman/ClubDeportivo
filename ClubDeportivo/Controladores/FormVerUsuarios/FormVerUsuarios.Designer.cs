namespace ClubDeportivo.Controladores.FormVerUsuarios
{
    partial class frmVerUsuarios
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
            this.lblTituloVerSocios = new System.Windows.Forms.Label();
            this.lblTituloVerNoSocios = new System.Windows.Forms.Label();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.NombreSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNISocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimientoSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FichaMedicaSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAltaSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNoSocios = new System.Windows.Forms.DataGridView();
            this.NombreNoSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoNoSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimientoNoSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioNoSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolverUsuarios = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloVerSocios
            // 
            this.lblTituloVerSocios.AutoSize = true;
            this.lblTituloVerSocios.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVerSocios.Location = new System.Drawing.Point(29, 52);
            this.lblTituloVerSocios.Name = "lblTituloVerSocios";
            this.lblTituloVerSocios.Size = new System.Drawing.Size(130, 27);
            this.lblTituloVerSocios.TabIndex = 1;
            this.lblTituloVerSocios.Text = "Ver Socios";
            // 
            // lblTituloVerNoSocios
            // 
            this.lblTituloVerNoSocios.AutoSize = true;
            this.lblTituloVerNoSocios.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVerNoSocios.Location = new System.Drawing.Point(29, 299);
            this.lblTituloVerNoSocios.Name = "lblTituloVerNoSocios";
            this.lblTituloVerNoSocios.Size = new System.Drawing.Size(167, 27);
            this.lblTituloVerNoSocios.TabIndex = 2;
            this.lblTituloVerNoSocios.Text = "Ver No Socios";
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.AllowUserToOrderColumns = true;
            this.dgvSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreSocio,
            this.ApellidoSocio,
            this.DNISocio,
            this.FechaNacimientoSocio,
            this.FichaMedicaSocio,
            this.FechaAltaSocio,
            this.UsuarioSocio});
            this.dgvSocios.Location = new System.Drawing.Point(59, 106);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.ReadOnly = true;
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.RowTemplate.Height = 24;
            this.dgvSocios.Size = new System.Drawing.Size(774, 167);
            this.dgvSocios.TabIndex = 3;
            // 
            // NombreSocio
            // 
            this.NombreSocio.HeaderText = "Nombre";
            this.NombreSocio.MinimumWidth = 6;
            this.NombreSocio.Name = "NombreSocio";
            this.NombreSocio.ReadOnly = true;
            // 
            // ApellidoSocio
            // 
            this.ApellidoSocio.HeaderText = "Apellido";
            this.ApellidoSocio.MinimumWidth = 6;
            this.ApellidoSocio.Name = "ApellidoSocio";
            this.ApellidoSocio.ReadOnly = true;
            // 
            // DNISocio
            // 
            this.DNISocio.HeaderText = "DNI";
            this.DNISocio.MinimumWidth = 6;
            this.DNISocio.Name = "DNISocio";
            this.DNISocio.ReadOnly = true;
            // 
            // FechaNacimientoSocio
            // 
            this.FechaNacimientoSocio.HeaderText = "Fecha de nacimiento";
            this.FechaNacimientoSocio.MinimumWidth = 6;
            this.FechaNacimientoSocio.Name = "FechaNacimientoSocio";
            this.FechaNacimientoSocio.ReadOnly = true;
            // 
            // FichaMedicaSocio
            // 
            this.FichaMedicaSocio.HeaderText = "Ficha médica";
            this.FichaMedicaSocio.MinimumWidth = 6;
            this.FichaMedicaSocio.Name = "FichaMedicaSocio";
            this.FichaMedicaSocio.ReadOnly = true;
            // 
            // FechaAltaSocio
            // 
            this.FechaAltaSocio.HeaderText = "Fecha de alta";
            this.FechaAltaSocio.MinimumWidth = 6;
            this.FechaAltaSocio.Name = "FechaAltaSocio";
            this.FechaAltaSocio.ReadOnly = true;
            // 
            // UsuarioSocio
            // 
            this.UsuarioSocio.HeaderText = "Usuario";
            this.UsuarioSocio.MinimumWidth = 6;
            this.UsuarioSocio.Name = "UsuarioSocio";
            this.UsuarioSocio.ReadOnly = true;
            // 
            // dgvNoSocios
            // 
            this.dgvNoSocios.AllowUserToAddRows = false;
            this.dgvNoSocios.AllowUserToDeleteRows = false;
            this.dgvNoSocios.AllowUserToOrderColumns = true;
            this.dgvNoSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNoSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreNoSocio,
            this.ApellidoNoSocio,
            this.FechaNacimientoNoSocio,
            this.UsuarioNoSocio});
            this.dgvNoSocios.Location = new System.Drawing.Point(59, 351);
            this.dgvNoSocios.Name = "dgvNoSocios";
            this.dgvNoSocios.ReadOnly = true;
            this.dgvNoSocios.RowHeadersWidth = 51;
            this.dgvNoSocios.RowTemplate.Height = 24;
            this.dgvNoSocios.Size = new System.Drawing.Size(774, 160);
            this.dgvNoSocios.TabIndex = 4;
            // 
            // NombreNoSocio
            // 
            this.NombreNoSocio.HeaderText = "Nombre";
            this.NombreNoSocio.MinimumWidth = 6;
            this.NombreNoSocio.Name = "NombreNoSocio";
            this.NombreNoSocio.ReadOnly = true;
            // 
            // ApellidoNoSocio
            // 
            this.ApellidoNoSocio.HeaderText = "Apellido";
            this.ApellidoNoSocio.MinimumWidth = 6;
            this.ApellidoNoSocio.Name = "ApellidoNoSocio";
            this.ApellidoNoSocio.ReadOnly = true;
            // 
            // FechaNacimientoNoSocio
            // 
            this.FechaNacimientoNoSocio.HeaderText = "Fecha de nacimiento";
            this.FechaNacimientoNoSocio.MinimumWidth = 6;
            this.FechaNacimientoNoSocio.Name = "FechaNacimientoNoSocio";
            this.FechaNacimientoNoSocio.ReadOnly = true;
            // 
            // UsuarioNoSocio
            // 
            this.UsuarioNoSocio.HeaderText = "Usuario";
            this.UsuarioNoSocio.MinimumWidth = 6;
            this.UsuarioNoSocio.Name = "UsuarioNoSocio";
            this.UsuarioNoSocio.ReadOnly = true;
            // 
            // btnVolverUsuarios
            // 
            this.btnVolverUsuarios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnVolverUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolverUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolverUsuarios.FlatAppearance.BorderSize = 3;
            this.btnVolverUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVolverUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVolverUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolverUsuarios.Font = new System.Drawing.Font("Arial Narrow", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnVolverUsuarios.Location = new System.Drawing.Point(703, 35);
            this.btnVolverUsuarios.Name = "btnVolverUsuarios";
            this.btnVolverUsuarios.Size = new System.Drawing.Size(130, 44);
            this.btnVolverUsuarios.TabIndex = 21;
            this.btnVolverUsuarios.Text = "Volver";
            this.btnVolverUsuarios.UseVisualStyleBackColor = false;
            this.btnVolverUsuarios.Click += new System.EventHandler(this.btnVolverUsuarios_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarUsuario.FlatAppearance.BorderSize = 3;
            this.btnEliminarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEliminarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Arial Narrow", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnEliminarUsuario.Location = new System.Drawing.Point(546, 35);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(130, 44);
            this.btnEliminarUsuario.TabIndex = 22;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // frmVerUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 532);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnVolverUsuarios);
            this.Controls.Add(this.dgvNoSocios);
            this.Controls.Add(this.dgvSocios);
            this.Controls.Add(this.lblTituloVerNoSocios);
            this.Controls.Add(this.lblTituloVerSocios);
            this.Name = "frmVerUsuarios";
            this.Text = "Club Deportivo - Ver Usuarios (Administrador)";
            this.Load += new System.EventHandler(this.frmVerUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloVerSocios;
        private System.Windows.Forms.Label lblTituloVerNoSocios;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.DataGridView dgvNoSocios;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNISocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimientoSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FichaMedicaSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAltaSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreNoSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoNoSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimientoNoSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioNoSocio;
        private System.Windows.Forms.Button btnVolverUsuarios;
        private System.Windows.Forms.Button btnEliminarUsuario;
    }
}