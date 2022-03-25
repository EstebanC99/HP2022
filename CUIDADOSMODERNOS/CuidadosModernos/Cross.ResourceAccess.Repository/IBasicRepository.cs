using Cross.Business.Domain;
using Cross.Business.Domain.Queries;
using System.Collections.Generic;

namespace Cross.ResourceAccess.Repository
{
    public interface IBasicRepository<TCriteria, TKey> : IDataAccessBase
        where TCriteria : Criteria<TKey>
    {
        List<DataView> ReadAll();

        List<DataView> ReadViewByDependencyValues(List<TKey> values);

        List<DataView> ReadViewByCriteria(TCriteria criteria);

        List<DataView> ReadByPattern(TCriteria criteria);

        List<DataView> ReadByID(TKey ID);
    }

    public interface IBasicRepository<TEntity, TCriteria, TKey> :IBasicRepository<TCriteria, TKey>
        where TEntity : Entity<TKey>
        where TCriteria : Criteria<TKey>
    {
        TEntity ReadEntityByID(TKey ID);
    }
}