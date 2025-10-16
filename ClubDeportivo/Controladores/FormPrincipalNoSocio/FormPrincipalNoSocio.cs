using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormPrincipalNoSocio
{
    public partial class frmPrincipalNoSocio : Form
    {
        private readonly int idNoSocio;

        public frmPrincipalNoSocio(int idNoSocio)
        {
            InitializeComponent();
            this.idNoSocio = idNoSocio;
        }

        private void btnPagarActividad_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPagarActividad.frmPagarActividad(idNoSocio).Show();
        }

        private void btnVerActividadesDisponibles_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormVerActividades.frmVerActividades(idNoSocio).Show();
        }

        private void btnCerrarNoSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormLogin.frmLogin().Show();
        }

        private void btnVerPerfilNoSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormVerPerfilNoSocio.frmVerPerfilNoSocio(idNoSocio).Show();
        }
    }
}
