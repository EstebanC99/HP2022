using Cross.Business.Domain;
using Cross.Business.Domain.Queries;
using System.Collections.Generic;

namespace Cross.BusinessService.Interfaces
{
    public interface IBasicBusinessService<TCriteria, TKey> : IBusinessService
        where TCriteria : Criteria<TKey>
    {
        List<DataView> ReadAll();

        List<DataView> ReadByID(TKey ID);

        List<DataView> ReadByPattern(TCriteria criteria);

        List<DataView> ReadViewByCriteria(TCriteria criteria);

        List<DataView> ReadViewByDependencyValues(List<TKey> values);
    }

    public interface IBasicBusinessService<TEntity, TCriteria, TKey> : IBasicBusinessService<TCriteria, TKey>
        where TEntity : Entity<TKey>
        where TCriteria : Criteria<TKey>
    {
        TEntity ReadEntityByID(TKey ID);
    }
}
