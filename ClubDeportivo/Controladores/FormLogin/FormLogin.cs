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
                string rol = resultado.Value.rol;

                this.Hide();

                switch (rol.ToLower())
                {
                    case "administrador":
                        new ClubDeportivo.Controladores.FormPrincipalAdmin.frmPrincipalAdmin().Show();
                        break;
                    case "socio":
                        var cuotaRepo = new ClubDeportivo.Servicios.CuotaRepository();

                        bool tieneCuota = cuotaRepo.TieneCuotaPagadaPorPersona(resultado.Value.idPersona);
                        bool vigente = cuotaRepo.TieneCuotaVigentePorPersona(resultado.Value.idPersona);

                        if (!tieneCuota)
                        {
                            MessageBox.Show("Debe abonar la cuota inicial.");
                            var form = new ClubDeportivo.Controladores.FormPagarCuota.frmPagarCuota(resultado.Value.idPersona);

                            if (form.ShowDialog() == DialogResult.OK)
                                new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio().Show();
                            else
                                this.Show();
                        }
                        else if (!vigente)
                        {
                            MessageBox.Show("Su cuota está vencida. Debe regularizar el pago.");
                            var form = new ClubDeportivo.Controladores.FormPagarCuota.frmPagarCuota(resultado.Value.idPersona);

                            if (form.ShowDialog() == DialogResult.OK)
                                new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio().Show();
                            else
                                this.Show();
                        }
                        else
                        {
                            new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio().Show();
                        }
                        break;

                    case "nosocio":
                        new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio().Show();
                        break;
                    default:
                        MessageBox.Show($"Rol desconocido: {rol}");
                        this.Show();
                        break;
                }
            }
            else
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
    }
}

