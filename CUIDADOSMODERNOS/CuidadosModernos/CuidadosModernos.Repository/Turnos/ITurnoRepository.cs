using Cross.ResourceAccess.Repository;
using CuidadosModernos.Domain.Horarios;
using System.Collections.Generic;

namespace CuidadosModernos.Repository.Turnos
{
    public interface ITurnoRepository : IRepository<Turno, int>
    {
        List<Turno> ObtenerTurnosPorCumplir();
    }
}