using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Repository
{
    public class CuidadosModernosDbContextFactory : IDbContextFactory
    {
        public TDbContext CreateDbContext<TDbContext>()
            where TDbContext : class, IDbContext
        {
            return new CuidadosModernosDbContext() as TDbContext;
        }
    }
}
