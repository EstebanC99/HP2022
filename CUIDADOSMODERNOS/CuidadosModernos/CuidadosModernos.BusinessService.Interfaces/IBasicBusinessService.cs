using Cross.Business.Domain.Queries;
using CuidadosModernos.Domain;

namespace CuidadosModernos.BusinessService.Interfaces
{
    public interface IBasicBusinessService<TCriteria> : Cross.BusinessService.Interfaces.IBasicBusinessService<TCriteria, int>
        where TCriteria : Criteria
    {

    }

    public interface IBasicBusinessService<TEntity, TCriteria> : IBasicBusinessService<TCriteria>, Cross.BusinessService.Interfaces.IBasicBusinessService<TEntity, TCriteria, int>
        where TEntity : Entity
        where TCriteria : Criteria
    {

    }
}
