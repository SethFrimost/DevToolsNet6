using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.WinFormsControlLibrary;
using DevToolsNet.WinServicesManager;

namespace DevToolsNet.WindowsApp.ServerTreeManager
{
    public class TreeServerServices : TreeServer<WindowsServiceConfig>
    {
        public override void InitializeTree(TreeView tree)
        {
            base.InitializeTree(tree);
            tree.ImageList.Images.Add("Wait", Properties.Resources.help2);
            tree.ImageList.Images.Add("Error", Properties.Resources.error);
            tree.ImageList.Images.Add("Stopped", Properties.Resources.media_stop_red);
            tree.ImageList.Images.Add("StartPending", Properties.Resources.media_play);
            tree.ImageList.Images.Add("StopPending", Properties.Resources.media_stop_red);
            tree.ImageList.Images.Add("Running", Properties.Resources.media_play_green);
            tree.ImageList.Images.Add("ContinuePending", Properties.Resources.media_play);
            tree.ImageList.Images.Add("PausePending", Properties.Resources.media_pause);
            tree.ImageList.Images.Add("Paused", Properties.Resources.media_pause);
        }

        protected override void AddServerData(WindowsServiceConfig data, TreeNode node)
        {
            base.AddServerData(data, node);

            if (data.Servicios != null)
            {
                foreach (var s in data.Servicios)
                {
                    var n = node.Nodes.Add(node.Name + "_ser_" + s, s);
                    n.Tag = s;
                    n.SelectedImageKey = n.ImageKey = "Wait";
                }
            }
        }

    }
}
