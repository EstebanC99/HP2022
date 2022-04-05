using Cross.Business.Domain;
using System;

namespace CuidadosModernos.Domain.ValueObjects.Tareas
{
    public class RegistrarTarea : ValueObject
    {
        public string Descripcion { get; set; }

        public TimeSpan HoraMinima { get; set; }

        public TimeSpan? HoraMaxima { get; set; }
    }
}
