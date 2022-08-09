using Cross.ResourceAccess.Repository;
using CuidadosModernos.Business.Domain.Queries.Tareas;
using CuidadosModernos.Domain.Tareas;
using System;
using System.Collections.Generic;

namespace CuidadosModernos.Repository
{
    public interface ITareaRepository : IRepository<Tarea, int>
    {
        List<TareaDataView> GetAll();

        List<Tarea> ObtenerTareasPorHorario(DateTime fechaInicio, TimeSpan horaInicio, DateTime fechaFin, TimeSpan horaFin);
    }
}