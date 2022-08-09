using CuidadosModernos.Domain.Horarios;
using CuidadosModernos.Domain.Tareas;

namespace CuidadosModernos.Domain.Factories.Turnos
{
    public interface ITareaTurnoFactory
    {
        TareaTurno Crear(Turno turno, Tarea tarea);
    }
}