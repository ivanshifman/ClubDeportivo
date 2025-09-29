using ClubDeportivo.Modelos;
using ClubDeportivo.Repositories;
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

                var repo = new SocioRepository();
                repo.Registrar(socio);

                new ClubDeportivo.Controladores.FormPagarCuota.frmPagarCuota().Show();
                this.Hide();
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

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreSocio.Text) || txtNombreSocio.Text.Length > 100)
                throw new ArgumentException("El nombre no puede estar vacío ni superar los 100 caracteres.");

            if (string.IsNullOrWhiteSpace(txtApellidoSocio.Text) || txtApellidoSocio.Text.Length > 100)
                throw new ArgumentException("El apellido no puede estar vacío ni superar los 100 caracteres.");

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

