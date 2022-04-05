using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.Domain.Encargadas;
using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Domain.ValueObjects.Empleadas;
using System.Collections.Generic;
using CuidadosModernos.CrossCutting.Exceptions;

namespace CuidadosModernos.Domain.Generales
{
    public class Empleada : Aggregate<int>
    {
        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public virtual string DNI { get; private set; }

        public string Mail { get; private set; }

        public string Telefono { get; private set; }

        public virtual ICollection<TareaEmpleada> Tareas { get; private set; }

        public virtual Encargada Encargada { get; private set; }

        #region Registrar Empleada

        public void Registrar(RegistrarEmpleada registrarEmpleada)
        {
            this.ValidarRegistrar(registrarEmpleada);

            this.Nombre = registrarEmpleada.Nombre;
            this.Apellido = registrarEmpleada.Apellido;
            this.DNI = registrarEmpleada.DNI;
            this.Mail = registrarEmpleada.Mail;
            this.Telefono = registrarEmpleada.Telefono;
            this.Encargada = registrarEmpleada.Encargada;
        }

        private void ValidarRegistrar(RegistrarEmpleada registrarEmpleada)
        {
            var validaciones = new ValidationException();

            if (string.IsNullOrEmpty(registrarEmpleada.Nombre))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarEmpleada.Nombre)));
            }

            if (string.IsNullOrEmpty(registrarEmpleada.Apellido))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarEmpleada.Apellido)));
            }

            if (string.IsNullOrEmpty(registrarEmpleada.DNI))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarEmpleada.DNI)));
            }

            if (string.IsNullOrEmpty(Mail) && string.IsNullOrEmpty(registrarEmpleada.Telefono))
            {
                validaciones.AddValidationResult(Messages.MailOTelefonoRequeridos);
            }

            if (registrarEmpleada.Encargada == null)
            {
                validaciones.AddValidationResult(Messages.NoSeEncontroLaEncargadaParaLaEmpleada);
            }

            validaciones.Throw();
        }

        #endregion

        #region Asignar Tarea

        public void AsignarTarea(TareaEmpleada tareaEmpleada)
        {
            if (tareaEmpleada != null)
            {
                this.Tareas.Add(tareaEmpleada);
            }
        }

        #endregion
    }
}
