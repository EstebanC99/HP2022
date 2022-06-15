using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Empleadas;

namespace CuidadosModernos.Domain.Factories.Empledas
{
    public class EmpleadaFactory : IEmpleadaFactory
    {
        public Empleada CrearEmpleada()
        {
            return new Empleada();
        }
    }
}
