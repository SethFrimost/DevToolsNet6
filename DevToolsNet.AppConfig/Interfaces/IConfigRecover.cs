namespace DevToolsNet.AppConfig.Interfaces
{
    public interface IConfigRecover
    {
        List<AppConfig> RecoverConfigs(string app, string pc, DateTime date);
    }
}