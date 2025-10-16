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
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();
                    string query = "SELECT id_noSocio FROM NoSocio WHERE id_persona = @idPersona";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPersona", idPersona);

                        object result = cmd.ExecuteScalar();
                        return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public NoSocio ObtenerNoSocioPorIdNoSocio(int idNoSocio)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();
                    string query = @"SELECT p.*
                                     FROM Persona p
                                     INNER JOIN NoSocio n ON p.id_persona = n.id_persona
                                     WHERE n.id_noSocio = @idNoSocio";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idNoSocio", idNoSocio);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new NoSocio(
                                    reader.GetString("nombre"),
                                    reader.GetString("apellido"),
                                    reader.GetString("dni"),
                                    reader.GetDateTime("fecha_nacimiento"),
                                    reader.GetString("usuario"),
                                    reader.GetString("clave")
                                )
                                {
                                    IdPersona = reader.GetInt32("id_persona"),
                                    IdNoSocio = idNoSocio
                                };
                            }
                            else
                            {
                                return null;
                            }
                        }
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

        public void ActualizarNoSocio(NoSocio noSocio)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();

                    string query = @"
                        UPDATE Persona 
                        SET nombre = @nombre,
                            apellido = @apellido,
                            fecha_nacimiento = @fechaNacimiento,
                            clave = @clave
                        WHERE id_persona = @idPersona";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", noSocio.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", noSocio.Apellido);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", noSocio.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@clave", noSocio.Clave);
                        cmd.Parameters.AddWithValue("@idPersona", noSocio.IdPersona);
                        cmd.ExecuteNonQuery();
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
    }
}
