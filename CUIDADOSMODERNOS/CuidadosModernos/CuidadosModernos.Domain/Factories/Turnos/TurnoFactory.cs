using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Usuarios;

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
