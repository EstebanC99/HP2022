using Cross.CrossCutting.IoC;
using Cross.UI.Web.Api.Config;
using Cross.UI.Web.Api.DependencyResolver;
using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using System.Web.Http;

namespace Cross.UI.Web.Api
{
    public class WebApiApplicationBase : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            this.RegisterDependencyResolver();
            this.RegisterControllerAndDependencies();
            this.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);
            this.OnApplicationStart();
        }

        protected virtual void OnApplicationStart() { }

        public virtual void RegisterGlobalFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {

        }

        protected virtual void RegisterControllerAndDependencies()
        {
            IoCContainer.Instance.Register<IDbContextScopeFactory, DbContextScopeFactory>();
            IoCContainer.Instance.Register<IAmbientDbContextLocator, AmbientDbContextLocator>();
        }

        protected virtual void RegisterDependencyResolver()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new DefaultDependencyResolver(IoCContainer.Instance);
        }

        protected void Application_End()
        {
            this.OnApplicationEnd();
        }

        protected virtual void OnApplicationEnd() { }
    }
}
