using Cross.Business.Domain;
using Cross.ResourceAccess.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Repository
{
    public abstract class Repository : DataAccessBase<CuidadosModernosDbContext>
    {
        protected Repository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        { }
    }

    public abstract class Repository<TAggregate, TKey> : Repository<CuidadosModernosDbContext, TAggregate, TKey>
        where TAggregate : class, IIdentificable<TKey>
    {
        protected Repository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        { }
    }

    public abstract class Repository<TAggregate> : Repository<TAggregate, int>
        where TAggregate : class, IIdentificable<int>
    {
        protected Repository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        { }
    }
}
