using System;

namespace ClubDeportivo.Modelos
{
    public class Socio : Persona
    {
        private int idSocio;
        private DateTime fechaAlta;
        private bool tieneCarnet;
        private bool fichaMedica;

        public int IdSocio
        {
            get => idSocio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id del socio no puede ser negativo.");
                idSocio = value;
            }
        }

        public DateTime FechaAlta
        {
            get => fechaAlta;
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException("La fecha de alta no puede ser futura.");
                fechaAlta = value;
            }
        }

        public bool TieneCarnet
        {
            get => tieneCarnet;
            set => tieneCarnet = value;
        }

        public bool FichaMedica
        {
            get => fichaMedica;
            set => fichaMedica = value;
        }

        public Socio(string nombre, string apellido, string dni, DateTime fechaNacimiento, string usuario, string clave,
                     DateTime fechaAlta, bool tieneCarnet = true, bool fichaMedica = false)
            : base(nombre, apellido, dni, fechaNacimiento, usuario, clave)
        {
            FechaAlta = fechaAlta;
            TieneCarnet = tieneCarnet;
            FichaMedica = fichaMedica;
        }

    }
}

