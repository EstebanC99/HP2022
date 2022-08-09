using CuidadosModernos.CrossCutting.Global;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Domain.Turnos;

namespace CuidadosModernos.Domain.Factories.Turnos
{
    public class TareaTurnoFactory : ITareaTurnoFactory
    {
        private IEntityLoaderDomainService EntityLoaderDomainService { get; set; }

        public TareaTurnoFactory(IEntityLoaderDomainService entityLoaderDomainService)
        {
            this.EntityLoaderDomainService = entityLoaderDomainService;
        }

        public TareaTurno Crear(Turno turno, Tarea tarea)
        {
            var estado = this.EntityLoaderDomainService.GetByID<EstadoTareaTurno>(EstadosTareaTurno.Asignada);

            return new TareaTurno(turno, tarea, estado);
        }
    }
}
