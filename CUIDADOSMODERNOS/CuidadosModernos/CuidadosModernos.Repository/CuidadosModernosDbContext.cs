using CuidadosModernos.Repository.Config;
using EntityFramework.DbContextScope.Interfaces;
using System.Data.Entity;
using System.Reflection;

namespace CuidadosModernos.Repository
{
    public class CuidadosModernosDbContext : DbContext, IDbContext
    {
        private const string DATA_BASE_COMMAND_TIMEOUT_KEY = "DataBaseCommandTimeout";

        public CuidadosModernosDbContext() : base("Name=CuidadosModernosDb")
        {
            var commandTimeoutValue = System.Configuration.ConfigurationManager.AppSettings[DATA_BASE_COMMAND_TIMEOUT_KEY];
            int timeout;
            if (int.TryParse(commandTimeoutValue, out timeout))
            {
                this.Database.CommandTimeout = timeout;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(DummyConfig)));
        }
    }
}
