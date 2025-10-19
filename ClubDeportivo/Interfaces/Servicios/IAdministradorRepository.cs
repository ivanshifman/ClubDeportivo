using System.Data;

namespace ClubDeportivo.Interfaces
{
    public interface IAdministradorRepository
    {
        DataTable ObtenerSocios();

        DataTable ObtenerNoSocios();

        void EliminarUsuarioPorUsuario(string usuario);
    }
}