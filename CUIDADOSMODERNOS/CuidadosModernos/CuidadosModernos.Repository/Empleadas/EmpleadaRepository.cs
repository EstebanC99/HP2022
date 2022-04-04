using CuidadosModernos.Domain.Generales;
using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuidadosModernos.Repository.Empleadas
{
    public class EmpleadaRepository: Repository<Empleada, int>, IEmpleadaRepository
    {
        public EmpleadaRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {
        }


    }
}
