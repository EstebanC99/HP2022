using CuidadosModernos.Business.Domain.Queries.Usuarios;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Repository;

namespace CuidadosModernos.ResourceAccess.Repository.Usuarios.Login
{
    public interface ILoginUsuarioRepository : IBasicRepository<UsuarioCriteria>
    {
        Usuario GetUser(UsuarioCriteria criteria);
    }
}