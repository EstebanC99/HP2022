using Cross.BusinessService.Interfaces;
using CuidadosModernos.Domain.Horarios;

namespace CuidadosModernos.BusinessService.Interfaces.Tareas
{
    public interface IAsignarTareaEmpleadaTurnoBusinessService : IBusinessService
    {
        void AsignarTarea(Turno turno);
    }
}
