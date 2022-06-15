using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Usuarios;

namespace CuidadosModernos.Domain.Factories.Turnos
{
    public interface ITurnoFactory
    {
        Turno Crear(Empleada empleada);
    }
}