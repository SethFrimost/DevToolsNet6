using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.Shared.Configs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WindowsApp
{
    public partial class frmTest : Form
    {
        ServersConfig<ServerConnectionStringCollection> servers;

        public frmTest(IOptions<ServersConfig<ServerConnectionStringCollection>> config)
        {
            InitializeComponent();
            servers = config.Value;
            this.treeServerConnections1.LoadServers(servers);
        }


    }
}
