using DevToolsNet.AppConfig.Interfaces;
using DevToolsNet.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Runtime.Serialization;

namespace DevToolsNet.AppConfig
{
    public class AplicationConfigManager : IConfigManager
    {
        public List<AppConfig> AppConfigs { get; private set; } 
        private IConfigRecover configRecover;
        private ISerializer confSerializer;


        public AplicationConfigManager(IConfigRecover configRecover, ISerializer confSerializer)
        {
            this.configRecover = configRecover;
        }


        public List<AppConfig> LoadConfigs(string app, string? group, string? pc, DateTime date)
        {
            AppConfigs = configRecover.RecoverConfigs(app, group, pc, date);
            return AppConfigs;
        }

        public AppConfig GetConfig(string name)
        {
            return AppConfigs?.Find(x=>x.Name == name);
        }

        public T GetConfig<T>(string name)
        {
            var d = GetConfig(name)?.Value;
            if (d == null || confSerializer == null) return default(T);
            else return confSerializer.Deserialize<T>(d);
        }

        public string GetConfigValue(string name)
        {
            return AppConfigs?.Find(x => x.Name == name)?.Value;
        }
    }
}