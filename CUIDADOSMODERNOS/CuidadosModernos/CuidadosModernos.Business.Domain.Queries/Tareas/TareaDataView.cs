using System;

namespace CuidadosModernos.Business.Domain.Queries.Tareas
{
    public class TareaDataView : DataView
    {
        public string Titulo { get; set; }
        public TimeSpan HoraRealizacion { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime? FechaFinVigencia { get; set; }
        public int FrecuenciaID { get; set; }
        public string FrecuenciaDescripcion { get; set; }
    }
}
