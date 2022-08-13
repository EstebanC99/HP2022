using Cross.Business.Domain.Queries;

namespace CuidadosModernos.Business.Domain.Queries.Usuarios
{
    public class UsuarioCriteria : Criteria
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
