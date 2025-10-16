using ClubDeportivo.Controladores.FormLogin;
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
            // El valor cambia dependiendo donde se ubique cada archivo .env en cada computadora local, se pone dentro de "" la ruta de acceso completa del archivo

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
