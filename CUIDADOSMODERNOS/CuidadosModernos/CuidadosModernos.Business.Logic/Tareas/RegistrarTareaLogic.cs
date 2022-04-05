using Cross.Business.Logic;
using CuidadosModernos.Business.Domain.Commands.Tareas;
using CuidadosModernos.BusinessService.Interfaces.Tareas;
using CuidadosModernos.Domain.Factories.Tareas;
using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Domain.ValueObjects.Tareas;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Tareas
{
    public class RegistrarTareaLogic : BusinessLogic<Tarea, ITareaRepository>, IRegistrarTareaBusinessService
    {
        private ITareaFactory TareaFactory { get; set; }

        public RegistrarTareaLogic(IDbContextScopeFactory dbContextScopeFactory,
                                   Tarea aggregate,
                                   ITareaRepository repository,
                                   ITareaFactory tareaFactory)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.TareaFactory = tareaFactory;
        }

        public void RegistrarTarea(RegistrarTareaCommand command)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                var registrarTarea = this.MapearRegistrarTarea(command);

                this.Aggregate = this.TareaFactory.Crear();

                this.Aggregate.Registrar(registrarTarea);

                context.SaveChanges();
            }
        }

        private RegistrarTarea MapearRegistrarTarea(RegistrarTareaCommand command)
        {
            var registrarTarea = new RegistrarTarea();

            registrarTarea.Descripcion = command.Descripcion;
            registrarTarea.HoraMinima = command.HoraMinima;
            registrarTarea.HoraMaxima = command.HoraMaxima;

            return registrarTarea;
        }
    }
}
