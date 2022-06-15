using Cross.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Models
{
    public class EmpleadaDetalleVM : ViewModel
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public int EncargadaID { get; set; }
    }
}
