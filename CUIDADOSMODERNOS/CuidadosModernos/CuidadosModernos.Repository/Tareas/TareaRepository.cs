using CuidadosModernos.Business.Domain.Queries.Tareas;
using CuidadosModernos.Domain.Tareas;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CuidadosModernos.Repository
{
    public class TareaRepository : Repository<Tarea, int>, ITareaRepository
    {
        public TareaRepository(IAmbientDbContextLocator ambientDbContexLocator)
            : base(ambientDbContexLocator)
        {

        }

        public List<TareaDataView> GetAll()
        {
            return this.DbSet.Where(t => t.Activa).ToList().ConvertAll(t => new TareaDataView()
            {
                ID = t.ID,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                HoraRealizacion = t.HoraRealizacion,
                FechaInicioVigencia = t.FechaInicioVigencia,
                FechaFinVigencia = t.FechaFinVigencia,
                FrecuenciaID = t.Frecuencia.ID,
                FrecuenciaDescripcion = t.Frecuencia.Descripcion
            });
        }
    }
}
