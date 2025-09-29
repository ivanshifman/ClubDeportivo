using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;

namespace ClubDeportivo.Servicios
{
    public class SocioRepository : PersonaRepository
    {
        public int Registrar(Socio socio)
        {
            int idPersona = base.Registrar(socio);

            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string query = @"INSERT INTO Socio (id_persona, fechaAlta, fichaMedica, tieneCarnet)
                                 VALUES (@idPersona, @fechaAlta, @fichaMedica, @tieneCarnet)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    cmd.Parameters.AddWithValue("@fechaAlta", socio.FechaAlta);
                    cmd.Parameters.AddWithValue("@fichaMedica", socio.FichaMedica);
                    cmd.Parameters.AddWithValue("@tieneCarnet", socio.TieneCarnet);
                    cmd.ExecuteNonQuery();
                }
            }

            return idPersona;
        }


        public int ObtenerIdSocioPorIdPersona(int idPersona)
        {
            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string query = @"SELECT id_socio FROM Socio WHERE id_persona = @idPersona";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        throw new Exception("No se encontró el id_socio para esta persona.");
                }
            }
        }

        public Socio ObtenerSocioPorIdSocio(int idSocio)
        {
            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string query = @"SELECT p.*, s.fechaAlta, s.tieneCarnet, s.fichaMedica
                         FROM Persona p
                         INNER JOIN Socio s ON p.id_persona = s.id_persona
                         WHERE s.id_socio = @idSocio";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSocio", idSocio);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Socio(
                                reader.GetString("nombre"),
                                reader.GetString("apellido"),
                                reader.GetString("dni"),
                                reader.GetDateTime("fecha_nacimiento"),
                                reader.GetString("usuario"),
                                reader.GetString("clave"),
                                reader.GetDateTime("fechaAlta"),
                                reader.GetBoolean("tieneCarnet"),
                                reader.GetBoolean("fichaMedica")
                            )
                            {
                                IdPersona = reader.GetInt32("id_persona"),
                                IdSocio = idSocio
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


    }
}

