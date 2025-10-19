using ClubDeportivo.Modelos;

namespace ClubDeportivo.Interfaces
{
    public interface IPersonaRepository
    {
        (int idPersona, string rol)? Ingresar(string usuario, string clave);

        int Registrar(Persona persona);
    }
}