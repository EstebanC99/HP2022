using Cross.CrossCutting.Mapping;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Business.Domain.Queries.Usuarios;
using CuidadosModernos.BusinessService.Interfaces.Login;
using CuidadosModernos.UI.Web.Models;
using CuidadosModernos.UI.Web.Models.Login;

namespace CuidadosModernos.UI.Web.Api.Services.Login
{
    public class LoginApiService : BasicApiService<UsuarioCriteria, LoginVM, ILoginBusinessService>, ILoginApiService
    {
        public LoginApiService(ILoginBusinessService businessService)
            : base(businessService)
        {

        }

        public UsuarioVM Ingresar(LoginVM login)
        {
            var mapper = new Mapper<LoginVM, UsuarioCriteria>(cfg =>
            {
                cfg.CreateMap<LoginVM, UsuarioCriteria>();
            });

            var usuario = this.BusinessService.Validar(mapper.Map(login));

            return new UsuarioVM()
            {
                ID = usuario.ID,
                Username = usuario.Username,
                Rol = usuario.Rol
            };
        }
    }
}
