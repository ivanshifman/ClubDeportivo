using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormVerActividades
{
    public partial class frmVerActividades : Form
    {
        private readonly int idNoSocio;
        public frmVerActividades(int idNoSocio)
        {
            InitializeComponent();
            this.idNoSocio = idNoSocio;
        }

        private void frmVerActividades_Load(object sender, EventArgs e)
        {
            var repo = new ClubDeportivo.Servicios.ActividadRepository();
            var actividades = repo.ObtenerTodasActividades();

            dgvActividades.Rows.Clear();

            foreach (var act in actividades)
            {
                bool disponible = repo.VerificarDisponibilidad(act.IdActividad);

                dgvActividades.Rows.Add(
                    act.Nombre,
                    act.Tipo,
                    act.Profesor,
                    act.Horario.ToString("dd/MM/yyyy HH:mm"),
                    act.Capacidad,
                    act.Costo,
                    disponible ? "Disponible" : "Sin cupos"
                );
            }
        }

        private void btnVolverActividades_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalNoSocio.frmPrincipalNoSocio(idNoSocio).Show();
        }

    }
}
