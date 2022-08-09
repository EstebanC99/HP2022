using CuidadosModernos.Domain.Horarios;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CuidadosModernos.Repository.Turnos
{
    public class TurnoRepository : Repository<Turno, int>, ITurnoRepository
    {
        public TurnoRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public List<Turno> ObtenerTurnosPorCumplir()
        {
            return this.DbSet.Where(t => t.FechaHoraFin >= System.DateTime.Now).ToList();
        }
    }
}
