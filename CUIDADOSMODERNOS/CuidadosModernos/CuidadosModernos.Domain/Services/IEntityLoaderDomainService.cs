using Cross.Business.Domain;
using System.Linq;

namespace CuidadosModernos.Domain.Services
{
    public interface IEntityLoaderDomainService : IDomainService
    {
        Entity GetByID<Entity>(int ID) where Entity : class;

        IQueryable<Entity> Query<Entity>() where Entity : class;

        TEntity CreateEntity<TEntity>() where TEntity : Cross.Business.Domain.Entity;

        TAggregate CreateAggregate<TAggregate, TKey>() where TAggregate : Aggregate<TKey>;
    }
}
