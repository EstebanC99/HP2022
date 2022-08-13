using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Usuarios.DuplicidadUsuario;
using CuidadosModernos.Domain.Usuarios.Rol;
using CuidadosModernos.Domain.ValueObjects.Usuarios;
using System;

namespace CuidadosModernos.Domain.Usuarios
{
    public class Usuario : Aggregate<int>
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public virtual Persona Persona{ get; private set; }

        public DateTime FechaAlta { get; private set; }

        public DateTime? FechaBaja { get; private set; }

        public bool Activo { get; private set; }

        public virtual RolUsuario Rol { get; private set; }

        public int ID_Persona { get; private set; }

        public void Registrar(RegistrarUsuario registrarUsuario,
                              IDuplicidadUsuario duplicidadUsuario)
        {
            #region Validaciones
            var validaciones = new ValidationException();

            if (string.IsNullOrEmpty(registrarUsuario.Username))
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarUsuario.Username)));

            if (string.IsNullOrEmpty(registrarUsuario.Password))
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarUsuario.Password)));

            if (registrarUsuario.Persona == null)
                validaciones.AddValidationResult(Messages.NoSeEncontroLaEmpleada);

            if (registrarUsuario.Rol == null)
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarUsuario.Rol)));

            validaciones.Throw();

            duplicidadUsuario.Validar(registrarUsuario);
            #endregion

            #region Setters
            this.Username = registrarUsuario.Username;
            this.Password = registrarUsuario.Password;
            this.Persona = registrarUsuario.Persona;
            this.Rol = registrarUsuario.Rol;
            this.FechaAlta = DateTime.Now;
            this.Activo = true;
            #endregion
        }

        public void Modificar(RegistrarUsuario registrarUsuario,
                              IDuplicidadUsuario duplicidadUsuario)
        {
            #region Validaciones
            var validaciones = new ValidationException();

            if (string.IsNullOrEmpty(registrarUsuario.Username))
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarUsuario.Username)));

            if (string.IsNullOrEmpty(registrarUsuario.Password))
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(registrarUsuario.Password)));

            validaciones.Throw();

            duplicidadUsuario.Validar(registrarUsuario);
            #endregion

            #region Setters
            this.Username = registrarUsuario.Username;
            this.Password = registrarUsuario.Password;
            #endregion
        }
    }
}
