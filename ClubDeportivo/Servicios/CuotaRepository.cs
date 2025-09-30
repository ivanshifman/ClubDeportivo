using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    public class CuotaRepository
    {
        public int RegistrarCuota(Cuota cuota)
        {
            if (cuota == null) throw new ArgumentNullException(nameof(cuota));

            try
            {
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

        public int RegistrarRenovacion(int idSocio, Cuota nuevaCuota)
        {
            try
            {
                var ultima = ObtenerUltimaCuota(idSocio);
                DateTime fechaVencimientoNueva = (ultima != null && ultima.FechaVencimiento >= DateTime.Today)
                                                 ? ultima.FechaVencimiento.AddMonths(1)
                                                 : DateTime.Today.AddMonths(1);

                nuevaCuota.IdSocio = idSocio;
                nuevaCuota.FechaPago = DateTime.Today;
                nuevaCuota.FechaVencimiento = fechaVencimientoNueva;

                return RegistrarCuota(nuevaCuota);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la renovación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool TieneCuotaPagada(int idSocio)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar cuota pagada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool TieneCuotaVigente(int idSocio)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar cuota vigente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public Cuota ObtenerUltimaCuota(int idSocio)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la última cuota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


    }
}


