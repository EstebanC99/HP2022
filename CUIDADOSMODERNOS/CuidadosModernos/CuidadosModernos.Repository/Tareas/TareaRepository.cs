using CuidadosModernos.Domain.Tareas;
using EntityFramework.DbContextScope.Interfaces;
using System;
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

    }
}
