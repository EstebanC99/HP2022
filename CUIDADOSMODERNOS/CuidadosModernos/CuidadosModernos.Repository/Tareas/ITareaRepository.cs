using Cross.ResourceAccess.Repository;
using CuidadosModernos.Business.Domain.Queries.Tareas;
using CuidadosModernos.Domain.Tareas;
using System.Collections.Generic;

namespace CuidadosModernos.Repository
{
    public interface ITareaRepository : IRepository<Tarea, int>
    {
        List<TareaDataView> GetAll();
    }
}