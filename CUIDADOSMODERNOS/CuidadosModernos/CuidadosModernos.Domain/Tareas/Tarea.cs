using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.ValueObjects.Tareas;
using System;

namespace CuidadosModernos.Domain.Tareas
{
    public class Tarea : Aggregate<int>
    {
        public string Titulo { get; private set; }

        public string Descripcion { get; private set; }

        public virtual TimeSpan HoraRealizacion { get; private set; }

        public virtual DateTime FechaInicioVigencia { get; private set; }

        public virtual DateTime? FechaFinVigencia { get; private set; }

        public virtual Frecuencia Frecuencia { get; private set; }

        public bool Activa { get; private set; }

        #region ABM

        #region Registrar

        public void Registrar(RegistrarTarea registrarTarea)
        {
            this.ValidarRegistrar(registrarTarea);

            this.GuardarTarea(registrarTarea);
        }

        private void ValidarRegistrar(RegistrarTarea registrarTarea)
        {
            var validaciones = new ValidationException();

            if (string.IsNullOrEmpty(registrarTarea.Titulo))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarTarea.Titulo)));
            }

            if (string.IsNullOrEmpty(registrarTarea.Descripcion))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarTarea.Descripcion)));
            }

            if (registrarTarea.HoraRealizacion == null || registrarTarea.HoraRealizacion == default)
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(HoraRealizacion)));
            }

            if (registrarTarea.FechaInicioVigencia == null || registrarTarea.FechaInicioVigencia == default)
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(FechaInicioVigencia)));
            }

            if (registrarTarea.Frecuencia == null)
            {
                validaciones.AddValidationResult(Messages.NoSeEncontroLaFrecuenciaElegida);
            }

            validaciones.Throw();
        }

        #endregion

        #region Modificar

        public void Modificar(ModificarTarea modificarTarea)
        {
            this.ValidarRegistrar(modificarTarea);

            this.GuardarTarea(modificarTarea);
        }

        #endregion

        #region Desactivar/Eliminar

        public void Desactivar()
        {
            this.Activa = false;
        }

        #endregion

        private void GuardarTarea(RegistrarTarea tarea)
        {
            this.Titulo = tarea.Titulo;
            this.Descripcion = tarea.Descripcion;
            this.HoraRealizacion = tarea.HoraRealizacion;
            this.FechaInicioVigencia = tarea.FechaInicioVigencia;
            this.FechaFinVigencia = tarea.FechaFinVigencia;
            this.Frecuencia = tarea.Frecuencia;
        }

        #endregion
    }
}
