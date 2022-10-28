using DevToolsNet.AppConfig;
using DevToolsNet.AppConfig.SQL;
using DevToolsNet.DB.Generator;
using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Runner;
using DevToolsNet.DB.Runner.Interfaces;
using DevToolsNet.Extensions;
using DevToolsNet.WinServicesManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;
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

            ConfigurationBuilder confBuilder = new ConfigurationBuilder();
            Configuration = confBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();           

            var appConn = Configuration.GetConnectionString("AppConfig");
            if (!string.IsNullOrEmpty(appConn))
            {
                try
                {
                    AppConfigSQLRecover confRecover = new AppConfigSQLRecover(Configuration);
                    AplicationConfigManager appConfMan = new AplicationConfigManager(confRecover, new DevToolsNet.Json.JsonSerializer());
                    appConfMan.LoadConfigs(Application.ProductName, null, Environment.MachineName, DateTime.Now);
                    foreach(var s in appConfMan.AppConfigs)
                    {
                        confBuilder.AddJsonStream(s.Value.GenerateStreamFromString()); 
                    }
                }
                catch(Exception ex)
                {
                    // log config
                }
            }

            Configuration = confBuilder.Build();
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            
            var form = ServiceProvider.GetRequiredService<frmMain>();
            Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configs
            services.AddSingleton<IConfiguration>(Configuration);

            

            // config objects
            services
                .Configure<LocalXmlTemplateConfigSection>(Configuration.GetSection("LocalXmlTemplateConfig"))
                .Configure<ConnectionStringGroupCollection>(Configuration.GetSection("SqlRunner"))
                .Configure<WinServicesManagerConfig>(Configuration.GetSection("WinServicesManagerConfig"));

            // clases
            services
                .AddScoped<WindowsServicesManager, WindowsServicesManager>()
                .AddScoped<IGenerators, LocalXmlTemplateGenerators>()
                .AddTransient<ICodeGenerator, GeneratorFromXml>()
                .AddTransient<ITableDataInfoRecover, SqlDataInfoRecover>()
                .AddTransient<ICommandRuner, SQLCommandRunner>()
                .AddTransient<IDbConnection, SqlConnection>();
                
            // forms
            services
                .AddTransient<frmMain>()
                .AddTransient<frmGenerador>()
                .AddTransient<frmSQLRunner>()
                .AddTransient<frmWinServices>();
            
        }
    }
}