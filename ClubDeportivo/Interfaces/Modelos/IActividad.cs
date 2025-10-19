using System;

namespace ClubDeportivo.Interfaces.Modelos
{
    public interface IActividad
    {
        int IdActividad { get; set; }
        string Nombre { get; set; }
        string Tipo { get; set; }
        string Profesor { get; set; }
        DateTime Horario { get; set; }
        int Capacidad { get; set; }
        decimal Costo { get; set; }
        string NombreConHorario { get; }
    }
}