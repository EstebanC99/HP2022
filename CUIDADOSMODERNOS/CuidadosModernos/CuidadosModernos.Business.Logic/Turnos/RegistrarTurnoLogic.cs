using Cross.Business.Logic;
using CuidadosModernos.Business.Domain.Commands.Turnos;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Tareas;
using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.Domain.Factories.Turnos;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Turnos;
using CuidadosModernos.Repository.Turnos;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Turnos
{
    public class RegistrarTurnoLogic : BusinessLogic<Turno, ITurnoRepository>, IRegistrarTurnoBusinessService
    {
        private ITurnoFactory TurnoFactory { get; set; }

        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }

        private IAsignarTareaEmpleadaTurnoBusinessService AsignarTareaEmpleadaTurnoBusinessService { get; set; }

        public RegistrarTurnoLogic(IDbContextScopeFactory dbContextScopeFactory,
                                   Turno aggregate,
                                   ITurnoRepository repository,
                                   ITurnoFactory turnoFactory,
                                   IEntityLoaderBusinessService entityLoaderBusinessService,
                                   IAsignarTareaEmpleadaTurnoBusinessService asignarTareaEmpleadaTurnoBusinessService)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.TurnoFactory = turnoFactory;
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
            this.AsignarTareaEmpleadaTurnoBusinessService = asignarTareaEmpleadaTurnoBusinessService;
        }

        public void RegistrarTurno(RegistrarTurnoCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                var registrarTurno = this.MapearRegistrarTurno(command);

                this.Aggregate = this.TurnoFactory.Crear(registrarTurno.Empleada);

                this.Aggregate.Registrar(registrarTurno);

                this.AsignarTareaEmpleadaTurnoBusinessService.AsignarTarea(this.Aggregate);

                context.SaveChanges();
            }
        }

        private RegistrarTurno MapearRegistrarTurno(RegistrarTurnoCommand command)
        {
            var registrarTurno = new RegistrarTurno();

            registrarTurno.Empleada = this.EntityLoaderBusinessService.GetByID<Empleada>(command.EmpleadaID);
            registrarTurno.FechaHoraInicio = command.FechaHoraInicio;
            registrarTurno.FechaHoraFin = command.FechaHoraFin;

            return registrarTurno;
        }
    }
}
