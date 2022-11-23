using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.Shared.Configs;
using DevToolsNet.WindowsApp.Properties;
using DevToolsNet.WinFormsControlLibrary;

namespace DevToolsNet.WindowsApp.ServerTreeManager
{
    public class TreeServersManger : TreeServer<ServerConfig>
    {
        public override void InitializeTree(TreeView tree)
        {
            base.InitializeTree(tree);
            tree.ImageList.Images.Add("dataBase", Resources.dataBase);
        }
    }
}
