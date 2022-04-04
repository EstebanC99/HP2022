using Cross.Business.Domain;
using CuidadosModernos.Domain.Generales;
using System;

namespace CuidadosModernos.Domain.Horarios
{
    public class Turno : Aggregate<int>
    {
        public virtual DateTime FechaHoraInicio { get; private set; }

        public virtual DateTime FechaHoraFin { get; private set; }

        public virtual Empleada Empleada { get; private set; }
    }
}
