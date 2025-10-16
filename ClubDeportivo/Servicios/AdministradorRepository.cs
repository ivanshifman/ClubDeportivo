using ClubDeportivo.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tabla;
        }

        public void EliminarUsuarioPorUsuario(string usuario)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();

                    string queryIdNoSocio = @"
                SELECT ns.id_noSocio
                FROM NoSocio ns
                INNER JOIN Persona p ON ns.id_persona = p.id_persona
                WHERE p.usuario = @usuario";

                    int? idNoSocio = null;
                    using (var cmd = new MySqlCommand(queryIdNoSocio, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            idNoSocio = Convert.ToInt32(result);
                    }

                    if (idNoSocio.HasValue)
                    {
                        string queryActividades = @"
                    SELECT id_actividad
                    FROM PagoActividad
                    WHERE id_noSocio = @idNoSocio";

                        var actividades = new List<int>();
                        using (var cmd = new MySqlCommand(queryActividades, conn))
                        {
                            cmd.Parameters.AddWithValue("@idNoSocio", idNoSocio.Value);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                    actividades.Add(reader.GetInt32("id_actividad"));
                            }
                        }

                        foreach (var idActividad in actividades)
                        {
                            string updateCapacidad = @"
                        UPDATE Actividad
                        SET capacidad = capacidad + 1
                        WHERE id_actividad = @idActividad";

                            using (var cmd = new MySqlCommand(updateCapacidad, conn))
                            {
                                cmd.Parameters.AddWithValue("@idActividad", idActividad);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    string queryDelete = "DELETE FROM Persona WHERE usuario = @usuario";
                    using (var cmd = new MySqlCommand(queryDelete, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
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
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
