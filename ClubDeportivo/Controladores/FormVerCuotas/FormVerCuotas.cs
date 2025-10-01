using ClubDeportivo.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormVerCuotas
{
    public partial class frmVerCuotas : Form
    {
        private readonly int idSocio;
        private readonly CuotaRepository cuotaRepo;

        public frmVerCuotas(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
            cuotaRepo = new CuotaRepository();
        }

        private void frmVerCuotas_Load(object sender, EventArgs e)
        {
            CargarHistorialCuotas();
        }

        private void btnVolverCuota_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
        }

        private void CargarHistorialCuotas()
        {
            dgvCuotas.AutoGenerateColumns = false;
            dgvCuotas.DataSource = cuotaRepo.ObtenerCuotasPorSocio(idSocio);

            dgvCuotas.Columns["FechaPago"].DataPropertyName = "fechaPago";
            dgvCuotas.Columns["FechaVencimiento"].DataPropertyName = "fechaVencimiento";
            dgvCuotas.Columns["Monto"].DataPropertyName = "monto";
            dgvCuotas.Columns["MedioPago"].DataPropertyName = "medioPago";
            dgvCuotas.Columns["Promocion"].DataPropertyName = "promocion";
        }
    }
}

