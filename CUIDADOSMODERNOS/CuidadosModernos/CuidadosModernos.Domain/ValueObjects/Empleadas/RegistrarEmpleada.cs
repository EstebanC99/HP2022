using Cross.Business.Domain;
using CuidadosModernos.Domain.Encargadas;

namespace CuidadosModernos.Domain.ValueObjects.Empleadas
{
    public class RegistrarEmpleada : ValueObject
    {
        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual string DNI { get; set; }

        public virtual string Email { get; set; }

        public virtual string Telefono { get; set; }

        public virtual string Usuario { get; set; }

        public virtual string Password { get; set; }

        public virtual Encargada Encargada { get; set; }
    }
}
