using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormVerPerfilNoSocio
{
    public partial class frmVerPerfilNoSocio : Form
    {
        private readonly int idNoSocio;
        private NoSocio noSocioActual;
        private readonly NoSocioRepository noSocioRepo = new NoSocioRepository();

        public frmVerPerfilNoSocio(int idNoSocio)
        {
            InitializeComponent();
            this.idNoSocio = idNoSocio;
            dtpPerfilNoSocio.MaxDate = DateTime.Today;
            dtpPerfilNoSocio.MinDate = new DateTime(1900, 1, 1);
        }

        private void frmVerPerfilNoSocio_Load(object sender, EventArgs e)
        {
            CargarDatosNoSocio();
            BloquearCampos();
        }

        private void CargarDatosNoSocio()
        {
            noSocioActual = noSocioRepo.ObtenerNoSocioPorIdNoSocio(idNoSocio);

            if (noSocioActual != null)
            {
                txtNombrePerfilNoSocio.Text = noSocioActual.Nombre;
                txtApellidoPerfilNoSocio.Text = noSocioActual.Apellido;
                txtDniPerfilNoSocio.Text = noSocioActual.Dni;

                if (noSocioActual.FechaNacimiento < dtpPerfilNoSocio.MinDate)
                    dtpPerfilNoSocio.Value = dtpPerfilNoSocio.MinDate;
                else if (noSocioActual.FechaNacimiento > dtpPerfilNoSocio.MaxDate)
                    dtpPerfilNoSocio.Value = dtpPerfilNoSocio.MaxDate;
                else
                    dtpPerfilNoSocio.Value = noSocioActual.FechaNacimiento;

                txtUsuarioPerfilNoSocio.Text = noSocioActual.Usuario;
                txtClaveActualPerfilNoSocio.Text = string.Empty;
                txtClaveNuevaPerfilNoSocio.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("No se encontraron datos del no socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BloquearCampos()
        {
            txtNombrePerfilNoSocio.ReadOnly = true;
            txtApellidoPerfilNoSocio.ReadOnly = true;
            txtDniPerfilNoSocio.ReadOnly = true;
            txtUsuarioPerfilNoSocio.ReadOnly = true;
            dtpPerfilNoSocio.Enabled = false;
            txtClaveActualPerfilNoSocio.Visible = false;
            txtClaveNuevaPerfilNoSocio.Visible = false;

            btnGuardarPerfilNoSocio.Visible = false;
            btnCancelarPerfilNoSocio.Visible = true;
            btnEditarPerfilNoSocio.Visible = true;
        }

        private void DesbloquearCampos()
        {
            txtNombrePerfilNoSocio.ReadOnly = false;
            txtApellidoPerfilNoSocio.ReadOnly = false;
            dtpPerfilNoSocio.Enabled = true;
            txtClaveActualPerfilNoSocio.Visible = true;
            txtClaveNuevaPerfilNoSocio.Visible = true;

            btnGuardarPerfilNoSocio.Visible = true;
            btnCancelarPerfilNoSocio.Visible = true;
            btnEditarPerfilNoSocio.Visible = false;
        }

        private void btnEditarPerfilNoSocio_Click(object sender, EventArgs e)
        {
            DesbloquearCampos();
        }

        private void btnCancelarPerfilNoSocio_Click(object sender, EventArgs e)
        {
            if (btnGuardarPerfilNoSocio.Visible)
            {
                CargarDatosNoSocio();
                BloquearCampos();
            }
            else
            {
                this.Close();
                new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio(idNoSocio).Show();
            }
        }

        private void btnGuardarPerfilNoSocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtClaveActualPerfilNoSocio.Text) || !string.IsNullOrWhiteSpace(txtClaveNuevaPerfilNoSocio.Text))
                {
                    if (txtClaveActualPerfilNoSocio.Text != noSocioActual.Clave)
                    {
                        MessageBox.Show("La clave actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtClaveNuevaPerfilNoSocio.Text))
                    {
                        MessageBox.Show("Debe ingresar una nueva clave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    noSocioActual.Clave = txtClaveNuevaPerfilNoSocio.Text;
                }

                noSocioActual.Nombre = txtNombrePerfilNoSocio.Text;
                noSocioActual.Apellido = txtApellidoPerfilNoSocio.Text;
                noSocioActual.FechaNacimiento = dtpPerfilNoSocio.Value;

                noSocioRepo.ActualizarNoSocio(noSocioActual);

                MessageBox.Show("Perfil actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatosNoSocio();
                BloquearCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el perfil: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

