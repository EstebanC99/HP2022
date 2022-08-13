using Cross.Business.Domain.Commands;
using System;

namespace CuidadosModernos.Business.Domain.Commands.Turnos
{
    public class RegistrarIngresoTurnoCommand : Command<int>
    {
        public DateTime FechaIngreso { get; set; }

        public int EmpleadaID { get; set; }
    }
}
