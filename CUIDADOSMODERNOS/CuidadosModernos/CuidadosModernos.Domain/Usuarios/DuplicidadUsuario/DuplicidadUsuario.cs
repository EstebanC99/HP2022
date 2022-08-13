using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.ValueObjects.Usuarios;

namespace CuidadosModernos.Domain.Usuarios.DuplicidadUsuario
{
    public class DuplicidadUsuario : IDuplicidadUsuario
    {
        private IDuplicidadUsuarioDomainService DuplicidadUsuarioDomainService { get; set; }

        public DuplicidadUsuario(IDuplicidadUsuarioDomainService duplicidadUsuarioDomainService)
        {
            this.DuplicidadUsuarioDomainService = duplicidadUsuarioDomainService;
        }

        public virtual void Validar(RegistrarUsuario usuario)
        {
            var usuarioExistente = this.DuplicidadUsuarioDomainService.ExisteUsuario(usuario.Username);

            if (usuarioExistente != null && usuarioExistente.Persona.ID != usuario.Persona.ID)
                throw new ValidationException(Messages.YaExisteUsuarioConNombreXFormat(usuario.Username));
        }
    }
}
