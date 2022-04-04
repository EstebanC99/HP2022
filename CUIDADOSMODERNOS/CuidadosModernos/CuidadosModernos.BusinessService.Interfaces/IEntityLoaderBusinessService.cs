using Cross.BusinessService.Interfaces;
using System.Linq;

namespace CuidadosModernos.BusinessService.Interfaces
{
    public interface IEntityLoaderBusinessService : IBusinessService
    {
        Entity GetByID<Entity>(int ID) where Entity : class;

        IQueryable<Entity> Query<Entity>() where Entity : class;
    }
}
