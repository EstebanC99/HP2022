using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.CrossCutting.IoC
{
    internal class AllInterfacesConvention<TPluginType> : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed))
            {
                foreach (var @interface in type.GetInterfaces())
                {
                    if (typeof(TPluginType).IsAssignableFrom(@interface))
                    {
                        registry.For(@interface).Use(type);
                    }
                }
            }
        }
    }

    public sealed class IoCContainer : IIoCContainer
    {
        #region Patron Singleton

        private static readonly IoCContainer instance = new IoCContainer();

        private readonly IContainer iocContainer;

        private IoCContainer()
        {
            this.iocContainer = new Container();
        }

        private IoCContainer(IContainer container)
        {
            this.iocContainer = container;
        }

        public static IoCContainer Instance { get { return instance; } }

        #endregion

        public void Register<TPluginType, TConcreteType>() where TConcreteType : TPluginType
        {
            this.iocContainer.Configure(x => x.For<TPluginType>().Use<TConcreteType>());
        }

        public void Register<TPluginType, TConcreteType, TCtor>(TCtor ctor) where TConcreteType : TPluginType
        {
            this.iocContainer.Configure(x => x.For<TPluginType>().Use<TConcreteType>().Ctor<TCtor>().Is(ctor));
        }

        public void RegisterSingleton<TPluginType, TConcreteType>() where TConcreteType : TPluginType
        {
            this.iocContainer.Configure(x => x.For<TPluginType>().Use<TConcreteType>().Singleton());
        }

        public void RegisterSingleton<TPluginType, TConcreteType, TCtor>(TCtor ctor) where TConcreteType : TPluginType
        {
            this.iocContainer.Configure(x => x.For<TPluginType>().Use<TConcreteType>().Ctor<TCtor>().Is(ctor).Singleton());
        }

        public void RegisterScoped<TPluginType, TConcreteType>() where TConcreteType : TPluginType
        {
            this.iocContainer.Configure(x => x.For<TPluginType>().Use<TConcreteType>().ContainerScoped());
        }

        public void Forward<TFrom, TTo>()
            where TFrom : class
            where TTo : class
        {
            this.iocContainer.Configure(x => x.Forward<TFrom, TTo>());
        }

        public void RegisterAssembly<TPluginType>(string assemblyName)
        {
            this.iocContainer.Configure(x =>
                                        x.Scan(_ =>
                                        {
                                            _.Assembly(assemblyName);
                                            _.Convention<AllInterfacesConvention<TPluginType>>();
                                        }));
        }

        public T Resolve<T>()
        {
            return this.iocContainer.GetInstance<T>();
        }

        public object Resolve(Type pluginType)
        {
            return this.iocContainer.GetInstance(pluginType);
        }

        public IEnumerable<object> ResolveAll(Type pluginType)
        {
            return this.iocContainer.GetAllInstances(pluginType).Cast<object>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return this.iocContainer.GetAllInstances<T>();
        }

        public object TryResolve(Type pluginType)
        {
            return this.iocContainer.TryGetInstance(pluginType);
        }

        public T TryResolve<T>()
        {
            return this.iocContainer.TryGetInstance<T>();
        }

        public IIoCContainer GetNestedContainer()
        {
            return new IoCContainer(this.iocContainer.GetNestedContainer());
        }

        public void Dispose()
        {
            this.iocContainer.Dispose();
        }
    }
}
