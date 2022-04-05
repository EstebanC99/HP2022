using CuidadosModernos.Domain.Generales;
using CuidadosModernos.Domain.Horarios;

namespace CuidadosModernos.Domain.Factories.Turnos
{
    public interface ITurnoFactory
    {
        Turno Crear(Empleada empleada);
    }
}