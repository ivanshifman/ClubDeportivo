using ClubDeportivo.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ClubDeportivo.Servicios
{
    internal class PersonaRepository
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
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error de conexión: {ex.Message}",
                        "Error de Conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return null;
                }
            }
        }


    }
}
