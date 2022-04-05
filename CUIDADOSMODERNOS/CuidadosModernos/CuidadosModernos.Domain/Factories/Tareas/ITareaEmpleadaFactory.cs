using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Tareas;

namespace CuidadosModernos.Domain.Factories.Tareas
{
    public interface ITareaEmpleadaFactory
    {
        TareaEmpleada Crear(Tarea tarea, IEntityLoaderDomainService entityLoaderDomainService);
    }
}