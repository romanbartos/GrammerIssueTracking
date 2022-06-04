using Grammer.IssueTracking.WinForms.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grammer.IssueTracking.WinForms.Views;

namespace Grammer.IssueTracking.WinForms
{
    static partial class Program
    {
        private const string JsonConfigurationFile = "appsettings.json";
        public static IConfiguration config;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>  
        [STAThread]
        static void Main()
        {
            // Initialize Application
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize Dependency Injection
            var services = new ServiceCollection();

            // Serilog Setup Constants
            const string outputTemplate =
                @"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}";
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmm");

            // Create Serilog
            var serilogLogger = new LoggerConfiguration()
                .WriteTo.File($"logs/IdealProductionPlanning_{timestamp}.log", outputTemplate: outputTemplate)
                .CreateLogger();

            // Add Serilog into services
            services.AddLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Information);
                x.AddSerilog(serilogLogger, true);
            });

            // Assign Configuration
            var builder = new ConfigurationBuilder().AddJsonFile(JsonConfigurationFile, true, true);
            config = builder.Build();

            // Configure Services
            ConfigureServices(services);

            // Run Application
            using var serviceProvider = services.BuildServiceProvider();
            var formMain = serviceProvider.GetRequiredService<FormMain>();

            Application.Run(formMain);
        }
    }
}
