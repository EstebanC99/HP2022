using Cross.Business.Domain;
using CuidadosModernos.Domain.Encargadas;

namespace CuidadosModernos.Domain.ValueObjects.Empleadas
{
    public class RegistrarEmpleada : ValueObject
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Mail { get; set; }

        public string Telefono { get; set; }

        public virtual Encargada Encargada { get; set; }
    }
}
