using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FrmLogin
{
    public partial class frmLogin : Form
    {
        private int intentosFallidos = 0;
        private const int maxIntentos = 3;

        public frmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => txtUsuario.Focus()));
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var repo = new Servicios.PersonaRepository();
            var resultado = repo.Ingresar(txtUsuario.Text.Trim(), txtPass.Text.Trim());

            if (resultado.HasValue)
            {
                intentosFallidos = 0;
                GestionarLoginPorRol(resultado.Value);
            }
            else
            {
                GestionarErrorLogin();
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnIngresar.PerformClick();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClubDeportivo.Controladores.FormPreRegistro.frmPreRegistro().Show();
        }

        private bool ValidarCampos()
        {
            bool esValido = true;

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.BackColor = Color.LightPink;
                esValido = false;
            }
            else
            {
                txtUsuario.BackColor = Color.White;
            }

            if (string.IsNullOrEmpty(txtPass.Text))
            {
                txtPass.BackColor = Color.LightPink;
                esValido = false;
            }
            else
            {
                txtPass.BackColor = Color.White;
            }

            if (!esValido)
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios");
                txtUsuario.BackColor = Color.White;
                txtPass.BackColor = Color.White;
            }

            return esValido;
        }

        private void GestionarLoginPorRol((int idPersona, string rol) resultado)
        {
            var (idPersona, rol) = resultado;
            this.Hide();

            switch (rol.ToLower())
            {
                case "administrador":
                    new ClubDeportivo.Controladores.FormPrincipalAdmin.frmPrincipalAdmin().Show();
                    break;
                case "socio":
                    VerificarCuotaSocio(idPersona);
                    break;
                case "nosocio":
                    var noSocioRepo = new ClubDeportivo.Servicios.NoSocioRepository();
                    int idNoSocio = noSocioRepo.ObtenerIdNoSocioPorIdPersona(idPersona);
                    new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio(idNoSocio).Show();
                    break;
                default:
                    MessageBox.Show($"Rol desconocido: {rol}");
                    this.Show();
                    break;
            }
        }

        private void VerificarCuotaSocio(int idPersona)
        {
            var socioRepo = new ClubDeportivo.Servicios.SocioRepository();
            int idSocio = socioRepo.ObtenerIdSocioPorIdPersona(idPersona);

            var cuotaRepo = new ClubDeportivo.Servicios.CuotaRepository();

            bool tieneCuota = cuotaRepo.TieneCuotaPagada(idSocio);
            bool vigente = cuotaRepo.TieneCuotaVigente(idSocio);

            if (!tieneCuota)
            {
                MostrarFormularioPagarCuota(idSocio, "Debe abonar la cuota inicial.");
            }
            else if (!vigente)
            {
                MostrarFormularioPagarCuota(idSocio, "Su cuota está vencida. Debe regularizar el pago.");
            }
            else
            {
                new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
            }
        }

        private void MostrarFormularioPagarCuota(int idSocio, string mensaje)
        {
            MessageBox.Show(mensaje);

            using (var formPagar = new ClubDeportivo.Controladores.FormPagarCuota.frmPagarCuota(idSocio))
            {
                var result = formPagar.ShowDialog();

                if (result == DialogResult.OK)
                {
                    new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            }
        }

        private void GestionarErrorLogin()
        {
            intentosFallidos++;
            MessageBox.Show($"Credenciales incorrectas. Intento {intentosFallidos} de {maxIntentos}.");
            txtUsuario.Clear();
            txtPass.Clear();
            txtUsuario.Focus();

            if (intentosFallidos >= maxIntentos)
            {
                MessageBox.Show("Demasiados intentos fallidos. La aplicación se cerrará.");
                Application.Exit();
            }
        }

    }
}


