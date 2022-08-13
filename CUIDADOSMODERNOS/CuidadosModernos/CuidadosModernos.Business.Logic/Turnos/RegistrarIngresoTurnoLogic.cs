using Cross.Crosscutting.Exceptions;
using CuidadosModernos.Business.Domain.Commands.Turnos;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Turnos;
using CuidadosModernos.Repository.Turnos;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Turnos
{
    public class RegistrarIngresoTurnoLogic : BusinessLogic<Turno, ITurnoRepository>, IRegistrarIngresoTurnoBusinessService
    {
        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }
        private IEntityLoaderDomainService EntityLoaderDomainService { get; set; }

        public RegistrarIngresoTurnoLogic(IDbContextScopeFactory dbContextScopeFactory,
                                          Turno aggregate,
                                          ITurnoRepository repository,
                                          IEntityLoaderBusinessService entityLoaderBusinessService,
                                          IEntityLoaderDomainService entityLoaderDomainService)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
            this.EntityLoaderDomainService = entityLoaderDomainService;
        }

        public void RegistrarIngreso(RegistrarIngresoTurnoCommand command)
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                this.Aggregate = this.Repository.ObtenerTurnoPorFechaIngreso(command.FechaIngreso);

                if (this.Aggregate == null)
                    throw new ValidationException(Messages.NoHayTurnosPorCumplir);

                var turno = new RegistrarIngresoTurno()
                {
                    Empleada = this.EntityLoaderBusinessService.GetByID<Empleada>(command.EmpleadaID),
                    FechaRealIngreso = command.FechaIngreso
                };

                this.Aggregate.RegistrarIngreso(turno);

                context.SaveChanges();
            }
        }

        public void FinalizarTurnoAnterior(RegistrarIngresoTurnoCommand command)
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                this.Aggregate = this.Repository.ObtenerTurnoAnterior(command.FechaIngreso);

                if (this.Aggregate != null)
                {
                    this.Aggregate.FinalizarTurno(command.FechaIngreso, this.EntityLoaderDomainService);
                }

                context.SaveChanges();
            }
        }
    }
}
