using System;

namespace ClubDeportivo.Modelos
{
    public class NoSocio : Persona
    {
        private int idNoSocio;
        public int IdNoSocio
        {
            get => idNoSocio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id del no socio no puede ser negativo.");
                idNoSocio = value;
            }
        }

        public NoSocio(string nombre, string apellido, string dni, DateTime fechaNacimiento, string usuario, string clave)
            : base(nombre, apellido, dni, fechaNacimiento, usuario, clave)
        {
        }
    }
}

