using Cross.ResourceAccess.Repository;
using CuidadosModernos.Domain.Tareas;
using System;
using System.Collections.Generic;

namespace CuidadosModernos.Repository
{
    public interface ITareaRepository : IRepository<Tarea, int>
    {
        List<Tarea> ObtenerTareasPorHora(TimeSpan horaInicio, TimeSpan horaFin);
    }
}