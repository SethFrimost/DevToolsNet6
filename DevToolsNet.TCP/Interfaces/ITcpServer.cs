using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.TCP.Interfaces
{
    public interface ITcpServer
    {
        string Key { get; }
        void Start();
        void Stop();
        void SendToClients(string message);
        void SendToLastServerClient(string message);

        event EventHandler DataReaded;
        event EventHandler ClientConected;

    }
}
