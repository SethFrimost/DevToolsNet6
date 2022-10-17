using System.ServiceProcess;
namespace DevToolsNet.WinServicesManager;

public class WinServicesManager
{
    WindowsServiceConfig conf;
    List<ServiceController> sc;

    public WinServicesManager(WindowsServiceConfig windowsServiceConfig)
    {
        conf = windowsServiceConfig;
    }

    
}