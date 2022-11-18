using DevToolsNet.WinServicesManager;
using DevToolsNet.Shared.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WindowsApp.ServerTrees
{
    public class TreeServerServices : TreeServer<WindowsServiceConfig>
    {
        public TreeServerServices() : base() 
        {
            ilTree.Images.Add("Wait", DevToolsNet.WindowsApp.Properties.Resources.help2);
            ilTree.Images.Add("Error", DevToolsNet.WindowsApp.Properties.Resources.error);
            ilTree.Images.Add("Stopped", DevToolsNet.WindowsApp.Properties.Resources.media_stop_red);
            ilTree.Images.Add("StartPending", DevToolsNet.WindowsApp.Properties.Resources.media_play);
            ilTree.Images.Add("StopPending", DevToolsNet.WindowsApp.Properties.Resources.media_stop_red);
            ilTree.Images.Add("Running", DevToolsNet.WindowsApp.Properties.Resources.media_play_green);
            ilTree.Images.Add("ContinuePending", DevToolsNet.WindowsApp.Properties.Resources.media_play);
            ilTree.Images.Add("PausePending", DevToolsNet.WindowsApp.Properties.Resources.media_pause);
            ilTree.Images.Add("Paused", DevToolsNet.WindowsApp.Properties.Resources.media_pause);
        }

        public override void LoadServers(ServersConfig<WindowsServiceConfig> Servers)
        {
            base.LoadServers(Servers);
        }

        protected override void AddServerData(WindowsServiceConfig data, TreeNode node)
        {
            base.AddServerData(data, node);

            if(data.Servicios != null) 
            {
                foreach(var s in data.Servicios)
                {
                    var n = node.Nodes.Add(node.Name+"_ser_"+ s,s);
                    n.Tag = s;
                    n.SelectedImageKey = n.ImageKey = "Wait";
                }
            }
        }
    }
}
