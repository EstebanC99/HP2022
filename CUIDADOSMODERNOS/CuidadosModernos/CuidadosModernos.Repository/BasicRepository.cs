using Cross.Business.Domain.Queries;
using Cross.ResourceAccess.Repository;
using CuidadosModernos.Domain;
using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CuidadosModernos.Repository
{
    public class BasicRepository<TCriteria> : BasicRepository<CuidadosModernosDbContext, TCriteria, int>, IBasicRepository<TCriteria>
        where TCriteria : Criteria
    {
        protected BasicRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }
    }

    public abstract class BasicRepository<TEntity, TCriteria> : BasicRepository<CuidadosModernosDbContext, TEntity, TCriteria, int>, IBasicRepository<TEntity, TCriteria>
        where TEntity : Entity
        where TCriteria : Criteria
    {
        protected DbSet<TEntity> DbSet
        {
            get { return this.DbContext.Set<TEntity>(); }
        }

        protected BasicRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public override List<DataView> ReadAll()
        {
            return this.DbSet.Select(this.ParseToDataView).ToList();
        }

        public override List<DataView> ReadByID(int ID)
        {
            return this.DbSet.Where(e => e.ID == ID).Select(this.ParseToDataView).ToList();
        }

        public override TEntity ReadEntityByID(int ID)
        {
            return this.DbSet.Find(ID);
        }

        protected Expression<Func<TEntity, DataView>> ParseToDataView = d =>
            new DataView()
            {
                ID = d.ID,
                Descripcion = d.Descripcion
            };
    }
}
