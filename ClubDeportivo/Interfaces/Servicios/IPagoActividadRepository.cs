using ClubDeportivo.Modelos;

namespace ClubDeportivo.Interfaces.Repositorios
{
    public interface IPagoActividadRepository
    {
        int RegistrarPago(PagoActividad pago);

        bool YaPagoActividad(int idNoSocio, int idActividad);
    }
}
