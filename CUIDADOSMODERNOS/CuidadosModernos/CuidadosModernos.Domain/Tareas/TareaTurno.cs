using CuidadosModernos.CrossCutting.Global;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Turnos;
using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class TareaTurno : Entity
    {
        public TareaTurno()
        {

        }

        public virtual int ID_Turno { get; private set; }

        public virtual DateTime? FechaHoraRealizacion { get; private set; }

        public string Comentario { get; private set; }

        public virtual EstadoTareaTurno Estado { get; private set; }

        public virtual Turno Turno { get; private set; }

        public virtual Tarea Tarea { get; private set; }

        public TareaTurno(Turno turno, Tarea tarea, EstadoTareaTurno estado)
        {
            this.Turno = turno;
            this.Tarea = tarea;
            this.Estado = estado;
        }

        public void MarcarIncumplida(IEntityLoaderDomainService entityLoaderDomainService)
        {
            this.Estado = entityLoaderDomainService.GetByID<EstadoTareaTurno>(EstadosTareaTurno.Incumplida);
        }
    }
}
