using Cross.UI.Web.Api;
using Cross.UI.Web.Api.Controllers;
using CuidadosModernos.UI.Web.Api.Services.Login;
using CuidadosModernos.UI.Web.Models;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiControllerBase<ILoginApiService>
    {
        public AccountController(ILoginApiService apiService) : base(apiService)
        {

        }

        [HttpPost]
        public IHttpActionResult Login(LoginVM login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioVM = this.ApiService.Ingresar(login);

            if (usuarioVM != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(usuarioVM.Username, usuarioVM.ID, usuarioVM.Rol);
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}