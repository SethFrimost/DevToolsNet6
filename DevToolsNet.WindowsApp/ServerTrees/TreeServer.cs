using DevToolsNet.Shared.Configs;
using DevToolsNet.WindowsApp.Properties;
using DevToolsNet.WindowsApp.ServerTrees;
using Microsoft.CodeAnalysis;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DevToolsNet.WindowsApp
{
    //public partial class TreeServer : UserControl
    public partial class TreeServer<T> : TreeViewTools where T : ServerConfig
    {
        private ServersConfig<T> servers;

        public TreeNodeCollection Nodes { get => tree.Nodes; }

        public TreeServer()
        {
            ilTree.Images.Add("server", Resources.server);
            ilTree.Images.Add("server_error", Resources.server_error);
            ilTree.Images.Add("grupo", Resources.folder);
        }

        public virtual void LoadServers(ServersConfig<T> Servers)
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

        private TreeNode AddGroupNode(GrupoConfig<T> grupo, TreeNodeCollection nodeCollection,TreeNode? parent=null)
        {
            string pKey = string.Empty;
            if (!string.IsNullOrEmpty(parent?.Name)) pKey = parent?.Name + "_";

            TreeNode node = nodeCollection.Add(pKey+"grp_" +grupo.Name, grupo.Name);
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
            var node = parent.Nodes.Add(parent.Name + "_srv_" +s.Name, s.Name);
            node.Tag = s;
            node.SelectedImageKey = node.ImageKey = "server";
            AddServerData(server, node);

            return node;
        }

        protected virtual void AddServerData(T data, TreeNode node) { }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.LineColor = System.Drawing.Color.Black;
            this.tree.Size = new System.Drawing.Size(297, 496);
            this.tree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tree_DrawNode);
            // 
            // TreeServer
            // 
            this.Name = "TreeServer";
            this.Size = new System.Drawing.Size(297, 521);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void tree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }


    }
}
