using System;

namespace ClubDeportivo.Modelos
{
    public class Cuota
    {
        private int idCuota;
        private int idSocio;
        private decimal monto;
        private DateTime fechaPago;
        private DateTime fechaVencimiento;
        private string medioPago;
        private string promocion;

        public int IdCuota
        {
            get => idCuota;
            set
            {
                if (value < 0) throw new ArgumentException("El id de la cuota no puede ser negativo.");
                idCuota = value;
            }
        }

        public int IdSocio
        {
            get => idSocio;
            set
            {
                if (value <= 0) throw new ArgumentException("El id del socio debe ser mayor que cero.");
                idSocio = value;
            }
        }

        public decimal Monto
        {
            get => monto;
            set
            {
                if (value <= 0) throw new ArgumentException("El monto debe ser mayor que 0.");
                monto = decimal.Round(value, 2);
            }
        }

        public DateTime FechaPago
        {
            get => fechaPago;
            set
            {
                if (value.Date > DateTime.Today) throw new ArgumentException("La fecha de pago no puede ser posterior a la fecha actual.");
                fechaPago = value.Date;
            }
        }

        public DateTime FechaVencimiento
        {
            get => fechaVencimiento;
            set
            {
                if (fechaPago != default && value.Date < fechaPago.Date)
                    throw new ArgumentException("La fecha de vencimiento no puede ser anterior a la fecha de pago.");
                fechaVencimiento = value.Date;
            }
        }

        public string MedioPago
        {
            get => medioPago;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El medio de pago es obligatorio.");
                if (value.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
                    medioPago = "Efectivo";
                else if (value.Equals("Tarjeta", StringComparison.OrdinalIgnoreCase))
                    medioPago = "Tarjeta";
                else
                    throw new ArgumentException("Medio de pago inválido. Debe ser 'Efectivo' o 'Tarjeta'.");
            }
        }

        public string Promocion
        {
            get => promocion;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("La promoción no puede estar vacía. Use '0','3' o '6'.");
                var v = value.Trim();
                if (v != "0" && v != "3" && v != "6")
                    throw new ArgumentException("Promoción inválida. Sólo '0', '3' o '6'.");

                if (!string.IsNullOrEmpty(medioPago) && medioPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase) && v != "0")
                    throw new ArgumentException("Con pago en Efectivo la promoción debe ser '0'.");

                promocion = v;
            }
        }

        public Cuota(int idSocio, decimal monto, DateTime fechaPago, DateTime? fechaVencimiento, string medioPago, string promocion)
        {
            IdSocio = idSocio;
            MedioPago = medioPago;           
            FechaPago = fechaPago;  
            FechaVencimiento = fechaVencimiento ?? FechaPago.AddMonths(1);
            Promocion = promocion;
            Monto = monto;
        }
    }
}

