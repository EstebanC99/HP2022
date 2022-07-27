using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Encargadas;
using CuidadosModernos.Domain.ValueObjects.Empleadas;

namespace CuidadosModernos.Domain.Usuarios
{
    public class Empleada : Aggregate<int>
    {
        public Empleada()
        {
        }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public virtual string DNI { get; private set; }

        public string Email { get; private set; }

        public string Telefono { get; private set; }

        public string Usuario { get; private set; }

        public string Password { get; private set; }

        public virtual Encargada Encargada { get; private set; }

        public bool Activa { get; private set; }

        #region ABM

        #region Registrar Empleada

        public void Registrar(RegistrarEmpleada registrarEmpleada)
        {
            this.ValidarRegistrar(registrarEmpleada);

            this.GuardarEmpleada(registrarEmpleada);

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

            if (registrarEmpleada.Encargada == null)
            {
                validaciones.AddValidationResult(Messages.NoSeEncontroLaEncargadaParaLaEmpleada);
            }

            validaciones.Throw();
        }

        #endregion

        #region Modificar

        public void Modificar(ModificarEmpleada modificarEmpleada)
        {
            this.ValidarRegistrar(modificarEmpleada);
            this.ValidarModificar(modificarEmpleada);

            this.GuardarEmpleada(modificarEmpleada);
        }

        private void ValidarModificar(ModificarEmpleada modificarEmpleada)
        {
            var validaciones = new ValidationException();

            if (this.Usuario != null && string.IsNullOrEmpty(modificarEmpleada.Usuario))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(modificarEmpleada.Usuario)));
            }

            if (this.Password != null && string.IsNullOrEmpty(modificarEmpleada.Password))
            {
                validaciones.AddValidationResult(Messages.LaPropiedadEsRequeridaFormat(nameof(modificarEmpleada.Password)));
            }

            validaciones.Throw();
        }

        #endregion

        #region Eliminar
        public void EliminarEmpleada()
        {
            this.Activa = false;
        }
        #endregion

        private void GuardarEmpleada(RegistrarEmpleada empleada)
        {
            this.Nombre = empleada.Nombre;
            this.Apellido = empleada.Apellido;
            this.DNI = empleada.DNI;
            this.Email = empleada.Email;
            this.Telefono = empleada.Telefono;
            this.Usuario = empleada.Usuario;
            this.Password = empleada.Password;
        }

        #endregion

    }
}
