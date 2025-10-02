using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormAgregarActividad
{
    public partial class frmAgregarActividad : Form
    {
        public frmAgregarActividad()
        {
            InitializeComponent();
            dtpHorarioActividad.Format = DateTimePickerFormat.Custom;
            dtpHorarioActividad.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpHorarioActividad.ShowUpDown = true;
            dtpHorarioActividad.MinDate = DateTime.Now;
            this.KeyPreview = true;

        }

        private void frmAgregarActividad_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => txtNombreActividad.Focus()));
        }

        private void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                AgregarActividad();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar actividad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAgregarActividad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnAgregarActividad.PerformClick();
            }
        }

        private void btnCancelarActividad_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalAdmin.frmPrincipalAdmin().Show();
        }
      
        private void txtNombreActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtTipoActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtProfesorActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreActividad.Text) || txtNombreActividad.Text.Length > 100)
                throw new ArgumentException("El nombre de la actividad no puede estar vacío ni superar 100 caracteres.");

            if (string.IsNullOrWhiteSpace(txtTipoActividad.Text) || txtTipoActividad.Text.Length > 50)
                throw new ArgumentException("El tipo de actividad no puede estar vacío ni superar 50 caracteres.");

            if (string.IsNullOrWhiteSpace(txtProfesorActividad.Text) || txtProfesorActividad.Text.Length > 100)
                throw new ArgumentException("El nombre del profesor no puede estar vacío ni superar 100 caracteres.");

            if (!Regex.IsMatch(txtNombreActividad.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El nombre de la actividad solo puede contener letras y espacios.");

            if (!Regex.IsMatch(txtTipoActividad.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El tipo de actividad solo puede contener letras y espacios.");

            if (!Regex.IsMatch(txtProfesorActividad.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ\s]+$"))
                throw new ArgumentException("El nombre del profesor solo puede contener letras y espacios.");

            if (dtpHorarioActividad.Value < DateTime.Now)
                throw new ArgumentException("El horario de la actividad no puede ser pasado.");

            if (nudCapacidadActividad.Value <= 0)
                throw new ArgumentException("La capacidad debe ser mayor a 0.");

            if (nudCostoActividad.Value < 0)
                throw new ArgumentException("El costo no puede ser negativo.");

            if (nudCostoActividad.Value > 1000)
                throw new ArgumentException("El costo no puede superar $1000.");

        }

        private void AgregarActividad()
        {
            try
            {
                var actividad = new Actividad
                {
                    Nombre = txtNombreActividad.Text.Trim(),
                    Tipo = txtTipoActividad.Text.Trim(),
                    Profesor = txtProfesorActividad.Text.Trim(),
                    Horario = dtpHorarioActividad.Value,
                    Capacidad = (int)nudCapacidadActividad.Value,
                    Costo = nudCostoActividad.Value
                };

                var repo = new ActividadRepository();
                if (repo.AgregarActividad(actividad))
                {
                    MessageBox.Show("Actividad agregada correctamente.");
                    this.Close();
                    new ClubDeportivo.Controladores.FormPrincipalAdmin.frmPrincipalAdmin().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar actividad: {ex.Message}");
            }
        }
    }
}
