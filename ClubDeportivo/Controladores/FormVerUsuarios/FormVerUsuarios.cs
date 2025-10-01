using System;
using System.Windows.Forms;
using ClubDeportivo.Servicios;

namespace ClubDeportivo.Controladores.FormVerUsuarios
{
    public partial class frmVerUsuarios : Form
    {
        private readonly AdministradorRepository adminRepo;

        public frmVerUsuarios()
        {
            InitializeComponent();
            adminRepo = new AdministradorRepository();
        }

        private void frmVerUsuarios_Load(object sender, EventArgs e)
        {
            CargarSocios();
            CargarNoSocios();
        }

        private void CargarSocios()
        {
            dgvSocios.AutoGenerateColumns = false;
            dgvSocios.DataSource = adminRepo.ObtenerSocios();

            dgvSocios.Columns["NombreSocio"].DataPropertyName = "nombre";
            dgvSocios.Columns["ApellidoSocio"].DataPropertyName = "apellido";
            dgvSocios.Columns["DNISocio"].DataPropertyName = "dni";
            dgvSocios.Columns["FechaNacimientoSocio"].DataPropertyName = "fecha_nacimiento";
            dgvSocios.Columns["FichaMedicaSocio"].DataPropertyName = "fichaMedica";
            dgvSocios.Columns["FechaAltaSocio"].DataPropertyName = "fechaAlta";
            dgvSocios.Columns["UsuarioSocio"].DataPropertyName = "usuario";
        }

        private void CargarNoSocios()
        {
            dgvNoSocios.AutoGenerateColumns = false;
            dgvNoSocios.DataSource = adminRepo.ObtenerNoSocios();

            dgvNoSocios.Columns["NombreNoSocio"].DataPropertyName = "nombre";
            dgvNoSocios.Columns["ApellidoNoSocio"].DataPropertyName = "apellido";
            dgvNoSocios.Columns["FechaNacimientoNoSocio"].DataPropertyName = "fecha_nacimiento";
            dgvNoSocios.Columns["UsuarioNoSocio"].DataPropertyName = "usuario";
        }

        private void btnVolverUsuarios_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalAdmin.frmPrincipalAdmin().Show();
        }

    }
}

