using DevToolsNet.AppConfig;
using DevToolsNet.AppConfig.SQL;
using DevToolsNet.DB.Generator;
using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Runner;
using DevToolsNet.DB.Runner.Interfaces;
using DevToolsNet.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace DevToolsNet.WebServer.Data
{
    public static class Services
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IConfiguration Configuration { get; set; }

        internal static void LoadConfigs(ConfigurationManager confBuilder)
        {
            Configuration = confBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            var appConn = Configuration.GetConnectionString("AppConfig");
            if (!string.IsNullOrEmpty(appConn))
            {
                try
                {
                    AppConfigSQLRecover confRecover = new AppConfigSQLRecover(Configuration);
                    AplicationConfigManager appConfMan = new AplicationConfigManager(confRecover, new DevToolsNet.Json.JsonSerializer());
                    appConfMan.LoadConfigs("DevToolsNet.WebServer", null, Environment.MachineName, DateTime.Now);

                    foreach (var s in appConfMan.AppConfigs)
                    {
                        confBuilder.AddJsonStream(s.Value.GenerateStreamFromString());
                    }
                }
                catch (Exception ex)
                {
                    // log config
                }
            }
        }

        internal static void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();

            // configs
            services.AddSingleton<IConfiguration>(Configuration);

            // config objects
            services
                .Configure<LocalXmlTemplateConfigSection>(Configuration.GetSection("LocalXmlTemplateConfig"))
                .Configure<ConnectionStringGroupCollection>(Configuration.GetSection("SqlRunner"));

            // clases
            services
                .AddScoped<IGenerators, LocalXmlTemplateGenerators>()
                //.AddTransient<ICodeGenerator, GeneratorFromXml>()
                .AddTransient<ITableDataInfoRecover, SqlDataInfoRecover>()
                .AddTransient<ICommandRuner, SQLCommandRunner>()
                .AddTransient<IDbConnection, SqlConnection>();

            // 
            /*services
                .AddTransient<frmMain>()
                .AddTransient<frmGenerador>()
                .AddTransient<frmSQLRunner>();*/

            
        }

    }
}
