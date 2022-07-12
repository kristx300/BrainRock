using System;
using System.Reflection;
using Autofac;
using Autofac.Core;
using BrainRock.App.Modules;
using BrainRock.App.Modules.Main;

namespace BrainRock.App
{
    public static class BootStrap
    {
        private static ILifetimeScope _rootScope;
        private static IMainViewModel _mainViewModel;

        public static IViewModel RootVisual
        {
            get
            {
                if (_rootScope == null) Start();

                _mainViewModel = _rootScope.Resolve<IMainViewModel>();
                return _mainViewModel;
            }
        }

        public static MainWindow RootWindow { get; set; }


        public static void Start()
        {
            if (_rootScope != null) return;

            var builder = new ContainerBuilder();
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IService).IsAssignableFrom(t))
                .SingleInstance()
                .AsImplementedInterfaces();


            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IViewModel).IsAssignableFrom(t))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.Name.EndsWith("Window"))
                .SingleInstance()
                .AsSelf();

            _rootScope = builder.Build();
        }

        public static void Stop()
        {
            _rootScope.Dispose();
        }

        public static T Resolve<T>()
        {
            if (_rootScope == null) throw new Exception("Bootstrapper hasn't been started!");

            return _rootScope.Resolve<T>(Array.Empty<Parameter>());
        }

        public static T Resolve<T>(Parameter[] parameters)
        {
            if (_rootScope == null) throw new Exception("Bootstrapper hasn't been started!");

            return _rootScope.Resolve<T>(parameters);
        }
    }
}