using System;
using System.Windows.Forms;
using ClubDeportivo.Modelos;

namespace ClubDeportivo.Controladores.FormPagarCuota
{
    public partial class frmPagarCuota : Form
    {
        private readonly int idSocio;

        public frmPagarCuota(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
            this.KeyPreview = true;
        }

        private void frmPagarCuota_Load(object sender, EventArgs e)
        {
            InicializarCombos();
            CargarDatosSocio();
            AplicarReglasDePromocion();
        }

        private void cmbMedioPagoCuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarReglasDePromocion();
        }

        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            RegistrarCuota();
        }

        private void frmPagarCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnPagarCuota.PerformClick();
            }
        }

        private void btnCancelarCuota_Click(object sender, EventArgs e)
        {
            var socioRepo = new ClubDeportivo.Servicios.CuotaRepository();

            bool tieneInicial = socioRepo.TieneCuotaPagada(idSocio);
            bool tieneVigente = socioRepo.TieneCuotaVigente(idSocio);

            string mensaje;

            if (!tieneInicial)
            {
                mensaje = "El socio quedará registrado pero no podrá acceder al menú principal hasta abonar la cuota inicial.\n\n¿Desea continuar?";
            }
            else if (!tieneVigente)
            {
                mensaje = "Su cuota está vencida. No podrá acceder al menú principal hasta renovarla.\n\n¿Desea continuar?";
            }
            else
            {
                mensaje = "¿Está seguro de que desea cancelar?";
            }

            var result = MessageBox.Show(
                mensaje,
                "Confirmar cancelación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                if (!tieneInicial || !tieneVigente)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                this.Close();
            }
        }
        
        private void InicializarCombos()
        {
            cmbMedioPagoCuota.Items.Clear();
            cmbMedioPagoCuota.Items.AddRange(new string[] { "Efectivo", "Tarjeta" });
            cmbMedioPagoCuota.SelectedIndex = 0;
            cmbMedioPagoCuota.SelectedIndexChanged += cmbMedioPagoCuota_SelectedIndexChanged;

            cmbPromocion.Items.Clear();
            cmbPromocion.Items.AddRange(new string[] { "0", "3", "6" });
            cmbPromocion.SelectedIndex = 0;
        }

        private void CargarDatosSocio()
        {
            var repo = new ClubDeportivo.Servicios.SocioRepository();
            var socio = repo.ObtenerSocioPorIdSocio(idSocio);

            if (socio != null)
            {
                lblNombreCompletoSocio.Text = $"{socio.Nombre} {socio.Apellido}";
                lblDniCompletoSocio.Text = socio.Dni;

                decimal montoDefault = 5000m;
                txtMontoCuota.Text = montoDefault.ToString("F2");
            }
            else
            {
                MessageBox.Show("No se encontró el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void AplicarReglasDePromocion()
        {
            if (cmbMedioPagoCuota.SelectedItem?.ToString() == "Efectivo")
            {
                cmbPromocion.SelectedItem = "0";
                cmbPromocion.Enabled = false;
            }
            else
            {
                cmbPromocion.Enabled = true;
            }
        }

        private void RegistrarCuota()
        {
            try
            {
                if (!decimal.TryParse(txtMontoCuota.Text, out decimal monto))
                {
                    MessageBox.Show("Monto inválido. Debe ser un número decimal.");
                    txtMontoCuota.Focus();
                    return;
                }

                string medioPago = cmbMedioPagoCuota.SelectedItem?.ToString() ?? "";
                string promocion = cmbPromocion.SelectedItem?.ToString() ?? "0";

                var cuota = new Cuota(
                    idSocio,
                    monto,
                    DateTime.Today,
                    DateTime.Today.AddMonths(1),
                    medioPago,
                    promocion
                );

                var repo = new ClubDeportivo.Servicios.CuotaRepository();
                int filasAfectadas = repo.RegistrarRenovacion(idSocio, cuota);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Cuota registrada con éxito.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cuota: {ex.Message}");
            }
        }

    }
}

