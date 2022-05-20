using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GrammerIssueTracking.Views;
using GrammerIssueTracking.Utilities;
using GrammerIssueTracking.Repositories;

namespace GrammerIssueTracking
{
    static partial class Program
    {
        /// <summary>
        /// Register Dependency Injection services
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <param name="argumentOptions">Arguments to be registered and globally accessible</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Initialize Configuration
            RegisterOptions(services);
                        
            // Initialize MVVM
            RegisterForms(services);
            RegisterRepositories(services);
        }

        /// <summary>
        /// Register Configuration Options we got from the JSON Settings File
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        private static void RegisterOptions(IServiceCollection services)
        {
            // Initialize Connection Strings
            var connectionStringsOptions = new ConnectionStringOptions();
            config.GetSection(ConfigOptions.ConnectionStrings).Bind(connectionStringsOptions);
            
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
            services.AddScoped<FormMain>();
            services.AddScoped<FormAdmin>();
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
            //services.AddSingleton<ActionPlanPointRepository>();
            //services.AddSingleton<ActionPlanRepository>();
            //services.AddSingleton<ActionRepository>();
            //services.AddSingleton<CustomerRepository>();
            //services.AddSingleton<DepartmentRepository>();
            //services.AddSingleton<EffectivityControlRepository>();
            //services.AddSingleton<EmailRepository>();
            //services.AddSingleton<EmployeeRepository>();
            //services.AddSingleton<ProjectRepository>();
        }
    }
}
