using ClubDeportivo.Controladores.FrmLogin;
using DotNetEnv;
using System;
using System.IO;
using System.Windows.Forms;

namespace ClubDeportivo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            // El valor cambia dependiendo donde se ubique cada archivo .env en cada computadora local, se pone dentro "ruta de acceso completa" 

            if (File.Exists(envPath))
            {
                Env.Load(envPath);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
