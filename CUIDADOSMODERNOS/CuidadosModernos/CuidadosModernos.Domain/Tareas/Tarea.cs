using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.ValueObjects.Tareas;
using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class Tarea : Aggregate<int>
    {
        public string Descripcion { get; private set; }

        public virtual TimeSpan HoraMinima { get; private set; }

        public virtual TimeSpan? HoraMaxima { get; private set; }

        public void Registrar(RegistrarTarea registrarTarea)
        {
            this.ValidarRegistrar(registrarTarea);

            this.Descripcion = registrarTarea.Descripcion;
            this.HoraMinima = registrarTarea.HoraMinima;
            this.HoraMaxima = registrarTarea.HoraMaxima;
        }

        private void ValidarRegistrar(RegistrarTarea registrarTarea)
        {
            var validaciones = new ValidationException();

            if (string.IsNullOrEmpty(registrarTarea.Descripcion))
            {
                validaciones.AddValidationResult(Messages.LaDescripcionNoPuedeEstarVacia);
            }

            if (registrarTarea.HoraMinima == null || registrarTarea.HoraMinima == TimeSpan.Zero)
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarTarea.HoraMinima)));
            }

            validaciones.Throw();
        }
    }
}
