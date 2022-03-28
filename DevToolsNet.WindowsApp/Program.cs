using DevToolsNet.DB.Generator;
using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Runner;
using DevToolsNet.DB.Runner.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace DevToolsNet.WindowsApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IConfiguration Configuration { get; set; }

        /// <summary>The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ConfigurationManager confManager = new ConfigurationManager();
            Configuration = confManager
                .AddJsonFile("appsettings.json",optional:false, reloadOnChange:true)
                .Build();
            
            var services = new ServiceCollection();
            ConfigureServices(confManager, services);
            ServiceProvider = services.BuildServiceProvider();
            

            var form = ServiceProvider.GetRequiredService<frmMain>();
            Application.Run(form);
        }

        private static void ConfigureServices(ConfigurationManager confManager, IServiceCollection services)
        {
            // configs
            services.AddSingleton<IConfiguration>(Configuration);

            // config objects
            services
                .Configure<LocalXmlTemplateConfigSection>(Configuration.GetSection("LocalXmlTemplateConfig"))
                .Configure<ConnectionStringGroupCollection>(Configuration.GetSection("SqlRunner"));
          
            // clases
            services
                .AddScoped<IGenerators, LocalXmlTemplateGenerators>()
                .AddTransient<ICodeGenerator, GeneratorFromXml>()
                .AddTransient<ITableDataInfoRecover, SqlDataInfoRecover>()
                .AddTransient<ICommandRuner, SQLCommandRunner>()
                .AddTransient<IDbConnection, SqlConnection>();
            
            // forms
            services
                .AddTransient<frmMain>()
                .AddTransient<frmGenerador>()
                .AddTransient<frmSQLRunner>();
            
        }
    }
}