using CuidadosModernos.Domain.Generales;
using System;

namespace CuidadosModernos.Domain.Horarios
{
    public class HorarioEmpleada : Entity
    {
        public virtual Empleada Empleada { get; private set; }

        public virtual Horario Horario { get; private set; }

        public DateTime FechaVigencia { get; private set; }

        public int ID_Empleada { get; private set; }
    }
}
