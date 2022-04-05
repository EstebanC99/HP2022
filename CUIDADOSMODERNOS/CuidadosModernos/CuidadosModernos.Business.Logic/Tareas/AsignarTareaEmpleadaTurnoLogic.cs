using Cross.Business.Logic;
using CuidadosModernos.BusinessService.Interfaces.Tareas;
using CuidadosModernos.Domain.Factories.Tareas;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Tareas
{
    public class AsignarTareaEmpleadaTurnoLogic : BusinessLogic<ITareaRepository>, IAsignarTareaEmpleadaTurnoBusinessService
    {
        private IEntityLoaderDomainService EntityLoaderDomainService { get; set; }

        private ITareaEmpleadaFactory TareaEmpleadaFactory { get; set; }

        public AsignarTareaEmpleadaTurnoLogic(IDbContextScopeFactory dbContextScopeFactory,
                                              ITareaRepository repository,
                                              IEntityLoaderDomainService entityLoaderDomainService,
                                              ITareaEmpleadaFactory tareaEmpleadaFactory)
            : base(dbContextScopeFactory, repository)
        {
            this.EntityLoaderDomainService = entityLoaderDomainService;
            this.TareaEmpleadaFactory = tareaEmpleadaFactory;
        }

        public void AsignarTarea(Turno turno)
        {
            using (var context = this.DbContextScopeFactory.CreateWithTransaction())
            {
                var tareas = this.Repository.ObtenerTareasPorHora(turno.FechaHoraInicio.TimeOfDay, turno.FechaHoraFin.TimeOfDay);

                if (tareas != null && tareas.Count >= 0)
                {
                    foreach (var tarea in tareas)
                    {
                        var tareaEmpleada = this.TareaEmpleadaFactory.Crear(tarea, this.EntityLoaderDomainService);

                        turno.Empleada.AsignarTarea(tareaEmpleada);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
