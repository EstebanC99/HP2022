using Cross.Business.Domain;
using Cross.ResourceAccess.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic
{
    public abstract class BusinessLogic<TAggregate, TRepository> : Cross.Business.Logic.BusinessLogic<TAggregate, TRepository, int>
        where TAggregate : Aggregate<int>
        where TRepository : IRepository<TAggregate, int>
    {
        protected BusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TAggregate aggregate, TRepository repository)
            : base(dbContextScopeFactory, aggregate, repository)
        {

        }
    }
}
