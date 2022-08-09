using Cross.Business.Logic;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.Business.Domain.Commands.Tareas;
using CuidadosModernos.Business.Domain.Queries.Tareas;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Tareas;
using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Factories.Tareas;
using CuidadosModernos.Domain.Services.Tareas;
using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Domain.ValueObjects.Tareas;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;

namespace CuidadosModernos.Business.Logic.Tareas
{
    public class AdministrarTareaLogic : BusinessLogic<Tarea, ITareaRepository>, IAdministrarTareaBusinessService, IAdministrarTareaDomainService
    {
        private ITareaFactory TareaFactory { get; set; }

        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }

        private IAsignarTareaTurnoBusinessService AsignarTareaTurnoBusinessService { get; set; }

        public AdministrarTareaLogic(IDbContextScopeFactory dbContextScopeFactory,
                                   Tarea aggregate,
                                   ITareaRepository repository,
                                   ITareaFactory tareaFactory,
                                   IEntityLoaderBusinessService entityLoaderBusinessService,
                                   IAsignarTareaTurnoBusinessService asignarTareaTurnoBusinessService)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.TareaFactory = tareaFactory;
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
            this.AsignarTareaTurnoBusinessService = asignarTareaTurnoBusinessService;
        }

        public List<TareaDataView> GetAll()
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                return this.Repository.GetAll();
            }
        }

        public TareaDataView GetByID(int tareaID)
        {
            using (this.DbContextScopeFactory.CreateReadOnly())
            {
                this.Aggregate = this.Repository.GetByID(tareaID);

                if (this.Aggregate == null)
                    throw new ValidationException(Messages.NoSeEncontroLaTarea);

                return new TareaDataView()
                {
                    ID = this.Aggregate.ID,
                    Titulo = this.Aggregate.Titulo,
                    Descripcion = this.Aggregate.Descripcion,
                    HoraRealizacion = this.Aggregate.HoraRealizacion,
                    FechaInicioVigencia = this.Aggregate.FechaInicioVigencia,
                    FechaFinVigencia = this.Aggregate.FechaFinVigencia,
                    FrecuenciaID = this.Aggregate.Frecuencia.ID,
                    FrecuenciaDescripcion = this.Aggregate.Frecuencia.Descripcion
                };
            }
        }

        public void RegistrarTarea(RegistrarTareaCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                var registrarTarea = this.MapearTarea(command);

                this.Aggregate = this.TareaFactory.Crear();

                this.Aggregate.Registrar(registrarTarea);

                this.Repository.Add(this.Aggregate);

                context.SaveChanges();

                this.AsignarTareaTurnoBusinessService.Asignar();
            }
        }

        public void ModificarTarea(ModificarTareaCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                this.Aggregate = this.Repository.GetByID(command.ID);

                if (this.Aggregate == null)
                    throw new ValidationException(Messages.NoSeEncontroLaTarea);

                this.Aggregate.Modificar(this.MapearTarea(command));

                context.SaveChanges();

                this.AsignarTareaTurnoBusinessService.Asignar();
            }
        }

        public void Desactivar(int tareaID)
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                this.Aggregate = this.Repository.GetByID(tareaID);

                if (this.Aggregate == null)
                    throw new ValidationException(Messages.NoSeEncontroLaTarea);

                this.Aggregate.Desactivar();

                context.SaveChanges();

                this.AsignarTareaTurnoBusinessService.Asignar();
            }
        }

        private ModificarTarea MapearTarea(RegistrarTareaCommand command)
        {
            var registrarTarea = new ModificarTarea();

            registrarTarea.Titulo = command.Titulo;
            registrarTarea.Descripcion = command.Descripcion;
            registrarTarea.HoraRealizacion = command.HoraRealizacion;
            registrarTarea.FechaInicioVigencia = command.FechaInicioVigencia;
            registrarTarea.FechaFinVigencia = command.FechaFinVigencia;
            registrarTarea.Frecuencia = this.EntityLoaderBusinessService.GetByID<Frecuencia>(command.FrecuenciaID);

            return registrarTarea;
        }
    }
}
