using EntityFramework.DbContextScope.Interfaces;

namespace Cross.Business.Logic
{
    public static class DbContextScopeFactoryExtensions
    {
        public static IDbContextReadOnlyScope CreateReadOnlyWithTransaction(this IDbContextScopeFactory dbContextScopeFactory)
        {
            return dbContextScopeFactory.CreateReadOnlyWithTransaction(System.Data.IsolationLevel.Unspecified);
        }

        public static IDbContextScope CreateWithTransaction(this IDbContextScopeFactory dbContextScopeFactory)
        {
            return dbContextScopeFactory.CreateWithTransaction(System.Data.IsolationLevel.Unspecified);
        }
    }
}
