using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class Tarea : Entity
    {
        public virtual TimeSpan Hora { get; private set; }
    }
}
