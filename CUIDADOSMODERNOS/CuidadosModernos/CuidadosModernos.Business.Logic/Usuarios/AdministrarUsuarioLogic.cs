using CuidadosModernos.Business.Domain.Commands.Usuarios;
using CuidadosModernos.BusinessService.Interfaces;
using CuidadosModernos.BusinessService.Interfaces.Usuarios;
using CuidadosModernos.Domain.Factories.Usuarios;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.Usuarios.DuplicidadUsuario;
using CuidadosModernos.Domain.ValueObjects.Usuarios;
using CuidadosModernos.ResourceAccess.Repository.Usuarios;
using EntityFramework.DbContextScope.Interfaces;

namespace CuidadosModernos.Business.Logic.Usuarios
{
    public class AdministrarUsuarioLogic : BusinessLogic<Usuario, IUsuarioRepository>, IAdministrarUsuarioBusinessService, IAdministrarUsuarioDomainService
    {
        private IEntityLoaderBusinessService EntityLoaderBusinessService { get; set; }
        private IUsuarioFactory UsuarioFactory { get; set; }
        private IDuplicidadUsuario DuplicidadUsuario { get; set; }


        public AdministrarUsuarioLogic(IDbContextScopeFactory dbContextScopeFactory,
                                       Usuario aggregate,
                                       IUsuarioRepository repository,
                                       IEntityLoaderBusinessService entityLoaderBusinessService,
                                       IUsuarioFactory usuarioFactory,
                                       IDuplicidadUsuario duplicidadUsuario)
            : base(dbContextScopeFactory, aggregate, repository)
        {
            this.EntityLoaderBusinessService = entityLoaderBusinessService;
            this.UsuarioFactory = usuarioFactory;
            this.DuplicidadUsuario = duplicidadUsuario;
        }

        public void RegistrarNuevoUsuario(RegistrarUsuarioCommand command)
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                this.RegistrarUsuario(command.Username,
                                      command.Password,
                                      this.EntityLoaderBusinessService.GetByID<Persona>(command.PersonaID));
            }
        }

        #region DomainService
        public void RegistrarUsuario(string username, string password, Persona persona)
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                var usuarioNuevo = new RegistrarUsuario()
                {
                    Username = username,
                    Password = password,
                    Persona = persona
                };

                this.Aggregate = this.UsuarioFactory.Crear();
                this.Aggregate.Registrar(usuarioNuevo, this.DuplicidadUsuario);

                this.Repository.Add(this.Aggregate);

                context.SaveChanges();
            }
        }
        #endregion
    }
}
