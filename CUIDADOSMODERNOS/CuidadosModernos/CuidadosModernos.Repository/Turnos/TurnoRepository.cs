using CuidadosModernos.Domain.Horarios;
using EntityFramework.DbContextScope.Interfaces;
using System;
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

        public Turno ObtenerTurnoPorFechaIngreso(DateTime fechaIngreso)
        {
            return this.DbSet.FirstOrDefault(t => t.FechaHoraFin > fechaIngreso && t.FechaHoraRealInicio == null);
        }

        public Turno ObtenerTurnoAnterior(DateTime fechaIngreso)
        {
            return this.DbSet.Where(t => t.FechaHoraRealInicio < fechaIngreso)
                             .OrderByDescending(t => t.FechaHoraRealInicio)
                             .FirstOrDefault();
        }

        public List<Turno> ObtenerTurnosPorCumplir()
        {
            return this.DbSet.Where(t => t.FechaHoraFin >= System.DateTime.Now).ToList();
        }
    }
}
