using CuidadosModernos.Business.Domain.Queries.Usuarios;

namespace CuidadosModernos.BusinessService.Interfaces.Login
{
    public interface ILoginBusinessService : IBasicBusinessService<UsuarioCriteria>
    {
        UsuarioDataView Validar(UsuarioCriteria criteria);
    }
}
