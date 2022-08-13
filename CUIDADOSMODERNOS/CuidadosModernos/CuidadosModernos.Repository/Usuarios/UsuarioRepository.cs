using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;
using System.Linq;

namespace CuidadosModernos.ResourceAccess.Repository.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public Usuario GetByUsername(string username)
        {
            return this.DbSet.Where(u => u.Username == username && u.Activo).FirstOrDefault();
        }
    }
}
