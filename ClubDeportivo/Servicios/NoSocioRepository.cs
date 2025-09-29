using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Servicios
{
    public class NoSocioRepository : PersonaRepository
    {
        public int Registrar(NoSocio noSocio)
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
                }
            }

            return idPersona;
        }
    }
}

