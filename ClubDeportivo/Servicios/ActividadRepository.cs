using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    public class ActividadRepository
    {
        public List<Actividad> ObtenerTodasActividades()
        {
            var actividades = new List<Actividad>();

            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();
                    string query = @"SELECT id_actividad, nombre, tipo, profesor, horario, capacidad, costo 
                                     FROM Actividad";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            actividades.Add(new Actividad
                            {
                                IdActividad = reader.GetInt32("id_actividad"),
                                Nombre = reader.GetString("nombre"),
                                Tipo = reader.GetString("tipo"),
                                Profesor = reader.GetString("profesor"),
                                Horario = reader.GetDateTime("horario"),
                                Capacidad = reader.GetInt32("capacidad"),
                                Costo = reader.GetDecimal("costo")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return actividades;
        }

        public void ReducirCapacidad(int idActividad)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();
                    string query = @"UPDATE Actividad
                             SET capacidad = capacidad - 1
                             WHERE id_actividad = @id AND capacidad > 0";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idActividad);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool VerificarDisponibilidad(int idActividad)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();

                    string query = @"SELECT a.capacidad - COUNT(p.id_pagoActividad) AS cuposDisponibles
                                     FROM Actividad a
                                     LEFT JOIN PagoActividad p ON a.id_actividad = p.id_actividad
                                     WHERE a.id_actividad = @id
                                     GROUP BY a.capacidad";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idActividad);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int cuposDisponibles = Convert.ToInt32(result);
                            return cuposDisponibles > 0;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool EstaInscripto(int idNoSocio, int idActividad)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();

                    string query = @"SELECT COUNT(*) 
                             FROM PagoActividad 
                             WHERE id_noSocio = @idNoSocio AND id_actividad = @idActividad";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idNoSocio", idNoSocio);
                        cmd.Parameters.AddWithValue("@idActividad", idActividad);

                        var result = Convert.ToInt32(cmd.ExecuteScalar());
                        return result > 0; // Si hay al menos un registro, ya está inscripto
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }


        public bool AgregarActividad(Actividad actividad)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();
                    string query = @"INSERT INTO Actividad (nombre, tipo, profesor, horario, capacidad, costo)
                             VALUES (@nombre, @tipo, @profesor, @horario, @capacidad, @costo)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", actividad.Nombre);
                        cmd.Parameters.AddWithValue("@tipo", actividad.Tipo);
                        cmd.Parameters.AddWithValue("@profesor", actividad.Profesor);
                        cmd.Parameters.AddWithValue("@horario", actividad.Horario);
                        cmd.Parameters.AddWithValue("@capacidad", actividad.Capacidad);
                        cmd.Parameters.AddWithValue("@costo", actividad.Costo);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
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
    }
}
