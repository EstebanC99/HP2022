using CuidadosModernos.Domain.Generales;

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
