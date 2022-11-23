using DevToolsNet.Shared.Configs;
using DevToolsNet.WindowsApp.Properties;
using DevToolsNet.WinFormsControlLibrary;

namespace DevToolsNet.WindowsApp.ServerTreeManager
{
    public partial class TreeServer<T> where T : ServerConfig
    {
        protected ServersConfig<T> servers;


        public virtual void InitializeTree(TreeView tree)
        {
            if(tree.ImageList == null)
            {
                tree.ImageList = new ImageList();
            }
            tree.ImageList.Images.Add("server", Resources.server);
            tree.ImageList.Images.Add("server_error", Resources.server_error);
            tree.ImageList.Images.Add("grupo", Resources.folder);
        }

        public virtual void LoadNodes(TreeView tree, ServersConfig<T> Servers)
        {
            servers = Servers;
            tree.Nodes.Clear();

            if (servers != null && servers.Servers != null)
            {
                foreach (var s in servers.Servers)
                {
                    AddGroupNode(s, tree.Nodes);
                }
            }
        }

        protected virtual void AddServerData(T data, TreeNode node) { }


        private TreeNode AddGroupNode(GrupoConfig<T> grupo, TreeNodeCollection nodeCollection, TreeNode? parent = null)
        {
            string pKey = string.Empty;
            if (!string.IsNullOrEmpty(parent?.Name)) pKey = parent?.Name + "_";

            TreeNode node = nodeCollection.Add(pKey + "grp_" + grupo.Name, grupo.Name);
            node.Tag = grupo;
            node.SelectedImageKey = node.ImageKey = "grupo";
            grupo.SubGrupos.ForEach(x => AddGroupNode(x, node.Nodes, node));
            grupo.Datos.ForEach(x => AddServerNode(x, node));

            return node;
        }

        private TreeNode AddServerNode(T server, TreeNode parent)
        {
            if (server == null) return null;

            var s = server as ServerConfig;
            var node = parent.Nodes.Add(parent.Name + "_srv_" + s.Name, s.Name);
            node.Tag = s;
            node.SelectedImageKey = node.ImageKey = "server";
            AddServerData(server, node);

            return node;
        }



    }
}
