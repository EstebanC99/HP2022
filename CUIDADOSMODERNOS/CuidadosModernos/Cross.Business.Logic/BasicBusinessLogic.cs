using Cross.Business.Domain;
using Cross.Business.Domain.Queries;
using Cross.BusinessService.Interfaces;
using Cross.ResourceAccess.Repository;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;

namespace Cross.Business.Logic
{
    public abstract class BasicBusinessLogic<TCriteria, TRepository, TKey> : BusinessLogic<TRepository>, IBasicBusinessService<TCriteria, TKey>
        where TCriteria : Criteria<TKey>
        where TRepository : IBasicRepository<TCriteria, TKey>
    {
        protected BasicBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TRepository repository)
            : base(dbContextScopeFactory, repository)
        {

        }

        public virtual List<DataView> ReadAll()
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.ReadAll();
            }
        }

        public virtual List<DataView> ReadByID(TKey ID)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.ReadByID(ID);
            }
        }

        public virtual List<DataView> ReadByPattern(TCriteria criteria)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.ReadByPattern(criteria);
            }
        }

        public virtual List<DataView> ReadViewByCriteria(TCriteria criteria)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.ReadViewByCriteria(criteria);
            }
        }

        public virtual List<DataView> ReadViewByDependencyValues(List<TKey> values)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.ReadViewByDependencyValues(values);
            }
        }
    }

    public abstract class BasicBusinessLogic<TEntity, TCriteria, TRepository, TKey> : BasicBusinessLogic<TCriteria, TRepository, TKey>, IBasicBusinessService<TEntity, TCriteria, TKey>
        where TEntity : Entity<TKey>
        where TCriteria : Criteria<TKey>
        where TRepository : IBasicRepository<TEntity, TCriteria, TKey>
    {
        protected BasicBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, TRepository repository)
            : base(dbContextScopeFactory, repository)
        {

        }

        public virtual TEntity ReadEntityByID(TKey ID)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.ReadEntityByID(ID);
            }
        }
    }
}
