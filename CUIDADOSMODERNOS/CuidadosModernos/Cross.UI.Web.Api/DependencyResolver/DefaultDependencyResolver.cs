using Cross.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Cross.UI.Web.Api.DependencyResolver
{
    public class DefaultDependencyResolver : DefaultDependencyScope, IDependencyResolver
    {
        public DefaultDependencyResolver(IoCContainer container) : base(container)
        {

        }

        public IDependencyScope BeginScope()
        {
            var childContainer = this.Container.GetNestedContainer();

            return new DefaultDependencyScope(childContainer);
        }
    }

    public class DefaultDependencyScope : IDependencyScope
    {
        protected IIoCContainer Container { get; private set; }

        public DefaultDependencyScope(IIoCContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return this.Container.TryResolve(serviceType);
            }

            return this.Container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Container.ResolveAll(serviceType);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Container.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
