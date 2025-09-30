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

        public int RegistrarRenovacion(int idSocio, Cuota nuevaCuota)
        {
            var ultima = ObtenerUltimaCuota(idSocio);

            DateTime fechaVencimientoNueva;

            if (ultima != null && ultima.FechaVencimiento >= DateTime.Today)
            {
                fechaVencimientoNueva = ultima.FechaVencimiento.AddMonths(1);
            }
            else
            {
                fechaVencimientoNueva = DateTime.Today.AddMonths(1);
            }

            nuevaCuota.IdSocio = idSocio;
            nuevaCuota.FechaPago = DateTime.Today;
            nuevaCuota.FechaVencimiento = fechaVencimientoNueva;

            return RegistrarCuota(nuevaCuota);
        }


        public bool TieneCuotaPagada(int idSocio)
        {;
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

        public bool TieneCuotaVigente(int idSocio)
        {
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

        public Cuota ObtenerUltimaCuota(int idSocio)
        {
            using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
            {
                conn.Open();
                string query = @"SELECT id_cuota, id_socio, monto, fechaPago, fechaVencimiento, medioPago, promocion
                         FROM Cuota
                         WHERE id_socio = @idSocio
                         ORDER BY fechaVencimiento DESC
                         LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSocio", idSocio);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cuota(
                                reader.GetInt32("id_socio"),
                                reader.GetDecimal("monto"),
                                reader.GetDateTime("fechaPago"),
                                reader.GetDateTime("fechaVencimiento"),
                                reader.GetString("medioPago"),
                                reader.GetString("promocion")
                            )
                            {
                                IdCuota = reader.GetInt32("id_cuota")
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


