using Cross.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Models
{
    public class EmpleadaAdminVM : ViewModel
    {
        public EmpleadaFiltroVM Filtro { get; set; }

        public ResultViewModel<EmpleadaResultVM> Resultado { get; set; }

        public EmpleadaDetalleVM Detalle { get; set; }

        public EmpleadaAdminVM()
        {
            this.Filtro = new EmpleadaFiltroVM();

            this.Resultado = new ResultViewModel<EmpleadaResultVM>();

            this.Detalle = new EmpleadaDetalleVM();
        }
    }
}
