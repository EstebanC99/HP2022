using Cross.UI.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace CuidadosModernos.UI.Web.Models
{
    public class LoginVM : FilterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
