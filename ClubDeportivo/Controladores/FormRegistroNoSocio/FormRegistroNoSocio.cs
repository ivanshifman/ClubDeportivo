using ClubDeportivo.Modelos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormRegistroNoSocio
{
    public partial class frmRegistroNoSocio : Form
    {
        public frmRegistroNoSocio()
        {
            InitializeComponent();
            dtpNoSocio.MaxDate = DateTime.Today;
            dtpNoSocio.MinDate = new DateTime(1900, 1, 1);
            dtpNoSocio.Value = DateTime.Today;
        }

        private void btnRegistrarNoSocio_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                var noSocio = new NoSocio(
                    txtNombreNoSocio.Text.Trim(),
                    txtApellidoNoSocio.Text.Trim(),
                    txtDniNoSocio.Text.Trim(),
                    dtpNoSocio.Value,
                    txtUsuarioNoSocio.Text.Trim(),
                    txtClaveNoSocio.Text
                );

                var repo = new ClubDeportivo.Servicios.NoSocioRepository();
                repo.Registrar(noSocio);

                this.Close();
                new FormPrincipalNoSocio.frmPrincipalNoSocio(noSocio.IdNoSocio).Show();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el no socio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombreNoSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellidoNoSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDniNoSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelarNoSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FrmLogin.frmLogin().Show();
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreNoSocio.Text) || txtNombreNoSocio.Text.Length > 100)
                throw new ArgumentException("El nombre no puede estar vacío ni superar los 100 caracteres.");

            if (string.IsNullOrWhiteSpace(txtApellidoNoSocio.Text) || txtApellidoNoSocio.Text.Length > 100)
                throw new ArgumentException("El apellido no puede estar vacío ni superar los 100 caracteres.");

            if (!Regex.IsMatch(txtNombreNoSocio.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El nombre solo puede contener letras y espacios.");

            if (!Regex.IsMatch(txtApellidoNoSocio.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El apellido solo puede contener letras y espacios.");

            if (string.IsNullOrWhiteSpace(txtDniNoSocio.Text) || !Regex.IsMatch(txtDniNoSocio.Text, @"^\d{7,8}$"))
                throw new ArgumentException("El DNI debe tener entre 7 y 8 dígitos numéricos.");

            if (dtpNoSocio.Value > DateTime.Today)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.");

            if (string.IsNullOrWhiteSpace(txtUsuarioNoSocio.Text) || txtUsuarioNoSocio.Text.Length > 50)
                throw new ArgumentException("El usuario no puede estar vacío ni superar los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(txtClaveNoSocio.Text) || txtClaveNoSocio.Text.Length < 6)
                throw new ArgumentException("La clave debe tener al menos 6 caracteres.");
        }

    }
}
