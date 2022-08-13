using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.Usuarios.Rol;

namespace CuidadosModernos.Domain.Services
{
    public interface IAdministrarUsuarioDomainService : IDomainService
    {
        void RegistrarUsuario(string username, string password, Persona persona, RolUsuario rolUsuario, bool esModificacion);
    }
}
