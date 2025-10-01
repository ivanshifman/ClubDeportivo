using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormVerCarnet
{
    public partial class frmVerCarnet : Form
    {
        private readonly int idSocio;

        public frmVerCarnet(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
        }

        private void frmVerCarnet_Load(object sender, EventArgs e)
        {
            CargarDatosCarnet();
        }

        private void btnVolverCarnet_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
        }

        private void CargarDatosCarnet()
        {
            var repo = new SocioRepository();
            Socio socio = repo.VerCarnet(idSocio);

            if (socio != null)
            {
                lblDniCompletoCarnet.Text = socio.Dni;
                lblNombreCompletoCarnet.Text = $"{socio.Nombre} {socio.Apellido}";
                lblFechaNacimientoCompletoCarnet.Text = socio.FechaNacimiento.ToString("dd/MM/yyyy");
                lblFechaAltaCompletoCarnet.Text = socio.FechaAlta.ToString("dd/MM/yyyy");
                lblFichaMedicaCompletoCarnet.Text = socio.FichaMedica ? "Sí" : "No";
            }
            else
            {
                MessageBox.Show("No se encontraron datos del socio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
