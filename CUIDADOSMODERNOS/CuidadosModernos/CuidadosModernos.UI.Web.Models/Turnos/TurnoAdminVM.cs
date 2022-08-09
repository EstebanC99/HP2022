using Cross.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Models
{
    public class TurnoAdminVM : ViewModel
    {
        public TurnoDetalleVM Detalle { get; set; }

        public ResultViewModel<TurnoResultVM> Resultado { get; set; }

        public TurnoAdminVM()
        {
            this.Detalle = new TurnoDetalleVM();
            this.Resultado = new ResultViewModel<TurnoResultVM>();
        }
    }
}
