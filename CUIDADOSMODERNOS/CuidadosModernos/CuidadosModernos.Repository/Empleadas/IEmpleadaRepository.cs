using Cross.ResourceAccess.Repository;
using CuidadosModernos.Business.Domain.Queries.Empleadas;
using CuidadosModernos.Domain.Usuarios;
using System.Collections.Generic;

namespace CuidadosModernos.Repository.Empleadas
{
    public interface IEmpleadaRepository : IRepository<Empleada, int>
    {
        List<EmpleadaDataView> GetAll();
    }
}