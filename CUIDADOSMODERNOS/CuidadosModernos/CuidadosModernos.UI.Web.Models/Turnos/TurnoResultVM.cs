using Cross.UI.Web.Models;
using System;

namespace CuidadosModernos.UI.Web.Models
{
    public class TurnoResultVM : ViewModel
    {
        public int EmpleadaID { get; set; }

        public string EmpleadaNombreApellido { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }
    }
}
