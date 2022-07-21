using Cross.UI.Web.Api;
using CuidadosModernos.UI.Web.Models;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        public AccountController()
        {

        }

        [HttpPost]
        public IHttpActionResult Login(LoginVM login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (login.Password == "1234")
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}