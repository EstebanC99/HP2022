using Cross.Crosscutting.Globalization;
using EntityFramework.DbContextScope.Interfaces;
using System;

namespace Cross.ResourceAccess.Repository
{
    public abstract class DataAccessBase<TDbContext> : IDataAccessBase
        where TDbContext : class, IDbContext
    {
        private readonly IAmbientDbContextLocator ambientDbContextLocator;

        protected TDbContext DbContext
        {
            get
            {
                var dbContext = this.ambientDbContextLocator.Get<TDbContext>();

                if (DbContext == null)
                    throw new InvalidOperationException(Messages.NoAmbientDbContextLocator);

                return dbContext;
            }
        }

        protected DataAccessBase(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
                throw new ArgumentNullException(nameof(ambientDbContextLocator));

            this.ambientDbContextLocator = ambientDbContextLocator;
        }
    }
}
