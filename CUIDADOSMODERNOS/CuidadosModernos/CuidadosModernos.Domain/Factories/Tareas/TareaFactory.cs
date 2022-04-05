using CuidadosModernos.Domain.Tareas;

namespace CuidadosModernos.Domain.Factories.Tareas
{
    public class TareaFactory : ITareaFactory
    {
        public Tarea Crear()
        {
            return new Tarea();
        }
    }
}
