using ClubDeportivo.Modelos;

namespace ClubDeportivo.Interfaces
{
    public interface INoSocioRepository : IPersonaRepository
    {
        int Registrar(NoSocio noSocio);

        int ObtenerIdNoSocioPorIdPersona(int idPersona);

        NoSocio ObtenerNoSocioPorIdNoSocio(int idNoSocio);

        void ActualizarNoSocio(NoSocio noSocio);
    }
}