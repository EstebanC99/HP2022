using EntityFramework.DbContextScope.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace Cross.ResourceAccess.Repository
{
    public abstract class EntityLoaderRepository<TDbContext> : DataAccessBase<TDbContext>, IEntityLoaderRepository
        where TDbContext : DbContext, IDbContext
    {
        protected EntityLoaderRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public TEntity GetByID<TEntity>(int ID)
            where TEntity : class
        {
            return this.DbContext.Set<TEntity>().Find(ID);
        }

        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : class
        {
            return this.DbContext.Set<TEntity>().AsQueryable();
        }
    }
}
