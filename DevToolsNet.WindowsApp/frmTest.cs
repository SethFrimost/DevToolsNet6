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
            //this.treeServerConnections1.LoadServers(servers);
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", "1");
            dic.Add("cod", "\"Hola\"");
            dic.Add("cod2", "\"Hola\"");
            dic.Add("cod3", "\"Hola\"");
            dic.Add("cod4", "\"Hola\"");
            dic.Add("cod5", "\"Hola\"");

            dicEdit.Dictionary = dic;
        }
    }
}
