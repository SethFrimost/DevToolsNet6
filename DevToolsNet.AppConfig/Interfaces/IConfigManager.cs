using System;
using System.Collections.Generic;

namespace DevToolsNet.AppConfig.Interfaces
{
    public interface IConfigManager
    {
        List<AppConfig> AppConfigs { get; }

        List<AppConfig> LoadConfigs(string app, string group, string pc, DateTime date);
        AppConfig GetConfig(string name);
        string GetConfigValue(string name);
        T GetConfig<T>(string name);
    }
}