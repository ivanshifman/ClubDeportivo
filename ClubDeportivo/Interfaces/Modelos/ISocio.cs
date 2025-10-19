using System;

namespace ClubDeportivo.Interfaces.Modelos
{
    public interface ISocio : IPersona
    {
        int IdSocio { get; set; }
        DateTime FechaAlta { get; set; }
        bool TieneCarnet { get; set; }
        bool FichaMedica { get; set; }
    }
}