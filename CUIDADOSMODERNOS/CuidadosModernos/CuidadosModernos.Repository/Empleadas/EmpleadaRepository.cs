using CuidadosModernos.Business.Domain.Queries.Empleadas;
using CuidadosModernos.Domain.Usuarios;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CuidadosModernos.Repository.Empleadas
{
    public class EmpleadaRepository : Repository<Empleada, int>, IEmpleadaRepository
    {
        public EmpleadaRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {
        }

        public List<EmpleadaDataView> GetAll()
        {
            return this.DbSet.Where(e => e.Activa).ToList().ConvertAll(e => new EmpleadaDataView()
            {
                ID = e.ID,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                DNI = e.DNI,
                Email = e.Email,
                Telefono = e.Telefono,
                Usuario = e.Usuario,
                Password = e.Password,
                EncargadaID = e.Encargada.ID,
                EncargadaNombreApellido = string.Join(" ", e.Encargada.Nombre, e.Encargada.Apellido)
            });
        }
    }
}
