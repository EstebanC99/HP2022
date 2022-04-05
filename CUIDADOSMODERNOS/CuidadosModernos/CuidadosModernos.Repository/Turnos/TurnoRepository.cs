using CuidadosModernos.Domain.Horarios;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Repository.Turnos
{
    public class TurnoRepository : Repository<Turno, int>, ITurnoRepository
    {
        public TurnoRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }
    }
}
