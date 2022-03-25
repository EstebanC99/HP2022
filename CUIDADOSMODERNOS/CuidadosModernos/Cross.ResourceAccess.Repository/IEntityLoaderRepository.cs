using System.Linq;

namespace Cross.ResourceAccess.Repository
{
    public interface IEntityLoaderRepository : IDataAccessBase
    {
        TEntity GetByID<TEntity>(int ID) where TEntity : class;

        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    }
}