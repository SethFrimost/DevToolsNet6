using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DevToolsNet.WindowsApp.ServerTrees
{
    public partial class TreeViewTools : UserControl
    {
        private Dictionary<TreeNodeCollection, List<TreeNode>> hidenNodes = new Dictionary<TreeNodeCollection, List<TreeNode>>();
        private string filterString = string.Empty;

        public bool ShowTools
        {
            get => toolStrip.Visible; 
            set
            {
                chkExact.Visible = value;
                toolStrip.Visible = value;
                if (!value) tstFilter.Text = string.Empty;
            }
        }

        public bool CheckBoxes
        {
            get => tree.CheckBoxes;
            set
            {
                tree.CheckBoxes = value;
                tsbSelectAll.Visible = value;
                tsSep1.Visible = value;
                tsbUnselectAll.Visible = value;
                resizeFilter();
            }
        }

        public event TreeViewEventHandler AfterNodeCheck;
        public event TreeViewEventHandler AfterNodeSelect;
        

        public TreeViewTools()
        {
            InitializeComponent();
            chkExact.Checked = false;
        }



        private void TreeViewTools_Resize(object sender, EventArgs e)
        {
            resizeFilter();
        }


        private void tsbSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in tree.Nodes) n.Checked = n.IsVisible;
        }

        private void tsbUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in tree.Nodes) n.Checked = false;
        }


        private void tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode n in e.Node.Nodes) 
            { 
                if(n.Checked != e.Node.Checked) n.Checked = e.Node.Checked; 
            }

            // check parent check state
            
            AfterNodeCheck?.Invoke(this, e);
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterNodeSelect?.Invoke(this, e);
        }


        private void tstFilter_TextChanged(object sender, EventArgs e)
        {
            filterString = tstFilter.Text.ToLower();
            FilterNodes(tree.Nodes);
            tree.Sort();
        }

        private void chkExact_CheckedChanged(object sender, EventArgs e)
        {
            FilterNodes(tree.Nodes);
            tree.Sort();
        }


        private void resizeFilter()
        {
            if (CheckBoxes) tstFilter.Width = this.Width - 55;
            else tstFilter.Width = this.Width - 5;

            chkExact.Location = new Point(tstFilter.Width - 15, chkExact.Location.Y);

            toolStrip.Refresh();
        }

        private bool FilterNodes(TreeNodeCollection nodes)
        {
            bool anyVisible = false;

            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                TreeNode node = nodes[i];
                if (!FilterNodes(node.Nodes) && checkFilter(node.Text.ToLower()))
                {
                    anyVisible = true;
                }
                else
                {
                    HideNode(node, nodes);
                }
            }

            var hn = GetHidenNodes(nodes);
            List<TreeNode> nodesRemove = new List<TreeNode>();

            foreach (TreeNode node in hn)
            {
                if (FilterNodes(node.Nodes) || checkFilter(node.Text.ToLower()))
                {
                    ShowNode(node, nodes);
                    anyVisible = true;
                    nodesRemove.Add(node);
                }
            }
            hn.RemoveAll(x=>nodesRemove.Contains(x));
            nodesRemove.Clear();

            return anyVisible;
        }

        private void HideNode(TreeNode node, TreeNodeCollection nodes)
        {
            if (!hidenNodes.ContainsKey(nodes))
            {
                hidenNodes.Add(nodes, new List<TreeNode>());
            }
            var col = hidenNodes[nodes];

            if (col == null)
            {
                col = new List<TreeNode>();
                hidenNodes.Add(nodes, col);
            }

            col.Add(node);
            nodes.Remove(node);

            if (node.Checked)
            {
                node.Checked = false;
                AfterNodeCheck?.Invoke(this, new TreeViewEventArgs(node));
            }
        }

        private void ShowNode(TreeNode node, TreeNodeCollection nodes)
        {
            if (!hidenNodes.ContainsKey(nodes))
            {
                hidenNodes.Add(nodes, new List<TreeNode>());
            }

            var col = hidenNodes[nodes];

            if (col != null)
            {
                nodes.Add(node);
                //col.Remove(node);
            }

            if(node.Checked) AfterNodeCheck?.Invoke(this, new TreeViewEventArgs(node));
        }

        private List<TreeNode> GetHidenNodes(TreeNodeCollection nodes)
        {
            if (!hidenNodes.ContainsKey(nodes))
            {
                hidenNodes.Add(nodes, new List<TreeNode>());
            }
            return hidenNodes[nodes];
        }

        private bool checkFilter(string text)
        {
            if (!ShowTools) return true;

            if(chkExact.Checked) return text == filterString;
            else return text.Contains(filterString);
        }

        // no tenemos
        /*private void setParentCheckState(TreeNode node)
        {
            if (node != null && node.Nodes.Count>0) 
            { 
                bool anyChecked = false;
                bool anyUncheked = false;
                bool anyUndeterminate = false;
                foreach(TreeNode n in node.Nodes)
                {
                    if(n.Checked) anyChecked= true;
                    else anyChecked= true;
                }
            }
        }*/
    }
    
}
