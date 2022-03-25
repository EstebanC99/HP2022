using Cross.Business.Domain.Queries;
using CuidadosModernos.Domain;

namespace CuidadosModernos.Repository
{
    public interface IBasicRepository<TCriteria> : Cross.ResourceAccess.Repository.IBasicRepository<TCriteria, int>
        where TCriteria : Criteria
    {

    }

    public interface IBasicRepository<TEntity, TCriteria> : IBasicRepository<TCriteria>, Cross.ResourceAccess.Repository.IBasicRepository<TEntity, TCriteria, int>
        where TEntity : Entity
        where TCriteria : Criteria
    {

    }
}