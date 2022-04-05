using Cross.Business.Domain.Commands;
using System;

namespace CuidadosModernos.Business.Domain.Commands.Tareas
{
    public class AsignarTareaEmpleadaCommand : Command<int>
    {
        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }
    }
}
