using Cross.Business.Domain;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Turnos;
using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class TareaTurno : Aggregate<int>
    {
        public virtual int ID_Turno { get; private set; }

        public virtual DateTime? FechaHoraRealizacion { get; private set; }

        public string Comentario { get; private set; }

        public virtual EstadoTareaTurno Estado { get; private set; }

        public virtual Turno Turno { get; private set; }

        public virtual Tarea Tarea { get; private set; }
    }
}
