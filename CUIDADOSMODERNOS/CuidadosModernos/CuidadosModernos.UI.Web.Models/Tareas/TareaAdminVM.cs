using Cross.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Models
{
    public class TareaAdminVM : ViewModel
    {
        public TareaFiltroVM Filtro { get; set; }
        public ResultViewModel<TareaResultVM> Resultado { get; set; }
        public TareaDetalleVM Detalle { get; set; }

        public TareaAdminVM()
        {
            this.Filtro = new TareaFiltroVM();
            this.Resultado = new ResultViewModel<TareaResultVM>();
            this.Detalle = new TareaDetalleVM();
        }
    }
}
