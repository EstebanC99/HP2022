using CuidadosModernos.Domain.Estados;
using CuidadosModernos.Domain.Generales;
using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class TareaEmpleada : Entity
    {
        public virtual Empleada Empleada { get; private set; }

        public virtual Tarea Tarea { get; private set; }

        public DateTime FechaHoraRealizacion { get; private set; }

        public virtual EstadoTareaEmpleada Estado { get; private set; }

        public int ID_Empleada { get; private set; }

        public TareaEmpleada(Tarea tarea, EstadoTareaEmpleada estado)
        {
            this.Tarea = tarea;
            this.Estado = estado;
        }

    }
}
