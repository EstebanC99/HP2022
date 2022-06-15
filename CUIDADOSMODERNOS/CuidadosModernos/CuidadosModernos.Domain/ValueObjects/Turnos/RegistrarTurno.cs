using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;
using System;

namespace CuidadosModernos.Domain.ValueObjects.Turnos
{
    public class RegistrarTurno : ValueObject
    {
        public Empleada Empleada { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }
    }
}
