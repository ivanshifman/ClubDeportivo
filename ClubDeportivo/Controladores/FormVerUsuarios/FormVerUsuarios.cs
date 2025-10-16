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

            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;
            dgvSocios.AllowUserToAddRows = false;

            dgvNoSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNoSocios.MultiSelect = false;
            dgvNoSocios.AllowUserToAddRows = false;

            dgvSocios.ClearSelection();
            dgvNoSocios.ClearSelection();

            foreach (DataGridViewColumn col in dgvSocios.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewColumn col in dgvNoSocios.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvSocios.SelectionChanged += (s, ev) =>
            {
                if (dgvSocios.SelectedRows.Count > 0)
                    dgvNoSocios.ClearSelection();
            };

            dgvNoSocios.SelectionChanged += (s, ev) =>
            {
                if (dgvNoSocios.SelectedRows.Count > 0)
                    dgvSocios.ClearSelection();
            };
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

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            string usuarioSeleccionado = null;
            bool esSocio = false;

            if (dgvSocios.SelectedRows.Count > 0)
            {
                usuarioSeleccionado = dgvSocios.SelectedRows[0].Cells["UsuarioSocio"].Value.ToString();
                esSocio = true;
            }
            else if (dgvNoSocios.SelectedRows.Count > 0)
            {
                usuarioSeleccionado = dgvNoSocios.SelectedRows[0].Cells["UsuarioNoSocio"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un socio o no socio para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar al {(esSocio ? "socio" : "no socio")} '{usuarioSeleccionado}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                adminRepo.EliminarUsuarioPorUsuario(usuarioSeleccionado);

                MessageBox.Show(
                    $"{(esSocio ? "Socio" : "No socio")} eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (esSocio)
                    CargarSocios();
                else
                    CargarNoSocios();

                dgvSocios.ClearSelection();
                dgvNoSocios.ClearSelection();
            }
        }
    }
}


