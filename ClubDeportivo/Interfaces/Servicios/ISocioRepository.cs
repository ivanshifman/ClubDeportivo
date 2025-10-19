using ClubDeportivo.Modelos;

namespace ClubDeportivo.Interfaces
{
    public interface ISocioRepository : IPersonaRepository
    {
        int Registrar(Socio socio);

        int ObtenerIdSocioPorIdPersona(int idPersona);

        Socio ObtenerSocioPorIdSocio(int idSocio);

        Socio VerCarnet(int idSocio);

        void ActualizarSocio(Socio socio);
    }
}