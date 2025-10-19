using ClubDeportivo.Interfaces.Modelos;
using System;

namespace ClubDeportivo.Modelos
{
    public class PagoActividad : IPagoActividad
    {
        private int idPagoActividad;
        private int idNoSocio;
        private int idActividad;
        private DateTime fecha;
        private decimal montoAPagar;
        private string metodoPago;

        public int IdPagoActividad
        {
            get => idPagoActividad;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El id de pago de actividad no puede ser negativo.");
                idPagoActividad = value;
            }
        }

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

        public DateTime Fecha
        {
            get => fecha;
            set => fecha = value;
        }

        public decimal MontoAPagar
        {
            get => montoAPagar;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El monto no puede ser negativo.");
                montoAPagar = value;
            }
        }

        public string MetodoPago
        {
            get => metodoPago;
            set => metodoPago = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("El método de pago es obligatorio.")
                : value;
        }
    }
}

