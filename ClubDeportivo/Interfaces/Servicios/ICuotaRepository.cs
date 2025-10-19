using System.Data;
using ClubDeportivo.Modelos;

namespace ClubDeportivo.Interfaces.Repositorios
{
    public interface ICuotaRepository
    {
        int RegistrarCuota(Cuota cuota);

        int RegistrarRenovacion(int idSocio, Cuota nuevaCuota);

        bool TieneCuotaPagada(int idSocio);

        bool TieneCuotaVigente(int idSocio);

        DataTable ObtenerCuotasPorSocio(int idSocio);

        Cuota ObtenerUltimaCuota(int idSocio);

        DataTable ObtenerCuotasVencidas();
    }
}