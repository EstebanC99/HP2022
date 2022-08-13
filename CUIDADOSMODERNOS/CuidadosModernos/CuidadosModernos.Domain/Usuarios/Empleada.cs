using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Encargadas;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.ValueObjects.Empleadas;
using System.Collections.Generic;

namespace CuidadosModernos.Domain.Usuarios
{
    public class Empleada : Persona
    {
        public Empleada()
        {
            this.Usuarios = new List<Usuario>();
        }

        public string Email { get; private set; }

        public virtual Encargada Encargada { get; private set; }

        public bool Activa { get; private set; }

        #region ABM

        #region Registrar Empleada

        public void Registrar(RegistrarEmpleada registrarEmpleada,
                              IAdministrarUsuarioDomainService administrarUsuarioDomainService)
        {
            this.ValidarRegistrar(registrarEmpleada);

            this.GuardarEmpleada(registrarEmpleada, administrarUsuarioDomainService, false);

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

            if (string.IsNullOrEmpty(registrarEmpleada.Email) && string.IsNullOrEmpty(registrarEmpleada.Telefono))
            {
                validaciones.AddValidationResult(Messages.MailOTelefonoRequeridos);
            }

            if (string.IsNullOrEmpty(registrarEmpleada.Usuario))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarEmpleada.Usuario)));
            }

            if (string.IsNullOrEmpty(registrarEmpleada.Password))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarEmpleada.Password)));
            }

            if (registrarEmpleada.Encargada == null)
            {
                validaciones.AddValidationResult(Messages.NoSeEncontroLaEncargadaParaLaEmpleada);
            }

            validaciones.Throw();
        }

        #endregion

        #region Modificar

        public void Modificar(ModificarEmpleada modificarEmpleada,
                              IAdministrarUsuarioDomainService administrarUsuarioDomainService)
        {
            this.ValidarRegistrar(modificarEmpleada);

            this.GuardarEmpleada(modificarEmpleada, administrarUsuarioDomainService, true);
        }

        #endregion

        #region Eliminar
        public void EliminarEmpleada()
        {
            this.Activa = false;
        }
        #endregion

        private void GuardarEmpleada(RegistrarEmpleada empleada, 
                                     IAdministrarUsuarioDomainService administrarUsuarioDomainService,
                                     bool esModificacion)
        {
            this.Nombre = empleada.Nombre;
            this.Apellido = empleada.Apellido;
            this.DNI = empleada.DNI;
            this.Email = empleada.Email;
            this.Telefono = empleada.Telefono;
            this.Activa = true;

            administrarUsuarioDomainService.RegistrarUsuario(empleada.Usuario, empleada.Password, this, empleada.RolUsuario, esModificacion);
        }

        #endregion

    }
}
