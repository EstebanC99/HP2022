using Cross.Business.Logic;
using CuidadosModernos.Business.Domain.Commands.Empleadas;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Empleadas;
using CuidadosModernos.Domain.Encargadas;
using CuidadosModernos.Domain.Factories.Empledas;
using CuidadosModernos.Domain.Generales;
using CuidadosModernos.Domain.ValueObjects.Empleadas;
using CuidadosModernos.Repository.Empleadas;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Empleadas
{
    public class RegistrarEmpleadaLogic : BusinessLogic<Empleada, IEmpleadaRepository>, IRegistrarEmpleadaBusinessService
    {
        private IEmpleadaFactory EmpleadaFactory { get; set; }

        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }

        public RegistrarEmpleadaLogic(IDbContextScopeFactory dbContextScopeFactory,
                                      Empleada aggregate,
                                      IEmpleadaRepository repository,
                                      IEmpleadaFactory empleadaFactory,
                                      IEntityLoaderBusinessService entityLoaderBusinessService)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.EmpleadaFactory = empleadaFactory;
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
        }

        public void RegistrarEmpleada(RegistrarEmpleadaCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                var registrarEmpleada = this.MapearRegistrarEmpleada(command);

                this.Aggregate = this.EmpleadaFactory.CrearEmpleada();

                this.Aggregate.Registrar(registrarEmpleada);

                context.SaveChanges();
            }
        }

        private RegistrarEmpleada MapearRegistrarEmpleada(RegistrarEmpleadaCommand command)
        {
            var registrarEmpleada = new RegistrarEmpleada();

            registrarEmpleada.Nombre = command.Nombre;
            registrarEmpleada.Apellido = command.Apellido;
            registrarEmpleada.DNI = command.DNI;
            registrarEmpleada.Mail = command.Mail;
            registrarEmpleada.Telefono = command.Telefono;

            registrarEmpleada.Encargada = this.EntityLoaderBusinessService.GetByID<Encargada>(command.EncargadaID);

            return registrarEmpleada;
        }
    }
}
