using Cross.Business.Domain;
using CuidadosModernos.Domain.Tareas;
using System;

namespace CuidadosModernos.Domain.ValueObjects.Tareas
{
    public class RegistrarTarea : ValueObject
    {
        public virtual string Titulo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual TimeSpan HoraRealizacion { get; set; }
        public virtual DateTime FechaInicioVigencia { get; set; }
        public virtual DateTime? FechaFinVigencia { get; set; }
        public virtual Frecuencia Frecuencia { get; set; }
    }
}
