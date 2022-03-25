using System.Data.Entity;

namespace CuidadosModernos.Repository
{
    public class CuidadosModernosDbContextConfiguration : DbConfiguration
    {
        public CuidadosModernosDbContextConfiguration()
        {
            this.AddInterceptor(new SessionContextInterceptor());
        }
    }
}
