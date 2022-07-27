using Cross.UI.Web.Api.Services;
using CuidadosModernos.UI.Web.Models;
using System.Collections.Generic;

namespace CuidadosModernos.UI.Web.Api.Services.Tareas
{
    public interface IAdministrarTareaApiService : IApiService
    {
        List<TareaResultVM> GetAll();

        TareaDetalleVM GetByID(TareaFiltroVM filtroVM);

        void RegistrarTarea(TareaDetalleVM viewModel);

        void ModificarTarea(TareaDetalleVM viewModel);

        void DesactivarTarea(TareaResultVM tareaVM);
    }
}