using System;
using System.Linq;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormPagarActividad
{
    public partial class frmPagarActividad : Form
    {

        private readonly int idNoSocio;
        public frmPagarActividad(int idNoSocio)
        {
            InitializeComponent();
            this.idNoSocio = idNoSocio;
            this.KeyPreview = true;
        }

        private void frmPagarActividad_Load(object sender, EventArgs e)
        {
            var repo = new ClubDeportivo.Servicios.ActividadRepository();
            var actividades = repo.ObtenerTodasActividades();

            actividades = actividades.OrderBy(a => a.Nombre).ToList();

            cmbActividad.DataSource = actividades;
            cmbActividad.DisplayMember = "NombreConHorario";
            cmbActividad.ValueMember = "IdActividad";

            cmbActividad.SelectedIndexChanged += CmbActividad_SelectedIndexChanged;

            cmbMetodoPagoActividad.Items.Clear();
            cmbMetodoPagoActividad.Items.Add("Efectivo");
            cmbMetodoPagoActividad.Items.Add("Tarjeta");

            if (cmbActividad.SelectedItem != null)
            {
                ActualizarMonto();
            }
        }

        private void CmbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarMonto();
        }

        private void btnPagarActividad_Click(object sender, EventArgs e)
        {
            if (cmbActividad.SelectedValue == null || cmbMetodoPagoActividad.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar actividad y método de pago");
                return;
            }

            int idActividad = (int)cmbActividad.SelectedValue;
            var repo = new ClubDeportivo.Servicios.ActividadRepository();
            var pagoRepo = new ClubDeportivo.Servicios.PagoActividadRepository();

            if (pagoRepo.YaPagoActividad(idNoSocio, idActividad))
            {
                MessageBox.Show("Ya pagó esta actividad. No puede pagar dos veces.");
                return;
            }

            if (!repo.VerificarDisponibilidad(idActividad))
            {
                MessageBox.Show("La actividad no tiene cupos disponibles.");
                return;
            }

            var pago = new ClubDeportivo.Modelos.PagoActividad
            {
                IdNoSocio = idNoSocio,
                IdActividad = idActividad,
                Fecha = DateTime.Now,
                MontoAPagar = decimal.Parse(txtMontoCuota.Text),
                MetodoPago = cmbMetodoPagoActividad.SelectedItem.ToString()
            };

            int result = pagoRepo.RegistrarPago(pago);

            if (result > 0)
            {
                repo.ReducirCapacidad(idActividad);

                MessageBox.Show("Pago registrado con éxito.");
                this.Close();
                new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio(idNoSocio).Show();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el pago.");
                this.Close();
                new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio(idNoSocio).Show();
            }
        }

        private void frmPagarActividad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnPagarActividad.PerformClick();
            }
        }

        private void ActualizarMonto()
        {
            if (cmbActividad.SelectedItem is ClubDeportivo.Modelos.Actividad act)
            {
                txtMontoCuota.Text = act.Costo.ToString("0.00");
            }
        }

        private void btnCancelarActividad_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio(idNoSocio).Show();
        }
    }
}
