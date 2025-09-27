using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Database
{
    internal class ConexionDB
    {
        private readonly string baseDatos;
        private readonly string servidor;
        private readonly string puerto;
        private readonly string usuario;
        private readonly string clave;
        private static ConexionDB instancia = null;

        private ConexionDB()
        {
            this.baseDatos = Environment.GetEnvironmentVariable("DB_NAME") ?? "club_deportivo";
            this.servidor = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            this.puerto = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";
            this.usuario = Environment.GetEnvironmentVariable("DB_USER") ?? "club_user";
            this.clave = Environment.GetEnvironmentVariable("DB_PASS") ?? "MiPass123";
            // Usuario o clave pueden sufrir modificaciones dependiendo los valores para uso local
        }

        public MySqlConnection CrearConexionMySQL()
        {
            try
            {
                var conexion = new MySqlConnection
                {
                    ConnectionString =
                        $"datasource={this.servidor};" +
                        $"port={this.puerto};" +
                        $"username={this.usuario};" +
                        $"password={this.clave};" +
                        $"Database={this.baseDatos};"
                };
                return conexion;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error al conectar a la base de datos:\n{ex.Message}",
                    "Error MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error general:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }
        }

        public static ConexionDB GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConexionDB();
            }
            return instancia;
        }
    }
}

