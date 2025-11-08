using ClubDeportivo.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormListadoCuotasVencidas
{
    public partial class frmListadoCuotasVencidas : Form
    {
        private readonly CuotaRepository cuotaRepo;

        public frmListadoCuotasVencidas()
        {
            InitializeComponent();
            cuotaRepo = new CuotaRepository();
        }

        private void frmListadoCuotasVencidas_Load(object sender, EventArgs e)
        {
            CargarCuotasVencidas();
        }

        private void CargarCuotasVencidas()
        {
            dgvCuotasVencidas.AutoGenerateColumns = false;
            dgvCuotasVencidas.DataSource = cuotaRepo.ObtenerCuotasVencidas();

            dgvCuotasVencidas.Columns["Nombre"].DataPropertyName = "nombre";
            dgvCuotasVencidas.Columns["Apellido"].DataPropertyName = "apellido";
            dgvCuotasVencidas.Columns["DNI"].DataPropertyName = "dni";
            dgvCuotasVencidas.Columns["FechaPago"].DataPropertyName = "fechaPago";
            dgvCuotasVencidas.Columns["FechaVencimiento"].DataPropertyName = "fechaVencimiento";
            dgvCuotasVencidas.Columns["Monto"].DataPropertyName = "monto";
            dgvCuotasVencidas.Columns["MedioPago"].DataPropertyName = "medioPago";
            dgvCuotasVencidas.Columns["Promocion"].DataPropertyName = "promocion";
            dgvCuotasVencidas.Columns["Pagado"].DataPropertyName = "pagado";
        }

        private void btnVolverListadoCuotasVencidas_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalAdmin.frmPrincipalAdmin().Show();
        }

    }
}
