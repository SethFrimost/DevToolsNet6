using DevToolsNet.Shared.Configs;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Net.Security;
using System.Security;

namespace DevToolsNet6.PowerShell
{
    public class PowerShellRunner : IDisposable
    {
        ServerConfig server;
        Runspace runspace;
        System.Management.Automation.PowerShell ps;

        public delegate void MessageOutDelegate(string msg);
        public event MessageOutDelegate ErrorMessaje;
        public event MessageOutDelegate WarningMessaje;
        public event MessageOutDelegate InfoMessaje;
        public event MessageOutDelegate TextMessaje;

        public PowerShellRunner(ServerConfig server, string user, SecureString pass) 
        { 
            this.server = server;
            crearPowerShell(user, pass);
        }

        private void crearPowerShell(string user, SecureString pass)
        { 
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
            connectionInfo.ComputerName = server.IP;
            connectionInfo.Credential = new PSCredential(user, pass); ;

            runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            ps = System.Management.Automation.PowerShell.Create(runspace);

            ps.Streams.Error.DataAdded += (s, e) => {
                var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
                if(streamObjectsReceived != null) ErrorMessaje?.Invoke(streamObjectsReceived[e.Index].ToString());
            };
            ps.Streams.Warning.DataAdded += (s, e) => {
                var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
                if (streamObjectsReceived != null) WarningMessaje?.Invoke(streamObjectsReceived[e.Index].ToString());
            };
            ps.Streams.Information.DataAdded += (s, e) => {
                var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
                if (streamObjectsReceived != null) InfoMessaje?.Invoke(streamObjectsReceived[e.Index].ToString());
            };
        }
        

        public async void RunCommand(string command)
        {
            var pipelineObjects = await ps.InvokeAsync().ConfigureAwait(false);

            foreach (var item in pipelineObjects)
            {
                if(item?.BaseObject != null) TextMessaje?.Invoke(item.BaseObject.ToString());
            }
        }

        public void Dispose()
        {
            if (runspace != null)
            {
                runspace.Close(); 
                runspace.Dispose();
            }

            if (ps != null)
            {
                ps.Stop();
                ps.Dispose();
            }
        }
    }
}