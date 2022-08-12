using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;

namespace CuidadosModernos.Domain.Services
{
    public interface IAdministrarUsuarioDomainService : IDomainService
    {
        void RegistrarUsuario(string username, string password, Persona persona);
    }
}
