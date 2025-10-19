using System.Collections.Generic;
using ClubDeportivo.Modelos;

namespace ClubDeportivo.Interfaces.Repositorios
{
    public interface IActividadRepository
    {
        List<Actividad> ObtenerTodasActividades();

        void ReducirCapacidad(int idActividad);

        bool VerificarDisponibilidad(int idActividad);

        bool EstaInscripto(int idNoSocio, int idActividad);

        bool AgregarActividad(Actividad actividad);
    }
}
