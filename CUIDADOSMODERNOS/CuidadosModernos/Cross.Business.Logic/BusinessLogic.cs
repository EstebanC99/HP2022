using Cross.Business.Domain;
using Cross.BusinessService.Interfaces;
using Cross.ResourceAccess.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace Cross.Business.Logic
{
    /// <summary>
    /// Logica de negocio
    /// </summary>
    public abstract class BusinessLogic : IBusinessService
    {
        protected BusinessLogic()
        {

        }
    }

    /// <summary>
    /// Logica de negocio que utiliza un Repositorio
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    public abstract class BusinessLogic<TRepository> : BusinessLogic
        where TRepository : IDataAccessBase
    {
        protected IDbContextScopeFactory DbContextScopeFactory { get; private set; }

        protected TRepository Repository { get; private set; }

        protected BusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TRepository repository)
        {
            this.DbContextScopeFactory = dbContextScopeFactory;
            this.Repository = repository;
        }
    }

    /// <summary>
    /// Logica de negocio que utiliza un Repositorio y su Aggregate
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BusinessLogic<TAggregate, TRepository, TKey> : BusinessLogic<TRepository>
        where TAggregate : Aggregate<TKey>
        where TRepository : IRepository<TAggregate, TKey>
    {
        protected TAggregate Aggregate { get; set; }

        protected BusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TAggregate aggregate, TRepository repository)
            : base(dbContextScopeFactory, repository)
        {
            this.Aggregate = aggregate;
        }
    }


}
