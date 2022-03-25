using Cross.Business.Domain;
using Cross.Business.Domain.Queries;
using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;

namespace Cross.ResourceAccess.Repository
{
    public abstract class BasicRepository<TDbContext, TCriteria, TKey> : DataAccessBase<TDbContext>, IBasicRepository<TCriteria, TKey>
        where TDbContext : class, IDbContext
        where TCriteria : Criteria<TKey>
    {
        protected BasicRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        { }

        public virtual List<DataView> ReadAll()
        {
            throw new NotImplementedException();
        }

        public virtual List<DataView> ReadByID(TKey ID)
        {
            throw new NotImplementedException();
        }

        public virtual List<DataView> ReadByPattern(TCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public virtual List<DataView> ReadViewByCriteria(TCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public virtual List<DataView> ReadViewByDependencyValues(List<TKey> values)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class BasicRepository<TDbContext, TEntity, TCriteria, TKey> : BasicRepository<TDbContext, TCriteria, TKey>, IBasicRepository<TEntity, TCriteria, TKey>
        where TDbContext : class, IDbContext
        where TEntity : Entity<TKey>
        where TCriteria : Criteria<TKey>
    {
        protected BasicRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public virtual TEntity ReadEntityByID(TKey ID)
        {
            throw new NotImplementedException();
        }
    }
}
