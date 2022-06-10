using System;
using System.Configuration;
using System.Windows;
using Grammer.IssueTracking.Core;
using Grammer.IssueTracking.Core.Repositories;
using Grammer.IssueTracking.Core.Utilities;
using Grammer.IssueTracking.Wpf.ViewModels;
using Grammer.IssueTracking.Wpf.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Grammer.IssueTracking.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        private const string JsonConfigurationFile = @"Configuration\appsettings.json";
        private static IConfiguration _config;
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
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
            _config = builder.Build();

            // Configure Services
            ConfigureServices(services);

            // Run Application
            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Register Configuration Options we got from the JSON Settings File
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        private static void RegisterOptions(IServiceCollection services)
        {
            // Initialize Connection Strings
            var connectionStringsOptions = new ConnectionStringOptions();
            _config.GetSection(ConfigOptions.ConnectionStrings).Bind(connectionStringsOptions);

            // Add options into the services
            services.AddOptions();
        }

        /// <summary>
        /// Register All Forms
        /// Missing registration of already used Form will result in program failure during build.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        private static void RegisterForms(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            
            // Register factories for new Windows
            services.AddTransient<BookWindowFactory>();
        }

        /// <summary>
        /// Register All Repositories
        /// Missing registration of already used Repository will result in program failure during build.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IssueRepository>();
            services.AddSingleton<KnihaRepository>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Initialize Configuration
            RegisterOptions(services);
            
            // Initialize DB
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DataAll"));
            });
            services.AddSingleton<RepositoryContext>();

            // Initialize MVVM
            RegisterViewModels(services);
            RegisterRepositories(services);
            RegisterForms(services);
        }

        private static void RegisterViewModels(IServiceCollection services)
        {
            services.AddSingleton<UserViewModel>();
            services.AddSingleton<KnihaViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs startupEventArgs)
        {
            var viewModel = _serviceProvider.GetService<UserViewModel>();
            var mainWindow = _serviceProvider.GetService<MainWindow>();

            if (mainWindow == null) return;

            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}