using System;

namespace ClubDeportivo.Interfaces.Modelos
{
    public interface IPersona
    {
        int IdPersona { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Dni { get; set; }
        DateTime FechaNacimiento { get; set; }
        string Usuario { get; set; }
        string Clave { get; set; }
    }
}