using System;
using System.Collections.Generic;

namespace Cross.CrossCutting.IoC
{
    public interface IIoCContainer : IDisposable
    {
        void Register<TPluginType, TConcreteType>() where TConcreteType : TPluginType;

        void Register<TPluginType, TConcreteType, TCtor>(TCtor ctor) where TConcreteType : TPluginType;

        void RegisterSingleton<TPluginType, TConcreteType>() where TConcreteType : TPluginType;

        void RegisterSingleton<TPluginType, TConcreteType, TCtor>(TCtor ctor) where TConcreteType : TPluginType;

        void RegisterScoped<TPluginType, TConcreteType>() where TConcreteType : TPluginType;

        void Forward<TFrom, TTo>() where TFrom : class where TTo : class;

        void RegisterAssembly<TPluginType>(string assemblyName);

        T Resolve<T>();

        object Resolve(Type pluginType);

        IEnumerable<object> ResolveAll(Type pluginType);

        IEnumerable<T> ResolveAll<T>();

        object TryResolve(Type pluginType);

        T TryResolve<T>();

        IIoCContainer GetNestedContainer();
    }
}