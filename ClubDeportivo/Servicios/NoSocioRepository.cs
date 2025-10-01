using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    public class NoSocioRepository : PersonaRepository
    {
        public int Registrar(NoSocio noSocio)
        {
            try
            {
                int idPersona = base.Registrar(noSocio);

                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();
                    string query = @"INSERT INTO NoSocio (id_persona)
                             VALUES (@idPersona)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPersona", idPersona);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT LAST_INSERT_ID();";
                        int idNoSocio = Convert.ToInt32(cmd.ExecuteScalar());
                        return idNoSocio;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public int ObtenerIdNoSocioPorIdPersona(int idPersona)
        {
            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string query = "SELECT id_noSocio FROM NoSocio WHERE id_persona = @idPersona";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


    }
}

