using ClubDeportivo.Modelos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormRegistroSocio
{
    public partial class frmRegistroSocio : Form
    {
        public frmRegistroSocio()
        {
            InitializeComponent();        
            dtpSocio.MaxDate = DateTime.Today;
            dtpSocio.MinDate = new DateTime(1900, 1, 1);
            dtpSocio.Value = DateTime.Today;
            this.KeyPreview = true;
        }

        private void frmRegistroSocio_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => txtNombreSocio.Focus()));
        }

        private void btnRegistrarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                var socio = new Socio(
                    txtNombreSocio.Text.Trim(),
                    txtApellidoSocio.Text.Trim(),
                    txtDniSocio.Text.Trim(),
                    dtpSocio.Value,
                    txtUsuarioSocio.Text.Trim(),
                    txtClaveSocio.Text,
                    DateTime.Today,
                    true,
                    chkFichaMedicaSocio.Checked
                );

                var repo = new ClubDeportivo.Servicios.SocioRepository();
                int idPersona = repo.Registrar(socio);
                int idSocio = repo.ObtenerIdSocioPorIdPersona(idPersona);

                this.Close();
                var formPagar = new ClubDeportivo.Controladores.FormPagarCuota.frmPagarCuota(idSocio);
                var result = formPagar.ShowDialog();

                if (result == DialogResult.OK)
                {
                    new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
                    this.Close();
                }
                else
                {
                    this.Close();
                    new ClubDeportivo.Controladores.FrmLogin.frmLogin().Show();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el socio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistroSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnRegistrarSocio.PerformClick();
            }
        }

        private void txtNombreSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellidoSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDniSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelarSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FrmLogin.frmLogin().Show();
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreSocio.Text) || txtNombreSocio.Text.Length > 100)
                throw new ArgumentException("El nombre no puede estar vacío ni superar los 100 caracteres.");

            if (string.IsNullOrWhiteSpace(txtApellidoSocio.Text) || txtApellidoSocio.Text.Length > 100)
                throw new ArgumentException("El apellido no puede estar vacío ni superar los 100 caracteres.");

            if (!Regex.IsMatch(txtNombreSocio.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El nombre solo puede contener letras y espacios.");

            if (!Regex.IsMatch(txtApellidoSocio.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El apellido solo puede contener letras y espacios.");

            if (string.IsNullOrWhiteSpace(txtDniSocio.Text) || !Regex.IsMatch(txtDniSocio.Text, @"^\d{7,8}$"))
                throw new ArgumentException("El DNI debe tener entre 7 y 8 dígitos numéricos.");

            if (dtpSocio.Value > DateTime.Today)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.");

            if (string.IsNullOrWhiteSpace(txtUsuarioSocio.Text) || txtUsuarioSocio.Text.Length > 50)
                throw new ArgumentException("El usuario no puede estar vacío ni superar los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(txtClaveSocio.Text) || txtClaveSocio.Text.Length < 6)
                throw new ArgumentException("La clave debe tener al menos 6 caracteres.");

            if (!chkFichaMedicaSocio.Checked)
                throw new ArgumentException("Debe completar la ficha médica para poder registrarse.");
        }
    }
}

