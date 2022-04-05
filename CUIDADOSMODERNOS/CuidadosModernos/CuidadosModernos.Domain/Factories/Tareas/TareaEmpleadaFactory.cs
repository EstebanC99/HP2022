using CuidadosModernos.Domain.Estados;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Tareas;

namespace CuidadosModernos.Domain.Factories.Tareas
{
    public class TareaEmpleadaFactory : ITareaEmpleadaFactory
    {
        public TareaEmpleada Crear(Tarea tarea, IEntityLoaderDomainService entityLoaderDomainService)
        {
            var estado = entityLoaderDomainService.GetByID<EstadoTareaEmpleada>(CrossCutting.Global.EstadosTareaEmpleada.Asignada);

            return new TareaEmpleada(tarea, estado);
        }
    }
}
