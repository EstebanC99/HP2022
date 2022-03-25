using Cross.Business.Domain;
using System.Collections.Generic;

namespace Cross.ResourceAccess.Repository
{
    public interface IRepository<TAggregate, TKey> : IDataAccessBase
        where TAggregate : IIdentificable<TKey>
    {
        TAggregate GetByID(TKey ID);

        void Add(TAggregate aggregate);

        void AddRange(IEnumerable<TAggregate> aggregates);

        void Remove(TKey ID);

        void Remove(TAggregate aggregate);

        void RemoveRange(IEnumerable<TAggregate> aggregates);
    }
}