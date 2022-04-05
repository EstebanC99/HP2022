using Cross.Business.Domain.Commands;
using System;

namespace CuidadosModernos.Business.Domain.Commands.Turnos
{
    public class RegistrarTurnoCommand : Command<int>
    {
        public int EmpleadaID { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }
    }
}
