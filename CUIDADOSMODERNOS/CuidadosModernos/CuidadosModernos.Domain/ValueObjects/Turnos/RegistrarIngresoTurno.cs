using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;
using System;

namespace CuidadosModernos.Domain.ValueObjects.Turnos
{
    public class RegistrarIngresoTurno : ValueObject
    {
        public Empleada Empleada { get; set; }

        public DateTime FechaRealIngreso { get; set; }
    }
}
