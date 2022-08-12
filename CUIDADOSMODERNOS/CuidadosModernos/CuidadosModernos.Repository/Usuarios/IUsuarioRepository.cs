using Cross.ResourceAccess.Repository;
using CuidadosModernos.Domain.Usuarios;

namespace CuidadosModernos.ResourceAccess.Repository.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        Usuario GetByUsername(string username);
    }
}