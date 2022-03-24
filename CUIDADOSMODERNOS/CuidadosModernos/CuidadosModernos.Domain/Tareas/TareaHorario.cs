using CuidadosModernos.Domain.Horarios;

namespace CuidadosModernos.Domain.Tareas
{
    public class TareaHorario : Entity
    {
        public virtual Horario Horario { get; private set; }

        public virtual Tarea Tarea { get; private set; }

        public int ID_Horario { get; private set; }
    }
}
