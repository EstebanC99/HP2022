using Cross.Business.Domain;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace Cross.ResourceAccess.Repository
{
    public abstract class Repository<TDbContext, TAggregate, TKey> : DataAccessBase<TDbContext>, IRepository<TAggregate, TKey>
        where TDbContext : DbContext, IDbContext
        where TAggregate : class, IIdentificable<TKey>
    {
        protected DbSet<TAggregate> DbSet
        {
            get { return this.DbContext.Set<TAggregate>(); }
        }

        protected Repository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public virtual TAggregate GetByID(TKey ID)
        {
            return this.DbSet.Find(ID);
        }

        public virtual void Add(TAggregate aggregate)
        {
            this.DbSet.Add(aggregate);
        }

        public void AddRange(IEnumerable<TAggregate> aggregates)
        {
            this.DbSet.AddRange(aggregates);
        }

        public virtual void Remove(TKey ID)
        {
            this.DbSet.Remove(this.GetByID(ID));
        }

        public virtual void Remove(TAggregate aggregate)
        {
            this.DbSet.Remove(aggregate);
        }

        public void RemoveRange(IEnumerable<TAggregate> aggregates)
        {
            this.DbSet.RemoveRange(aggregates);
        }
    }
}
