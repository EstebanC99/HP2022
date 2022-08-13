using CuidadosModernos.Business.Domain.Queries.Usuarios;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;
using System.Linq;

namespace CuidadosModernos.ResourceAccess.Repository.Usuarios.Login
{
    public class LoginUsuarioRepository : BasicRepository<UsuarioCriteria>, ILoginUsuarioRepository
    {
        public LoginUsuarioRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {

        }

        public Usuario GetUser(UsuarioCriteria criteria)
        {
            return this.DbContext.Set<Usuario>().FirstOrDefault(u => u.Username == criteria.Username
                                                        && u.Password == criteria.Password
                                                        && u.Activo);
        }
    }
}
