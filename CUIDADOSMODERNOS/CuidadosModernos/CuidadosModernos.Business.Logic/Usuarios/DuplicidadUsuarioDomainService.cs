using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.ResourceAccess.Repository.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuidadosModernos.Business.Logic.Usuarios
{
    public class DuplicidadUsuarioDomainService : IDuplicidadUsuarioDomainService
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public DuplicidadUsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }

        public Usuario ExisteUsuario(string username)
        {
            return this.UsuarioRepository.GetByUsername(username);
        }
    }
}
