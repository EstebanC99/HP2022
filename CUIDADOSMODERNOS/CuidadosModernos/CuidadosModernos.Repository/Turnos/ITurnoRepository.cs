using Cross.ResourceAccess.Repository;
using CuidadosModernos.Domain.Horarios;
using System;
using System.Collections.Generic;

namespace CuidadosModernos.Repository.Turnos
{
    public interface ITurnoRepository : IRepository<Turno, int>
    {
        Turno ObtenerTurnoPorFechaIngreso(DateTime fechaIngreso);

        Turno ObtenerTurnoAnterior(DateTime fechaIngreso);

        List<Turno> ObtenerTurnosPorCumplir();
    }
}