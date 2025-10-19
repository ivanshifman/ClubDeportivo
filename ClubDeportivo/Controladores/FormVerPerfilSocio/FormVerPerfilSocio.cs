using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormVerPerfilSocio
{
    public partial class frmVerPerfilSocio : Form
    {
        private readonly int idSocio;
        private Socio socioActual;
        private readonly SocioRepository socioRepo = new SocioRepository();

        public frmVerPerfilSocio(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
            dtpPerfilSocio.MaxDate = DateTime.Today;
            dtpPerfilSocio.MinDate = new DateTime(1900, 1, 1);
        }

        private void frmVerPerfilSocio_Load(object sender, EventArgs e)
        {
            CargarDatosSocio();
            BloquearCampos();
        }

        private void CargarDatosSocio()
        {
            socioActual = socioRepo.ObtenerSocioPorIdSocio(idSocio);

            if (socioActual != null)
            {
                txtNombrePerfilSocio.Text = socioActual.Nombre;
                txtApellidoPerfilSocio.Text = socioActual.Apellido;
                txtDniPerfilSocio.Text = socioActual.Dni;

                if (socioActual.FechaNacimiento < dtpPerfilSocio.MinDate)
                    dtpPerfilSocio.Value = dtpPerfilSocio.MinDate;
                else if (socioActual.FechaNacimiento > dtpPerfilSocio.MaxDate)
                    dtpPerfilSocio.Value = dtpPerfilSocio.MaxDate;
                else
                    dtpPerfilSocio.Value = socioActual.FechaNacimiento;

                txtUsuarioPerfilSocio.Text = socioActual.Usuario;
                txtClaveActualPerfilSocio.Text = string.Empty;
                txtClaveNuevaPerfilSocio.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("No se encontraron datos del socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void BloquearCampos()
        {
            txtNombrePerfilSocio.ReadOnly = true;
            txtApellidoPerfilSocio.ReadOnly = true;
            txtDniPerfilSocio.ReadOnly = true;
            txtUsuarioPerfilSocio.ReadOnly = true;
            dtpPerfilSocio.Enabled = false;
            txtClaveActualPerfilSocio.Visible = false;
            txtClaveNuevaPerfilSocio.Visible = false;

            btnGuardarPerfilSocio.Visible = false;
            btnCancelarPerfilSocio.Visible = true;
            btnEditarPerfilSocio.Visible = true;
        }

        private void DesbloquearCampos()
        {
            txtNombrePerfilSocio.ReadOnly = false;
            txtApellidoPerfilSocio.ReadOnly = false;
            dtpPerfilSocio.Enabled = true;
            txtClaveActualPerfilSocio.Visible = true;
            txtClaveNuevaPerfilSocio.Visible = true;

            btnGuardarPerfilSocio.Visible = true;
            btnCancelarPerfilSocio.Visible = true;
            btnEditarPerfilSocio.Visible = false;
        }

        private void btnEditarPerfilSocio_Click(object sender, EventArgs e)
        {
            DesbloquearCampos();
        }

        private void btnCancelarPerfilSocio_Click(object sender, EventArgs e)
        {
            if (btnGuardarPerfilSocio.Visible)
            {
                CargarDatosSocio();
                BloquearCampos();
            }
            else
            {
                this.Close();
                new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
            }
        }

        private void btnGuardarPerfilSocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtClaveActualPerfilSocio.Text) || !string.IsNullOrWhiteSpace(txtClaveNuevaPerfilSocio.Text))
                {
                    if (txtClaveActualPerfilSocio.Text != socioActual.Clave)
                    {
                        MessageBox.Show("La clave actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtClaveNuevaPerfilSocio.Text))
                    {
                        MessageBox.Show("Debe ingresar una nueva clave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    socioActual.Clave = txtClaveNuevaPerfilSocio.Text;
                }

                socioActual.Nombre = txtNombrePerfilSocio.Text;
                socioActual.Apellido = txtApellidoPerfilSocio.Text;
                socioActual.FechaNacimiento = dtpPerfilSocio.Value;

                socioRepo.ActualizarSocio(socioActual);

                MessageBox.Show("Perfil actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatosSocio();
                BloquearCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el perfil: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombrePerfilSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellidoPerfilSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
