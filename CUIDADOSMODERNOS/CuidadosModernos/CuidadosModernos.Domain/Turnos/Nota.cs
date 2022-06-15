using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;
using System;

namespace CuidadosModernos.Domain.Turnos
{
    public class Nota : Aggregate<int>
    {
        public virtual DateTime FechaHoraCreacion { get; private set; }

        public virtual DateTime FechaHoraRealizacion { get; private set; }

        public string Descripcion { get; private set; }

        public virtual bool Urgente { get; private set; }

        public Empleada Empleada { get; private set; }
    }
}
