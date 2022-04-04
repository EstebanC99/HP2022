using Cross.Business.Logic;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Linq;

namespace CuidadosModernos.Business.Logic
{
    public sealed class EntityLoaderLogic : BusinessLogic<IEntityLoaderRepository>, IEntityLoaderBusinessService, IEntityLoaderDomainService
    {
        public EntityLoaderLogic(IDbContextScopeFactory dbContextScopeFactory, IEntityLoaderRepository repository)
            : base(dbContextScopeFactory, repository)
        {

        }

        public Entity GetByID<Entity>(int ID)
            where Entity : class
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.GetByID<Entity>(ID);
            }
        }

        public IQueryable<Entity> Query<Entity>()
            where Entity : class
        {
            return this.Repository.Query<Entity>();
        }

        public TEntity CreateEntity<TEntity>()
            where TEntity : Cross.Business.Domain.Entity
        {
            return Activator.CreateInstance<TEntity>();
        }

        public TAggregate CreateAggregate<TAggregate, TKey>()
            where TAggregate : Cross.Business.Domain.Aggregate<TKey>
        {
            return Activator.CreateInstance<TAggregate>();
        }
    }
}
