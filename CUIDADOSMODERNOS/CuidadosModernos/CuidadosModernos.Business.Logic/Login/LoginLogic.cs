using Cross.Crosscutting.Exceptions;
using CuidadosModernos.Business.Domain.Commands.Turnos;
using CuidadosModernos.Business.Domain.Queries.Usuarios;
using CuidadosModernos.BusinessService.Interfaces.Login;
using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.CrossCutting.Global.Roles;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.ResourceAccess.Repository.Usuarios.Login;
using EntityFramework.DbContextScope.Interfaces;
using System;

namespace CuidadosModernos.Business.Logic.Login
{
    public class LoginLogic : BasicBusinessLogic<UsuarioCriteria, ILoginUsuarioRepository>, ILoginBusinessService
    {
        private IRegistrarIngresoTurnoBusinessService RegistrarIngresoTurnoBusinessService { get; set; }

        public LoginLogic(IDbContextScopeFactory dbContextScopeFactory,
                          ILoginUsuarioRepository repository,
                          IRegistrarIngresoTurnoBusinessService registrarIngresoTurnoBusinessService)
            : base(dbContextScopeFactory, repository)
        {
            this.RegistrarIngresoTurnoBusinessService = registrarIngresoTurnoBusinessService;
        }

        public UsuarioDataView Validar(UsuarioCriteria criteria)
        {
            using (var context = this.DbContextScopeFactory.Create())
            {
                var usuario = this.Repository.GetUser(criteria);

                if (usuario == null)
                    throw new ValidationException(Messages.UsuarioOContraseniaIncorrectos);

                this.RegistrarIngresoEmpleada(usuario);

                context.SaveChanges();

                return new UsuarioDataView()
                {
                    ID = usuario.ID,
                    Username = usuario.Username,
                    Rol = usuario.Rol.Descripcion
                };
            }
        }

        private void RegistrarIngresoEmpleada(Usuario usuario)
        {
            if (usuario.Rol.ID == Roles.Encargada)
                return;

            var registrarIngreso = new RegistrarIngresoTurnoCommand()
            {
                FechaIngreso = DateTime.Now,
                EmpleadaID = usuario.Persona.ID
            };

            this.RegistrarIngresoTurnoBusinessService.FinalizarTurnoAnterior(registrarIngreso);

            this.RegistrarIngresoTurnoBusinessService.RegistrarIngreso(registrarIngreso);
        }
    }
}
