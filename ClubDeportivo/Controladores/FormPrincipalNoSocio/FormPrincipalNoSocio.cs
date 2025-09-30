using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormPrincipalNoSocio
{
    public partial class frmPrincipalNoSocio : Form
    {
        public frmPrincipalNoSocio()
        {
            InitializeComponent();      
        }

        private void btnPagarActividad_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarNoSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FrmLogin.frmLogin().Show();
        }
    }
}
