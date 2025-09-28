using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormPreRegistro
{
    public partial class frmPreRegistro : Form
    {
        public frmPreRegistro()
        {
            InitializeComponent();
        }

        private void btnPreRegistroSocio_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClubDeportivo.Controladores.FormRegistroSocio.frmRegistroSocio().Show();
        }

        private void btnPreRegistroNoSocio_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClubDeportivo.Controladores.FormRegistroNoSocio.frmRegistroNoSocio().Show();
        }
    }
}
