using Cross.ResourceAccess.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Repository
{
    public class EntityLoaderRepository : EntityLoaderRepository<CuidadosModernosDbContext>, IEntityLoaderRepository
    {
        public EntityLoaderRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {

        }
    }
}
