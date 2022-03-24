using CuidadosModernos.Domain.Tareas;
using System;
using System.Collections.Generic;

namespace CuidadosModernos.Domain.Horarios
{
    public class Horario : Entity
    {
        public virtual TimeSpan HoraInicio { get; private set; }

        public virtual TimeSpan HoraFin { get; private set; }

        public virtual ICollection<TareaHorario> Tareas { get; private set; }
    }
}
