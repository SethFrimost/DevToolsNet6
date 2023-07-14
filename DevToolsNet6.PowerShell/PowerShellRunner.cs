using DevToolsNet.Shared.Configs;
using System.Management.Automation;            
using System.Management.Automation.Runspaces;  
using System.Net.Security;
using System.Security;
using static DevToolsNet.PowerShell.IPowerShellRunner;

namespace DevToolsNet.PowerShell
{
    public class PowerShellRunner : IDisposable, IPowerShellRunner
    {
        ServerConfig server;
        Runspace runspace;
        System.Management.Automation.PowerShell ps;

        public string Key { get; set; }
       
        public event MessageOutDelegate ErrorMessaje;
        public event MessageOutDelegate WarningMessaje;
        public event MessageOutDelegate InfoMessaje;
        public event MessageOutDelegate TextMessaje;

        public PowerShellRunner()
        {
            crearPowerShell(null, null);
        }

        public PowerShellRunner(ServerConfig server, string user, SecureString pass)
        {
            this.server = server;
            crearPowerShell(user, pass);
        }
        

        private void crearPowerShell(string user, SecureString pass)
        {
            if (server == null || string.IsNullOrEmpty(user) || pass == null)
            {
                ps = System.Management.Automation.PowerShell.Create();
            }
            else
            {
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
                connectionInfo.ComputerName = server.IP;
                connectionInfo.Credential = new PSCredential(user, pass); ;

                runspace = RunspaceFactory.CreateRunspace(connectionInfo);
                runspace.Open();
                ps = System.Management.Automation.PowerShell.Create(runspace);
            }

            ps.Streams.Error.DataAdded += (s, e) =>
            {
                var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
                if (streamObjectsReceived != null) ErrorMessaje?.Invoke(this, streamObjectsReceived[e.Index].ToString());
            };
            ps.Streams.Warning.DataAdded += (s, e) =>
            {
                var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
                if (streamObjectsReceived != null) WarningMessaje?.Invoke(this, streamObjectsReceived[e.Index].ToString());
            };
            ps.Streams.Information.DataAdded += (s, e) =>
            {
                var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
                if (streamObjectsReceived != null) InfoMessaje?.Invoke(this, streamObjectsReceived[e.Index].ToString());
            };
            
            TextMessaje?.Invoke(this, ">");
        }


        public async void RunCommand(string command)
        {
            try
            {
                ps.Commands.Clear();
                ps.Commands.AddScript(command);
                ps.Commands.AddCommand("Out-String");
                
                TextMessaje?.Invoke(this, "> "+ command);

                var pipelineObjects = await ps.InvokeAsync().ConfigureAwait(false);

                foreach (var item in pipelineObjects)
                {
                    if (item?.BaseObject != null) TextMessaje?.Invoke(this, item?.BaseObject?.ToString());
                    else TextMessaje?.Invoke(this, item?.ToString());
                }

                TextMessaje?.Invoke(this, ">");
            }
            catch (Exception ex)
            {
                ErrorMessaje?.Invoke(this, ex.ToString());
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