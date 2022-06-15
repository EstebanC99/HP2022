using CuidadosModernos.Domain.Usuarios;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Repository.Empleadas
{
    public class EmpleadaRepository : Repository<Empleada, int>, IEmpleadaRepository
    {
        public EmpleadaRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {
        }


    }
}
