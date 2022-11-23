using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.Shared.Configs;
using DevToolsNet.WindowsApp.Properties;
using DevToolsNet.WinFormsControlLibrary;

namespace DevToolsNet.WindowsApp.ServerTreeManager
{
    public class TreeServerConnections : TreeServer<ServerConnectionStringCollection>
    {
        public override void InitializeTree(TreeView tree)
        {
            base.InitializeTree(tree);
            tree.ImageList.Images.Add("dataBase", Resources.dataBase);
        }

        protected override void AddServerData(ServerConnectionStringCollection data, TreeNode node)
        {
            base.AddServerData(data, node);

            if (data.Connections != null)
            {
                foreach (var c in data.Connections)
                {
                    var n = node.Nodes.Add(node.Name + "_con_" + c.Name, c.Name);
                    n.Tag = c;
                    n.SelectedImageKey = n.ImageKey = "dataBase";
                }
            }
        }
    }
}
