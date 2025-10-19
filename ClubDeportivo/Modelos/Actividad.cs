using ClubDeportivo.Interfaces.Modelos;
using System;

namespace ClubDeportivo.Modelos
{
    public class Actividad : IActividad
    {
        private int idActividad;
        private string nombre;
        private string tipo;
        private string profesor;
        private DateTime horario;
        private int capacidad;
        private decimal costo;

        public int IdActividad
        {
            get => idActividad;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id de la actividad no puede ser negativo.");
                idActividad = value;
            }
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("El nombre no puede estar vacío.")
                : value;
        }

        public string Tipo
        {
            get => tipo;
            set => tipo = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("El tipo no puede estar vacío.")
                : value;
        }

        public string Profesor
        {
            get => profesor;
            set => profesor = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("El profesor no puede estar vacío.")
                : value;
        }

        public DateTime Horario
        {
            get => horario;
            set => horario = value;
        }

        public int Capacidad
        {
            get => capacidad;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La capacidad no puede ser negativa.");
                capacidad = value;
            }
        }

        public decimal Costo
        {
            get => costo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo no puede ser negativo.");
                costo = value;
            }
        }

        public string NombreConHorario
        {
            get => $"{Nombre} - {Horario:dd/MM/yyyy HH:mm}";
        }

    }
}

