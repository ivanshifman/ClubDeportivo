using ClubDeportivo.Database;
using ClubDeportivo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    public class PersonaRepository
    {
        public (int idPersona, string rol)? Ingresar(string usuario, string clave)
        {
            using (var sqlCon = ConexionDB.GetInstancia().CrearConexionMySQL())
            using (var comando = new MySqlCommand("IngresoLogin", sqlCon))
            {
                try
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("Usu", MySqlDbType.VarChar).Value = usuario;
                    comando.Parameters.Add("Pass", MySqlDbType.VarChar).Value = clave;

                    sqlCon.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32("id_persona");
                            string rol = reader.GetString("rol");
                            return (id, rol);
                        }
                        else
                        {
                            return null;
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
        }

        public int Registrar(Persona persona)
        {
            try
            {
                using (var conn = ConexionDB.GetInstancia().CrearConexionMySQL())
                {
                    conn.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM Persona 
                          WHERE usuario = @usuario OR dni = @dni";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@usuario", persona.Usuario);
                        checkCmd.Parameters.AddWithValue("@dni", persona.Dni);
                        var count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                            throw new Exception("Ya existe un usuario o DNI registrado con esos datos.");
                    }

                    string query = @"INSERT INTO Persona (nombre, apellido, dni, fecha_nacimiento, usuario, clave)
                             VALUES (@nombre, @apellido, @dni, @fechaNacimiento, @usuario, @clave);
                             SELECT LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                        cmd.Parameters.AddWithValue("@dni", persona.Dni);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@usuario", persona.Usuario);
                        cmd.Parameters.AddWithValue("@clave", persona.Clave);

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



    }
}
