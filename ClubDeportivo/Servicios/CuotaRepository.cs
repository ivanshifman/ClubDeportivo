using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;

namespace ClubDeportivo.Servicios
{
    public class CuotaRepository
    {
        public int RegistrarCuota(Cuota cuota)
        {
            if (cuota == null) throw new ArgumentNullException(nameof(cuota));

            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string query = @"INSERT INTO Cuota (id_socio, monto, fechaPago, fechaVencimiento, medioPago, promocion)
                                 VALUES (@idSocio, @monto, @fechaPago, @fechaVencimiento, @medioPago, @promocion);
                                 SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSocio", cuota.IdSocio);
                    cmd.Parameters.AddWithValue("@monto", cuota.Monto);
                    cmd.Parameters.AddWithValue("@fechaPago", cuota.FechaPago);
                    cmd.Parameters.AddWithValue("@fechaVencimiento", cuota.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@medioPago", cuota.MedioPago);
                    cmd.Parameters.AddWithValue("@promocion", cuota.Promocion);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int RegistrarCuotaParaPersona(int idSocio, Cuota cuota)
        {
            cuota.IdSocio = idSocio;
            return RegistrarCuota(cuota);
        }

        public bool TieneCuotaPagadaPorPersona(int idPersona)
        {
            var idSocio = new ClubDeportivo.Servicios.SocioRepository().ObtenerIdSocioPorIdPersona(idPersona);

            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string q = "SELECT COUNT(*) FROM Cuota WHERE id_socio = @idSocio";
                using (var cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@idSocio", idSocio);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool TieneCuotaVigentePorPersona(int idPersona)
        {
            var idSocio = new ClubDeportivo.Servicios.SocioRepository().ObtenerIdSocioPorIdPersona(idPersona);

            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string q = @"SELECT COUNT(*) FROM Cuota 
                             WHERE id_socio = @idSocio AND fechaVencimiento >= CURDATE()";
                using (var cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@idSocio", idSocio);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}


