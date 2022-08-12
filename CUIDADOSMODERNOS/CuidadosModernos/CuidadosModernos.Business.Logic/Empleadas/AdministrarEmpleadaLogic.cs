using Cross.Business.Logic;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.Business.Domain.Commands.Empleadas;
using CuidadosModernos.Business.Domain.Commands.Usuarios;
using CuidadosModernos.Business.Domain.Queries.Empleadas;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Empleadas;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Encargadas;
using CuidadosModernos.Domain.Factories.Empledas;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Empleadas;
using CuidadosModernos.Repository.Empleadas;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CuidadosModernos.Business.Logic.Empleadas
{
    public class AdministrarEmpleadaLogic : BusinessLogic<Empleada, IEmpleadaRepository>, IAdministrarEmpleadaBusinessService
    {
        private IEmpleadaFactory EmpleadaFactory { get; set; }
        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }
        private IAdministrarUsuarioDomainService AdministrarUsuarioDomainService { get; set; }

        public AdministrarEmpleadaLogic(IDbContextScopeFactory dbContextScopeFactory,
                                        Empleada aggregate,
                                        IEmpleadaRepository repository,
                                        IEmpleadaFactory empleadaFactory,
                                        IEntityLoaderBusinessService entityLoaderBusinessService,
                                        IAdministrarUsuarioDomainService administrarUsuarioDomainService)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.EmpleadaFactory = empleadaFactory;
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
            this.AdministrarUsuarioDomainService = administrarUsuarioDomainService;
        }

        public List<EmpleadaDataView> GetAll()
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.GetAll();
            }
        }

        public EmpleadaDataView GetByID(int empleadaID)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                this.Aggregate = this.Repository.GetByID(empleadaID);

                if (this.Aggregate == null)
                    throw new ValidationException(Messages.NoSeEncontroLaEmpleada);

                return new EmpleadaDataView()
                {
                    ID = this.Aggregate.ID,
                    Nombre = this.Aggregate.Nombre,
                    Apellido = this.Aggregate.Apellido,
                    DNI = this.Aggregate.DNI,
                    Email = this.Aggregate.Email,
                    Telefono = this.Aggregate.Telefono,
                    Usuario = this.Aggregate.ObtenerUsuario()?.Username,
                    Password = this.Aggregate.ObtenerUsuario()?.Password,
                    EncargadaID = this.Aggregate.Encargada.ID,
                    EncargadaNombreApellido = string.Join(" ", this.Aggregate.Encargada.Nombre, this.Aggregate.Encargada.Apellido)
                };
            }
        }

        public void RegistrarEmpleada(RegistrarEmpleadaCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                this.ValidarRegistroEmpleada(command);

                var registrarEmpleada = this.MapearEmpleada(command);

                this.Aggregate = this.EmpleadaFactory.CrearEmpleada();

                this.Aggregate.Registrar(registrarEmpleada, this.AdministrarUsuarioDomainService);

                this.Repository.Add(this.Aggregate);

                context.SaveChanges();
            }
        }

        public void ModificarEmpleada(ModificarEmpleadaCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                this.Aggregate = this.Repository.GetByID(command.ID);

                if (this.Aggregate == null)
                {
                    throw new ValidationException(Messages.NoSeEncontroLaEmpleada);
                }

                this.Aggregate.Modificar(this.MapearEmpleada(command), this.AdministrarUsuarioDomainService);

                context.SaveChanges();
            }
        }

        public void EliminarEmpleada(int empleadaID)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                this.Aggregate = this.Repository.GetByID(empleadaID);

                if (this.Aggregate == null)
                {
                    throw new ValidationException(Messages.NoSeEncontroLaEmpleada);
                }

                this.Aggregate.EliminarEmpleada();

                context.SaveChanges();
            }
        }

        private void ValidarRegistroEmpleada(RegistrarEmpleadaCommand command)
        {
            var validaciones = new ValidationException();

            if (this.Repository.GetAll().Any(e => e.DNI == command.DNI))
            {
                validaciones.AddValidationResult(Messages.YaSeRegistroUnaEmpleadaConDNIXFormat(command.DNI));
            }

            validaciones.Throw();
        }

        private ModificarEmpleada MapearEmpleada(RegistrarEmpleadaCommand command)
        {
            var registrarEmpleada = new ModificarEmpleada();

            registrarEmpleada.Nombre = command.Nombre;
            registrarEmpleada.Apellido = command.Apellido;
            registrarEmpleada.DNI = command.DNI;
            registrarEmpleada.Email = command.Email;
            registrarEmpleada.Telefono = command.Telefono;
            registrarEmpleada.Usuario = command.Usuario;
            registrarEmpleada.Password = command.Password;

            registrarEmpleada.Encargada = this.EntityLoaderBusinessService.GetByID<Encargada>(command.EncargadaID);

            return registrarEmpleada;
        }
    }
}
