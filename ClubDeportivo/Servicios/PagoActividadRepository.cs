using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    public class PagoActividadRepository
    {
        public int RegistrarPago(PagoActividad pago)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM nosocio WHERE id_noSocio = @idNoSocio";
                    using (var cmdCheck = new MySqlCommand(checkQuery, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@idNoSocio", pago.IdNoSocio);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count == 0)
                            throw new Exception("No existe el NoSocio con ese ID.");
                    }

                    string query = @"INSERT INTO PagoActividad (id_noSocio, id_actividad, fecha, montoAPagar, metodoPago)
                             VALUES (@idNoSocio, @idActividad, @fecha, @monto, @metodo)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idNoSocio", pago.IdNoSocio);
                        cmd.Parameters.AddWithValue("@idActividad", pago.IdActividad);
                        cmd.Parameters.AddWithValue("@fecha", pago.Fecha);
                        cmd.Parameters.AddWithValue("@monto", pago.MontoAPagar);
                        cmd.Parameters.AddWithValue("@metodo", pago.MetodoPago);

                        return cmd.ExecuteNonQuery();
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


        public bool YaPagoActividad(int idNoSocio, int idActividad)
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

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar pago previo: {ex.Message}");
                return false;
            }
        }

    }
}

