using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Repositories
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
    }
}

