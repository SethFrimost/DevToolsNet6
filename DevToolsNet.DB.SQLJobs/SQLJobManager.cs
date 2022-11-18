using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Permissions;

namespace DevToolsNet.DB.SQLJobs;

public class SQLJobManager
{
    private string serName;
    private Server server;

    public SQLJobManager(string serverName)
    {
        serName = serverName;
        server = new Server(serName);
    }

    public JobCollection? Jobs { get { return server?.JobServer?.Jobs; } }

}