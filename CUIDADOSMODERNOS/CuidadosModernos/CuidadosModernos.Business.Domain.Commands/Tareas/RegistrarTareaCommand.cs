using Cross.Business.Domain.Commands;
using System;

namespace CuidadosModernos.Business.Domain.Commands.Tareas
{
    public class RegistrarTareaCommand : Command<int>
    {
        public string Descripcion { get; set; }

        public TimeSpan HoraMinima { get; set; }

        public TimeSpan? HoraMaxima { get; set; }
    }
}
