using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Tareas;

namespace CuidadosModernos.BusinessService.Interfaces.Tareas
{
    public interface IRegistrarTareaBusinessService : IBusinessService
    {
        void RegistrarTarea(RegistrarTareaCommand command);
    }
}
