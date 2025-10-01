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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener actividades: {ex.Message}");
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reducir capacidad: {ex.Message}");
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar disponibilidad: {ex.Message}");
            }

            return false;
        }

    }
}

