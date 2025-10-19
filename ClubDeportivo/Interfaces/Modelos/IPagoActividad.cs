using System;

namespace ClubDeportivo.Interfaces.Modelos
{
    public interface IPagoActividad
    {
        int IdPagoActividad { get; set; }
        int IdNoSocio { get; set; }
        int IdActividad { get; set; }
        DateTime Fecha { get; set; }
        decimal MontoAPagar { get; set; }
        string MetodoPago { get; set; }
    }
}