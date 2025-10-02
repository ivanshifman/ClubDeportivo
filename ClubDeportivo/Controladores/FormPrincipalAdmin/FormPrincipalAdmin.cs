using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormPrincipalAdmin
{
    public partial class frmPrincipalAdmin : Form
    {
        public frmPrincipalAdmin()
        {
            InitializeComponent();
        }

        private void btnCerrarAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FrmLogin.frmLogin().Show();
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormVerUsuarios.frmVerUsuarios().Show();
        }

        private void btnListarCuotasVencidas_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormListadoCuotasVencidas.frmListadoCuotasVencidas().Show();
        }

        private void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormAgregarActividad.frmAgregarActividad().Show();
        }
    }
}
