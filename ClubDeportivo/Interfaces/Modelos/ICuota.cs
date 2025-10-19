using System;

namespace ClubDeportivo.Interfaces.Modelos
{
    public interface ICuota
    {
        int IdCuota { get; set; }
        int IdSocio { get; set; }
        decimal Monto { get; set; }
        DateTime FechaPago { get; set; }
        DateTime FechaVencimiento { get; set; }
        string MedioPago { get; set; }
        string Promocion { get; set; }
    }
}