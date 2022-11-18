using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.Shared.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WindowsApp.ServerTrees
{
    public class TreeServerConnections : TreeServer<ServerConnectionStringCollection>
    {
        
        public TreeServerConnections() : base()
        {
            ilTree.Images.Add("dataBase", DevToolsNet.WindowsApp.Properties.Resources.dataBase);
        }

        public override void LoadServers(ServersConfig<ServerConnectionStringCollection> Servers)
        {
            base.LoadServers(Servers);
        }

        protected override void AddServerData(ServerConnectionStringCollection data, TreeNode node)
        {
            base.AddServerData(data, node);

            if(data.Connections != null) 
            {
                foreach(var c in data.Connections)
                {
                    var n = node.Nodes.Add(node.Name+"_con_"+c.Name,c.Name);
                    n.Tag = c;
                    n.SelectedImageKey = n.ImageKey = "dataBase";
                }
            }
        }
    }
}
