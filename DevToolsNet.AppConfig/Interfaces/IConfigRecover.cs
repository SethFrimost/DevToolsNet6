using System;
using System.Collections.Generic;

namespace DevToolsNet.AppConfig.Interfaces
{
    public interface IConfigRecover
    {
        List<AppConfig> RecoverConfigs(string app, string group, string pc, DateTime date);
        List<AppConfig> RecoverAllConfigs(DateTime date);
        List<AppConfig> GetAllConfigs(List<AppConfig> configs, string app, string group, string pc, DateTime date);
    }
}