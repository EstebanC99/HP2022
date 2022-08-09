using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.Domain.Factories.Turnos;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Services.Tareas;
using CuidadosModernos.Repository;
using CuidadosModernos.Repository.Turnos;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Turnos
{
    public class AsignarTareaTurnoLogic : BusinessLogic<Turno, ITurnoRepository>, IAsignarTareaTurnoBusinessService
    {
        private ITareaTurnoFactory TareaTurnoFactory { get; set; }
        private ITareaRepository TareaRepository { get; set; }

        public AsignarTareaTurnoLogic(IDbContextScopeFactory dbContextScopeFactory,
                                      Turno aggregate,
                                      ITurnoRepository repository,
                                      ITareaRepository tareaRepository,
                                      ITareaTurnoFactory tareaTurnoFactory)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.TareaRepository = tareaRepository;
            this.TareaTurnoFactory = tareaTurnoFactory;
        }

        public void Asignar()
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                foreach (var turno in this.Repository.ObtenerTurnosPorCumplir())
                {
                    var tareas = this.TareaRepository.ObtenerTareasPorHorario(turno.FechaHoraInicio.Date, turno.FechaHoraInicio.TimeOfDay, turno.FechaHoraFin.Date, turno.FechaHoraFin.TimeOfDay);

                    turno.AsignarTareas(tareas, this.TareaTurnoFactory);
                }

                context.SaveChanges();
            }
        }
    }
}
