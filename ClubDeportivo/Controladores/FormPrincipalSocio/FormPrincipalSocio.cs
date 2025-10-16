using System;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormPrincipalSocio
{
    public partial class frmPrincipalSocio : Form
    {
        private readonly int idSocio;

        public frmPrincipalSocio(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
        }

        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            using (var formPagar = new ClubDeportivo.Controladores.FormPagarCuota.frmPagarCuota(idSocio))
            {
                var result = formPagar.ShowDialog();

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("La cuota fue renovada correctamente.");
                }
            }
        }

        private void btnCerrarSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormLogin.frmLogin().Show();
        }

        private void btnVerCarnet_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormVerCarnet.frmVerCarnet(idSocio).Show();
        }

        private void btnVerCuotas_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormVerCuotas.frmVerCuotas(idSocio).Show();
        }

        private void btnVerPerfilSocio_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormVerPerfilSocio.frmVerPerfilSocio(idSocio).Show();
        }
    }
}
