using Cross.Business.Domain.Queries;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.Domain;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic
{
    public abstract class BasicBusinessLogic<TCriteria, TRepository> : Cross.Business.Logic.BasicBusinessLogic<TCriteria, TRepository, int>, IBasicBusinessService<TCriteria>
        where TCriteria : Criteria
        where TRepository : IBasicRepository<TCriteria>
    {
        protected BasicBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TRepository repository)
            : base(dbContextScopeFactory, repository)
        {

        }
    }

    public abstract class BasicBusinessLogic<TEntity, TCriteria, TRepository> : Cross.Business.Logic.BasicBusinessLogic<TEntity, TCriteria, TRepository, int>, IBasicBusinessService<TEntity, TCriteria>
        where TEntity : Entity
        where TCriteria : Criteria
        where TRepository : IBasicRepository<TEntity, TCriteria>
    {
        protected BasicBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TRepository repository)
            : base(dbContextScopeFactory, repository)
        {

        }
    }
}
