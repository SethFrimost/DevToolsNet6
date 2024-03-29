﻿using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Objects.Interfaces;
using DevToolsNet.DB.Runner;
using DevToolsNet.DB.Runner.Interfaces;
using DevToolsNet.Shared.Configs;
using Microsoft.Extensions.DependencyInjection;
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

    public partial class frmSQLRunner : Form
    {
        ServerTreeManager.TreeServerConnections treeServerConnections;
        ServersConfig<ServerConnectionStringCollection> servers;

        ConnectionStringGroupCollection settings;
        Dictionary<string, ICommandRuner> runners;

        private const string serverColumnUnion = "_Server_";
        private bool executedNoErr = false;
        private bool showReplace = false;
        private bool showGrids = false;

        private frmSQLRunner()
        {
            InitializeComponent();

            splcCode.Panel2Collapsed = !tsbSelectReplace.Checked;
            txtCode.MaxLength = int.MaxValue;
            txtReplace.MaxLength = int.MaxValue;

            runners = new Dictionary<string, ICommandRuner>();
        }

        /*public frmSQLRunner(IOptions<ConnectionStringGroupCollection> settings) : this()
        {
            this.settings = settings.Value;
        }*/

        public frmSQLRunner(IOptions<ServersConfig<ServerConnectionStringCollection>> settings) : this()
        {
            servers = settings.Value;
            treeServerConnections = new ServerTreeManager.TreeServerConnections();
            treeServerConnections.InitializeTree(treeServers.Tree);
            treeServerConnections.LoadNodes(treeServers.Tree, servers);
        }


        #region Events

        private void frmSQLRunner_Shown(object sender, EventArgs e)
        {
            //loadConnections();
        }


        private void treeServers_AfterNodeCheck(object sender, TreeViewEventArgs e)
        {
            
            if (e.Node != null && e.Node.Tag is ConnectionString)
            {
                if (e.Node.Checked)
                {
                    ICommandRuner r = Program.ServiceProvider.GetService<ICommandRuner>();
                    r.SetConnection(e.Node.Tag as ConnectionString);
                    r.DisplayName = e.Node.Parent.Text + "." + e.Node.Text;
                    runners.Add(e.Node.Name, r);
                }
                else
                    runners.Remove(e.Node.Name);
            }
        }

        private void tsbReload_Click(object sender, EventArgs e)
        {
            loadConnections();
        }

        private void tsbSelectReplace_CheckedChanged(object sender, EventArgs e)
        {
            splcCode.Panel2Collapsed = !tsbSelectReplace.Checked;
            showReplace = tsbSelectReplace.Checked;
        }

        private void tsbVerGrids_CheckedChanged(object sender, EventArgs e)
        {
            showGrids = tsbVerGrids.Checked;
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            ejecutarTodos(false, false);
        }

        private void tsbRunMeger_Click(object sender, EventArgs e)
        {
            ejecutarTodos(false, true);
        }

        private void tsbRunNonQ_Click(object sender, EventArgs e)
        {
            ejecutarTodos(true, false);
        }

        private void tsbDoReplace_Click(object sender, EventArgs e)
        {
            MakeReplaceText();
        }

        #endregion



        #region Functions

        private void loadConnections()
        {
            treeServers.Nodes.Clear();
            treeServers.CheckBoxes = true;
            runners.Clear();
            treeServerConnections.LoadNodes(treeServers.Tree, servers);
        }

        private void createNodes(TreeNodeCollection parent, ConnectionStringGroup group)
        {
            // group node
            TreeNode gNode = parent.Add(group.group, group.group, 0, 0);

            if (group.connectionStrings != null)
            {
                foreach (var con in group.connectionStrings)
                {
                    var n = gNode.Nodes.Add($"{group.group}_{con.Name}", con.Name, 1, 1);
                    n.Tag = con;
                }
            }
            if (group.Groups != null && group.Groups.Any()) foreach (var g in group.Groups) createNodes(gNode.Nodes, g);

        }


        private List<Task> ejecutarTodos(bool nonquery, bool union)
        {
            tabResults.TabPages.Clear();
            List<Task> tasks = new List<Task>();
            DataSet dsUnion = null;
            TabPage tabUnion = null;
            if (union)
            {
                dsUnion = new DataSet();
                tabUnion = GetTabPage("Result", "Result");
                tabUnion.ImageIndex = 2;
            }
            foreach (var run in runners.Values)
            {
                tasks.Add(ejecutarSQL(run.ConnectionString.Name, run, nonquery, dsUnion, run.DisplayName));
            }



            Task.Factory.ContinueWhenAll(tasks.ToArray(), (x) =>
            {
                executedNoErr = !x.Any(y => y.Exception != null);
            }).ContinueWith((x) =>
            {
                if (dsUnion != null)
                {
                    if (tabUnion == null) tabUnion = GetTabPage("Result", "Result");
                    tabUnion.ImageIndex = -1;

                    SetGridControl(tabUnion, dsUnion, null, true);
                    if (showReplace) SetTextControl(tabUnion, CreateTextReplace(dsUnion, txtReplace.Text));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

            return tasks;
        }


        /// <summary>  </summary>
        /// <param name="connName"></param>
        private Task ejecutarSQL(string name, ICommandRuner run, bool nonquery, DataSet dsUnion, string displayName)
        {
            DataSet ds = null;
            string strOut = string.Empty;
            TabPage tab = null;
            if (dsUnion == null)
            {
                tab = GetTabPage(name,displayName);
                tab.ImageIndex = 2;
                tab.Text = displayName;
            }
            Task tSql = Task.Factory.StartNew(() =>
            {
                if (nonquery) strOut = run.RunNonQuery(txtCode.Text);
                else ds = run.RunDataset(txtCode.Text, out strOut);
            }).ContinueWith((t) =>
            {
                if (dsUnion == null)
                {
                    if (tab == null) tab = GetTabPage(name, displayName);
                    tab.ImageIndex = -1;
                    if (t.Exception != null)
                    {
                        tab.ImageIndex = 3;
                        SetTextControl(tab, t.Exception.ToString());
                    }
                    else if (nonquery) SetTextControl(tab, strOut);
                    else SetGridControl(tab, ds, strOut, false);
                }
                else
                {
                    if (t.Exception != null)
                    {
                        var dt = dsUnion.Tables["Error"];
                        if (dt == null)
                        {
                            dt = dsUnion.Tables.Add("Error");
                            dt.Columns.Add("Srv");
                            dt.Columns.Add("Err");
                        }
                        dt.Rows.Add(name, t.Exception.ToString());
                    }
                    else
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            var clone = dt.Clone();
                            foreach (DataRow dr in dt.Rows) clone.ImportRow(dr);
                            clone.Columns.Add(serverColumnUnion);
                            foreach (DataRow dr in clone.Rows) dr[serverColumnUnion] = displayName;
                            if (dsUnion.Tables[clone.TableName] == null) dsUnion.Tables.Add(clone);
                            else dsUnion.Tables[clone.TableName].Merge(clone);
                        }

                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return tSql;
        }


        private TabPage GetTabPage(string name, string displayName)
        {
            TabPage tab;

            if (tabResults.TabPages.ContainsKey(name)) tab = tabResults.TabPages[name];
            else
            {
                tab = new TabPage(name) { Text = name };
                tab.Tag = new TabData() { Name = name };
                tab.Text = displayName;
                tabResults.TabPages.Add(tab);
            }

            return tab;
        }

        private void SetTextControl(TabPage tab, string text)
        {
            TextBox txt = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                MaxLength = int.MaxValue,
                ScrollBars = ScrollBars.Both
            };
            txt.Text = text;
            ((TabData)tab.Tag).txtReplace = txt;

            tab.Controls.Add(txt);
        }

        private void SetGridControl(TabPage tab, DataSet ds, string strOut, bool union)
        {
            // limiar columnas
            CorregirColumnas(ds);
            ((TabData)tab.Tag).data = ds;

            var g = CrearGrids(tab, ds, union);

            if (!string.IsNullOrEmpty(strOut))
            {
                TabControl tabC = new TabControl
                {
                    Dock = DockStyle.Fill
                };
                tabC.TabPages.Add("Data");
                tabC.TabPages.Add("Msj");

                tabC.TabPages[0].Controls.Add(g);

                TextBox txt = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    MaxLength = int.MaxValue,
                    ScrollBars = ScrollBars.Both,

                    Text = strOut
                };
                tabC.TabPages[1].Controls.Add(txt);

                tab.Controls.Add(tabC);
            }
            else
            {
                tab.Controls.Add(g);
            }
        }

        private static void CorregirColumnas(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                List<string> remCol = new List<string>();
                foreach (DataColumn c in dt.Columns)
                {
                    if (c.DataType.Name == "Byte[]") { remCol.Add(c.ColumnName); }
                }
                remCol.ForEach(c => dt.Columns.Remove(c));
                remCol.Clear();
                remCol = null;
            }
        }

        private Control CrearGrids(TabPage tab, DataSet ds, bool union)
        {
            if (ds.Tables.Count == 1 && !showReplace)
            {
                DataGridView g = CrearDataGridView(ds.Tables[0], union);

                return g;
            }
            else
            {
                Panel p = new Panel() { Dock = DockStyle.Fill };
                p.AutoScroll = true;
                p.AutoScrollMargin = new Size(100, 100);
                //p.AutoSize = true;
                foreach (DataTable dt in ds.Tables)
                {
                    var g = CrearDataGridView(dt, union);
                    if (g.Columns[serverColumnUnion] != null) g.Columns[serverColumnUnion].DisplayIndex = 0;

                    if (dt != ds.Tables[ds.Tables.Count - 1])
                    {
                        g.Dock = DockStyle.Top;
                        g.Height = 200;
                        var s = new Splitter() { Dock = DockStyle.Top, Height = 6 };
                        p.Controls.Add(g);
                        p.Controls.Add(s);
                        g.BringToFront();
                        s.BringToFront();
                    }
                    else
                    {
                        p.Controls.Add(g);
                        g.BringToFront();
                    }

                    if (showReplace)
                    {
                        g.Dock = DockStyle.Top;
                        g.Height = 200;
                        var s = new Splitter() { Dock = DockStyle.Top, Height = 6 };
                        p.Controls.Add(s);
                        g.BringToFront();
                        s.BringToFront();

                        TextBox txt = new TextBox()
                        {
                            Dock = DockStyle.Fill,
                            Multiline = true,
                            MaxLength = int.MaxValue,
                            ScrollBars = ScrollBars.Both
                        };
                        txt.Text = CreateTextReplace(ds, txtReplace.Text);
                        ((TabData)tab.Tag).txtReplace = txt;

                        p.Controls.Add(txt);
                        txt.BringToFront();
                    }
                }

                return p;
            }
        }

        private static DataGridView CrearDataGridView(DataTable dt, bool union)
        {
            var res = new DataGridView
            {
                AutoGenerateColumns = true,
                Dock = DockStyle.Fill,
                DataSource = dt,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = true,
                AllowUserToOrderColumns = true,
                MinimumSize = new Size(100, 100)
            };
            if (union)
            {
                using (var g = res.CreateGraphics()) { }
                using (var f = new Form())
                {
                    f.Controls.Add(res);
                    f.Controls.Remove(res);
                }
                if (res.Columns[serverColumnUnion] != null) res.Columns[serverColumnUnion].DisplayIndex = 0;
            }
            return res;
        }


        private string CreateTextReplace(DataSet ds, string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataTable dt in ds.Tables)
            {
                sb.AppendLine(CreateTextReplace(dt, text));
            }
            return sb.ToString();
        }

        private string CreateTextReplace(DataTable dt, string text)
        {
            StringBuilder sb = new StringBuilder();
            string row = string.Empty;
            foreach (DataRow r in dt.Rows)
            {
                row = text;
                foreach (DataColumn c in dt.Columns)
                {
                    row = row.Replace("{" + c.ColumnName + "}", r[c].ToString());
                }
                sb.AppendLine(row);
            }
            return sb.ToString();
        }

        private void MakeReplaceText()
        {
            for (int i = 0; i < tabResults.TabCount; i++)
            {
                var td = tabResults.TabPages[i].Tag as TabData;
                if (td?.txtReplace != null)
                {
                    // do replace
                    td.txtReplace.Text = CreateTextReplace(td.data, txtReplace.Text);
                    td.txtReplace.Update();
                }
            }
        }




        #endregion

        private class TabData
        {
            public string Name { get; set; }
            public DataSet data { get; set; }
            public TextBox txtReplace { get; set; }
        }
    }

    
}
