namespace DevToolsNet.AppConfig.Interfaces
{
    public interface IConfigRecover
    {
        List<AppConfig> RecoverConfigs(string app, string? group, string? pc, DateTime date);
        void SetConnectionString(string connectionString);
    }
}