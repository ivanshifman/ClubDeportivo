using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
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

        public DataTable ObtenerCuotasPorSocio(int idSocio)
        {
            var tabla = new DataTable();

            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    string query = @"
                SELECT fechaPago, fechaVencimiento, monto, medioPago, promocion
                FROM Cuota
                WHERE id_socio = @idSocio
                ORDER BY fechaPago DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idSocio", idSocio);

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

        public DataTable ObtenerCuotasVencidas()
        {
            var tabla = new DataTable();

            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    string query = @"
                SELECT p.nombre, p.apellido, p.dni,
                       c.fechaPago, c.fechaVencimiento, c.monto,
                       c.medioPago, c.promocion
                FROM Cuota c
                INNER JOIN Socio s ON c.id_socio = s.id_socio
                INNER JOIN Persona p ON s.id_persona = p.id_persona
                WHERE c.fechaVencimiento < CURDATE()";

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



    }
}


