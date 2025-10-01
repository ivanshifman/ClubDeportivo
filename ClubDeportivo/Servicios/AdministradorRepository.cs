using ClubDeportivo.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    public class AdministradorRepository
    {
        public DataTable ObtenerSocios()
        {
            var tabla = new DataTable();

            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    string query = @"
                        SELECT p.nombre, p.apellido, p.dni, p.fecha_nacimiento,
                               s.fichaMedica, s.fechaAlta, p.usuario
                        FROM Persona p
                        INNER JOIN Socio s ON p.id_persona = s.id_persona";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            tabla.Load(reader);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }

            return tabla;
        }

        public DataTable ObtenerNoSocios()
        {
            var tabla = new DataTable();

            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    string query = @"
                        SELECT p.nombre, p.apellido, p.fecha_nacimiento, p.usuario
                        FROM Persona p
                        INNER JOIN NoSocio ns ON p.id_persona = ns.id_persona";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            tabla.Load(reader);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }

            return tabla;
        }
    }
}
