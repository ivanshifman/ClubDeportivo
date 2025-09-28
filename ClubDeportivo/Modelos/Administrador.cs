using System;

namespace ClubDeportivo.Modelos
{
    public class Administrador : Persona
    {
        private int idAdmin;

        public int IdAdmin
        {
            get => idAdmin;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id del administrador no puede ser negativo.");
                idAdmin = value;
            }
        }

        public Administrador(string nombre, string apellido, string dni, DateTime fechaNacimiento, string usuario, string clave)
            : base(nombre, apellido, dni, fechaNacimiento, usuario, clave)
        {
        }
    }
}
