using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.ResourceAccess.Repository.Turnos
{
    public class TareaTurnoRepository : Repository<TareaTurno>, ITareaTurnoRepository
    {
        public TareaTurnoRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }


    }
}
