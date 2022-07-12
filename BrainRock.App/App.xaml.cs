using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using BrainRock.App.Modules.Main;
using BrainRock.Lib.Core;
using Serilog;

namespace BrainRock.App
{
    /// <summary>
    ///     Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            BuildSerilog();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Current.DispatcherUnhandledException += DispatcherOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Information("Starting");

            base.OnStartup(e);

            BootStrap.Start();

            BootStrap.RootWindow = new MainWindow
            {
                // The window has to be created before the root visual - all to do with the idling service initialising correctly...
                DataContext = BootStrap.RootVisual
            };

            BootStrap.RootWindow.Closed += HandleClosed;
            Current.Exit += HandleExit;

            // Let's go...
            BootStrap.RootWindow.Show();

            Log.Information("Started");
        }

        private void HandleClosed(object sender, EventArgs e)
        {
            BootStrap.Stop();
            HttpWrapper.Dispose();
        }

        private static void HandleExit(object sender, ExitEventArgs e)
        {
            Log.Information("End!");
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Log.Information("Unhandled app domain exception");
            HandleException(args.ExceptionObject as Exception);
        }

        private static void DispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            Log.Information("Unhandled dispatcher thread exception");
            args.Handled = true;

            HandleException(args.Exception);
        }

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs args)
        {
            Log.Information("Unhandled task exception");
            args.SetObserved();

            HandleException(args.Exception.GetBaseException());
        }

        private static void HandleException(Exception exception)
        {
            Log.Error(exception, "HandleException ");
        }

        private static ILogger BuildSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File("serilog/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            return Log.Logger;
        }
    }
}