using CuidadosModernos.Domain.Horarios;
using System.Collections.Generic;

namespace CuidadosModernos.Domain.Generales
{
    public class Empleada : Entity
    {
        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public virtual string DNI { get; private set; }

        public string Mail { get; private set; }

        public string Telefono { get; private set; }

        public virtual ICollection<HorarioEmpleada> Horarios { get; private set; }

    }
}
