using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using System.ServiceProcess;

namespace DevToolsNet.WinServicesManager;

[SupportedOSPlatform("windows")]
public class WindowsServicesManager2
{
    Dictionary<string , WindowsServiceStatus> services = new Dictionary<string ,WindowsServiceStatus>();
    public delegate void ServiceStatusUpdateDelegate(WindowsServiceStatus se);
    public ServiceStatusUpdateDelegate ServiceStatusUpdate;

    public Task<WindowsServiceStatus> TrackService(string key, string server, string serviceName)
    {
        WindowsServiceStatus wss;
        if (services.ContainsKey(key)) wss = services[key];
        else wss = new WindowsServiceStatus();
        wss.Server = server;
        wss.Name = serviceName;
        wss.Key = key;
        wss.ServController = new ServiceController(serviceName, server);
        if (!services.ContainsKey(key))  services.Add(key, wss);
        return ManageService(wss, WinServicesManagerConfig.ServiceAction.Refresh);
    }

    public void UntrakService(string key)
    {
        if(services.ContainsKey(key))
        {
            var sm = services[key];
            sm.ServController.Dispose();
            services.Remove(key);
        }
    }

    public void Clear()
    {
        foreach(var s in services.Values)
        {
            s.ServController.Dispose();
        }
        services.Clear();
    }

    public Task<WindowsServiceStatus> ManageService(WindowsServiceStatus se, WinServicesManagerConfig.ServiceAction action)
    {
        var t = new Task<WindowsServiceStatus>(() =>
        {
            try
            {
                se.exception = null;
                if (se.ServController != null)
                {
                    switch (action)
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