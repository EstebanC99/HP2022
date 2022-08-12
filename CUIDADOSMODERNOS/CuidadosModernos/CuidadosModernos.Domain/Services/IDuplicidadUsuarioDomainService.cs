using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;

namespace CuidadosModernos.Domain.Services
{
    public interface IDuplicidadUsuarioDomainService : IDomainService
    {
        Usuario ExisteUsuario(string username);
    }
}
