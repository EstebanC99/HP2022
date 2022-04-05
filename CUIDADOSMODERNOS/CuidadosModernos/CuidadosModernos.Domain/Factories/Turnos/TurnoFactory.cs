using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Generales;
using CuidadosModernos.Domain.Horarios;

namespace CuidadosModernos.Domain.Factories.Turnos
{
    public class TurnoFactory : ITurnoFactory
    {
        public Turno Crear(Empleada empleada)
        {
            if (empleada == null)
            {
                throw new ValidationException(Messages.NoSeEncontroLaEmpleada);
            }

            return new Turno(empleada);
        }
    }
}
