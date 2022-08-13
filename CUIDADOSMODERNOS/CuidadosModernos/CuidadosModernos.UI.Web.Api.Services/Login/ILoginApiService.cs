using Cross.UI.Web.Api.Services;
using CuidadosModernos.UI.Web.Models;
using CuidadosModernos.UI.Web.Models.Login;

namespace CuidadosModernos.UI.Web.Api.Services.Login
{
    public interface ILoginApiService : IBasicApiService<LoginVM>
    {
        UsuarioVM Ingresar(LoginVM login);
    }
}