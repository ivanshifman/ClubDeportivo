using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FrmLogin
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                DataTable tablaLogin = new DataTable(); // es la que recibe los datos desde el formulario
                Clases.Usuarios dato = new Clases.Usuarios(); // variable que contiene todas las caracteristicas de la clase
                tablaLogin = dato.Log_Usu(txtUsuario.Text, txtPass.Text);
                if (tablaLogin.Rows.Count > 0)
                {
                    // quiere decir que el resultado tiene 1 fila por lo que el usuario EXISTE
                    MessageBox.Show("Ingreso exitoso");
                }
                else
                {
                    MessageBox.Show("Usuario y/o password incorrecto");
                }
            }
            else
            {
                return;
            }
        }
        private bool ValidarCampos()
        {
            bool esValido = true;

            // Validar usuario
            if (string.IsNullOrEmpty(txtUsuario.Text) || txtUsuario.Text == "USUARIO")
            {
                txtUsuario.BackColor = Color.LightPink; // Resaltar error
                esValido = false;
            }
            else
            {
                txtUsuario.BackColor = Color.White;
            }

            // Validar contraseña
            if (string.IsNullOrEmpty(txtPass.Text) || txtPass.Text == "CONTRASEÑA")
            {
                txtPass.BackColor = Color.LightPink;
                esValido = false;
            }
            else
            {
                txtPass.BackColor = Color.White;
            }

            if (!esValido)
                MessageBox.Show("Por favor complete todos los campos obligatorios");

            return esValido;
        }

    }
}

