using Cross.Business.Domain;
using Cross.BusinessService.Interfaces;
using Cross.CrossCutting.IoC;
using Cross.ResourceAccess.Repository;
using Cross.UI.Web.Api;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Domain.Factories.Empledas;
using CuidadosModernos.Domain.Factories.Tareas;
using CuidadosModernos.Domain.Factories.Turnos;
using CuidadosModernos.Repository;
using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using System.Data.Entity;

namespace CuidadosModernos.UI.Web.Api
{
    public class WebApiApplication : WebApiApplicationBase
    {
        protected override void RegisterControllerAndDependencies()
        {
            base.RegisterControllerAndDependencies();

            #region Register DbContextScope

            IoCContainer.Instance.Register<IDbContextFactory, CuidadosModernosDbContextFactory>();
            IoCContainer.Instance.Register<IDbContextScopeFactory, DbContextScopeFactory>();

            #endregion

            #region Register Factories

            IoCContainer.Instance.Register<IEmpleadaFactory, EmpleadaFactory, IIoCContainer>(IoCContainer.Instance);
            IoCContainer.Instance.Register<ITareaFactory, TareaFactory, IIoCContainer>(IoCContainer.Instance);
            IoCContainer.Instance.Register<ITurnoFactory, TurnoFactory, IIoCContainer>(IoCContainer.Instance);
            IoCContainer.Instance.Register<ITareaTurnoFactory, TareaTurnoFactory, IIoCContainer>(IoCContainer.Instance);

            #endregion

            #region Register ApiServices

            IoCContainer.Instance.RegisterAssembly<IApiService>("CuidadosModernos.UI.Web.Api.Services");

            #endregion

            #region Register Business Services

            IoCContainer.Instance.RegisterAssembly<IBusinessService>("CuidadosModernos.Business.Logic");

            #endregion

            #region Register Domain

            #endregion

            #region Register Domain Services

            IoCContainer.Instance.RegisterAssembly<IDomainService>("CuidadosModernos.Business.Logic");

            #endregion

            #region Register Repositories

            IoCContainer.Instance.RegisterAssembly<IDataAccessBase>("CuidadosModernos.ResourceAccess.Repository");

            #endregion
        }

        protected override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Database.SetInitializer<CuidadosModernosDbContext>(null);
        }

        protected override void OnApplicationEnd()
        {
            base.OnApplicationEnd();
        }
    }
}
