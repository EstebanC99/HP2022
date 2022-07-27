using Cross.UI.Web.Models;
using System;

namespace CuidadosModernos.UI.Web.Models
{
    public class TareaDetalleVM : ViewModel
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string HoraRealizacion { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public int FrecuenciaID { get; set; }
        public string FrecuenciaDescripcion { get; set; }
    }
}
