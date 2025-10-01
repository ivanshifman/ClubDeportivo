using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
