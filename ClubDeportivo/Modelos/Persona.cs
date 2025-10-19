using ClubDeportivo.Interfaces.Modelos;
using System;
using System.Text.RegularExpressions;

namespace ClubDeportivo.Modelos
{
    public abstract class Persona : IPersona
    {
        private int idPersona;
        private string nombre;
        private string apellido;
        private string dni;
        private DateTime fechaNacimiento;
        private string usuario;
        private string clave;

        public int IdPersona
        {
            get => idPersona;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id de persona no puede ser negativo.");
                idPersona = value;
            }
        }

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
                nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get => apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El apellido no puede superar los 100 caracteres.");
                apellido = value.Trim();
            }
        }

        public string Dni
        {
            get => dni;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El DNI no puede estar vacío.");
                if (!Regex.IsMatch(value, @"^\d{7,8}$")) // 7 u 8 dígitos
                    throw new ArgumentException("El DNI debe tener entre 7 y 8 dígitos numéricos.");
                dni = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get => fechaNacimiento;
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura.");
                fechaNacimiento = value;
            }
        }

        public string Usuario
        {
            get => usuario;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El usuario no puede estar vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El usuario no puede superar los 50 caracteres.");
                usuario = value.Trim();
            }
        }

        public string Clave
        {
            get => clave;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La clave no puede estar vacía.");
                if (value.Length < 6)
                    throw new ArgumentException("La clave debe tener al menos 6 caracteres.");
                clave = value;
            }
        }

        protected Persona(string nombre, string apellido, string dni, DateTime fechaNacimiento, string usuario, string clave)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            FechaNacimiento = fechaNacimiento;
            Usuario = usuario;
            Clave = clave;
        }
    }
}
