using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.Configs;
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
            services.AddSingleton<IConfiguration>(Configuration);

            services
                .Configure<LocalXmlTemplateConfigSection>(Configuration.GetSection("LocalXmlTemplateConfig"));
          
            services
                .AddScoped<DevToolsNet.DB.Generator.Interfaces.IGenerators, DevToolsNet.DB.Generator.LocalXmlTemplateGenerators>()
                .AddScoped<DevToolsNet.DB.Generator.Interfaces.ICodeGenerator, DevToolsNet.DB.Generator.GeneratorFromXml>()
                .AddScoped<DevToolsNet.DB.Generator.Interfaces.IDataInfoRecover, DevToolsNet.DB.Generator.SqlDataInfoRecover>()
                .AddScoped<IDbConnection, SqlConnection>();

            services
                .AddScoped<frmMain>()
                .AddScoped<frmGenerador>();
        }
    }
}