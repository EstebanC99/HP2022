using Cross.Business.Domain;
using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class Tarea : Aggregate<int>
    {
        public virtual TimeSpan HoraMinima { get; private set; }

        public virtual TimeSpan? HoraMaxima { get; private set; }
    }
}
