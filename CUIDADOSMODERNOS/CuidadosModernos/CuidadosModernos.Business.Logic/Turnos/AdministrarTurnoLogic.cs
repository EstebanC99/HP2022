using Cross.Business.Logic;
using CuidadosModernos.Business.Domain.Commands.Turnos;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.Domain.Factories.Turnos;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Turnos;
using CuidadosModernos.Repository.Turnos;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Turnos
{
    public class AdministrarTurnoLogic : BusinessLogic<Turno, ITurnoRepository>, IAdministrarTurnoBusinessService
    {
        private ITurnoFactory TurnoFactory { get; set; }
        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }
        private IAsignarTareaTurnoBusinessService AsignarTareaTurnoBusinessService { get; set; }

        public AdministrarTurnoLogic(IDbContextScopeFactory dbContextScopeFactory,
                                   Turno aggregate,
                                   ITurnoRepository repository,
                                   ITurnoFactory turnoFactory,
                                   IEntityLoaderBusinessService entityLoaderBusinessService,
                                   IAsignarTareaTurnoBusinessService asignarTareaTurnoBusinessService)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.TurnoFactory = turnoFactory;
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
            this.AsignarTareaTurnoBusinessService = asignarTareaTurnoBusinessService;
        }

        public void RegistrarTurno(RegistrarTurnoCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                var registrarTurno = this.MapearRegistrarTurno(command);

                this.Aggregate = this.TurnoFactory.Crear(registrarTurno.Empleada);

                this.Aggregate.Registrar(registrarTurno);

                this.Repository.Add(this.Aggregate);

                context.SaveChanges();
            }

            this.AsignarTareaTurnoBusinessService.Asignar();
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
