using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.ServiceProcess;

namespace DevToolsNet.WinServicesManager;

[SupportedOSPlatform("windows")]
public class WindowsServicesManager
{
    WinServicesManagerConfig conf;
    List<WindowsServiceStatus> services;

    public delegate void ServiceStatusUpdateDelegate(WindowsServiceStatus se);
    public ServiceStatusUpdateDelegate ServiceStatusUpdate;

    public WindowsServicesManager(IOptions<WinServicesManagerConfig> windowsServiceConfig)
    {
        conf = windowsServiceConfig.Value;
        services = new List<WindowsServiceStatus>();
    }

    public WindowsServicesManager(WinServicesManagerConfig windowsServiceConfig)
    {
        conf = windowsServiceConfig;
        services = new List<WindowsServiceStatus>();
    }

    public Task<List<WindowsServiceStatus>> LoadServices()
    {
        var t = new Task<List<WindowsServiceStatus>>(() =>
        {
            services.ForEach(x => x.ServController.Dispose());
            services.Clear();

            foreach (var ser in conf.Servers)
            {
                foreach (var s in ser.Servicios)
                {
                    var se = new WindowsServiceStatus();
                    se.Server = ser.Name;
                    se.Name = s;
                    se.ServController = new ServiceController(s, ser.IP);
                    services.Add(se);
                    ManageService(se, WinServicesManagerConfig.ServiceAction.Refresh);
                }
            }
            return services;
        });
        t.Start();
        return t;
    }

    public Task<WindowsServiceStatus> ManageService(WindowsServiceStatus se, WinServicesManagerConfig.ServiceAction action)
    {
        var t = new Task<WindowsServiceStatus>(() =>
        {
            try
            {
                se.exception = null;
                if(se.ServController != null)
                { 
                    switch(action)
                    {
                        case WinServicesManagerConfig.ServiceAction.Play: se.ServController.Start(); break;
                        case WinServicesManagerConfig.ServiceAction.Stop: se.ServController.Stop(); break;
                        case WinServicesManagerConfig.ServiceAction.Refresh: se.ServController.Refresh(); break;
                        case WinServicesManagerConfig.ServiceAction.Restart: 
                            se.ServController.Stop(); 
                            se.ServController.Start(); 
                            break;
                    }

                    se.LastStatus = se.ServController.Status;

                    OnServiceStatusUpdate(se);
                }
            }
            catch (Exception ex)
            {
                se.exception = ex;
                //se.LastStatus = ServiceControllerStatus.;
                OnServiceStatusUpdate(se);
            }

            return se;
        });

        t.Start();

        return t;
    }

    public void OnServiceStatusUpdate(WindowsServiceStatus se)
    {
        ServiceStatusUpdate?.Invoke(se);
    }
}