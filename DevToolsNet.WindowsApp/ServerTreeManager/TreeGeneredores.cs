using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.Shared.Configs;
using DevToolsNet.WindowsApp.Properties;
using DevToolsNet.WinFormsControlLibrary;

namespace DevToolsNet.WindowsApp.ServerTreeManager
{
    public partial class TreeGeneredores
    {
        public event TreeViewEventHandler AfterNodeAdd;

        public virtual void InitializeTree(TreeView tree)
        {
            if(tree.ImageList == null)
            {
                tree.ImageList = new ImageList();
            }
            tree.ImageList.Images.Add("grupo", Resources.folder);
            tree.ImageList.Images.Add("item", Resources.text_align_left);
        }

        public virtual void LoadNodes(TreeView tree, List<ICodeGenerator> generadoes)
        {
            tree.Nodes.Clear();

            if (generadoes != null)
            {
                foreach (var s in generadoes)
                {
                    var p = GetParentNodeCollection(s.PathCarpeta,tree.Nodes,string.Empty);
                    var n = p.Add(null, s.Name, "item", "item");
                    n.Tag = s;
                    if (s.whitErrors) n.ForeColor = Color.Red;
                    AfterNodeAdd?.Invoke(this, new TreeViewEventArgs(n));
                }
            }
            tree.Sort();
        }

        public TreeNodeCollection GetParentNodeCollection(string path, TreeNodeCollection parent, string parentkey)
        {
            if(string.IsNullOrEmpty(path)) return parent;
            else
            {
                string carp = path.Split('\\')[0]??string.Empty;
                var k = parentkey + "\\" + carp;
                var n = parent[k];
                if (n == null) n = parent.Add(k,carp,"grupo","grupo");

                return GetParentNodeCollection(path.Replace(carp + "\\", string.Empty), n.Nodes, k);
            }
        }


    }
}
