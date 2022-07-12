using System;
using System.ServiceProcess;
using Serilog;

namespace BrainRock.Service
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        private static void Main(params string[] args)
        {
            BuildSerilog();
            if (Environment.UserInteractive)
                using (var server = new RockService())
                {
                    server.Start();
                    Console.ReadLine();
                }
            else
                ServiceBase.Run(new ServiceBase[] { new RockService() });
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