using DevToolsNet.Shared.Configs;
using Microsoft.CodeAnalysis.Options;
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
using DevToolsNet.PowerShell;
using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Runner.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace DevToolsNet.WindowsApp;

public partial class frmPowerShell : Form
{
    private class TabData
    {
        public string Name { get; set; }
        public IPowerShellRunner psr { get; set; }
        public System.Windows.Forms.TextBox TextBox { get; set; }
    }

    ServerTreeManager.TreeServersManger treeServesManager = new ServerTreeManager.TreeServersManger();
    ServersConfig<ServerConfig> servers;
    Dictionary<string, IPowerShellRunner> runners = new Dictionary<string, IPowerShellRunner>();
    SecureString passSecure = new SecureString();

    private frmPowerShell()
    {
        InitializeComponent();

        treeServesManager.InitializeTree(treeServers.Tree);

        tstUser.Text = Environment.UserName;
    }

    public frmPowerShell(IOptions<ServersConfig<ServerConfig>> settings) : this()
    {
        servers = settings.Value;
        if(servers !=null) treeServesManager.LoadNodes(treeServers.Tree, servers);
    }

    private async void treeServers_AfterNodeCheck(object sender, TreeViewEventArgs e)
    {
        ServerConfig? sc = e?.Node?.Tag as ServerConfig;
        if (sc != null && e?.Node !=null)
        {
            if (e.Node.Checked)
            {
                if (!(await createRunner(sc, e.Node.Name)))
                {
                    e.Node.Checked= false;
                }
            }
            else
            {
                if(runners.ContainsKey(e.Node.Name))
                {
                    var r = runners[e.Node.Name];
                    runners.Remove(e.Node.Name);
                    r.Dispose();
                    tabResults.TabPages.RemoveByKey(e.Node.Name);
                }
            }
        }
    }

    private void AddResultTab(IPowerShellRunner psr, string tabText)
    {
        TabData tdata = new TabData();
        tdata.psr = psr;

        var tab = new TabPage(tabText);
        tab.Name = psr.Key;
        tab.Tag = tdata;

        tdata.TextBox = new System.Windows.Forms.TextBox()
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            MaxLength = int.MaxValue,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Consolas", 10),
            ForeColor = Color.White,
            BackColor = Color.FromArgb(1, 36, 86)
        };

        tab.Controls.Add(tdata.TextBox);
        
        tabResults.TabPages.Add(tab);
    }


    private void tsbClear_Click(object sender, EventArgs e)
    {
        foreach(TabPage tab in tabResults.TabPages)
        {
            ((TabData)tab.Tag).TextBox.Text = string.Empty;
        }

    }


    private async Task<bool> createRunner(ServerConfig sc, string key)
    {
        try
        {
            passSecure.Clear();
            foreach (Char c in tstPass.Text) passSecure.AppendChar(c);

            var r = await Task.Factory.StartNew<IPowerShellRunner>(() => new PowerShellRunner(sc, tstUser.Text, passSecure)).WaitAsync(CancellationToken.None);
            if(r != null)
            {
                r.Key = key;
                r.TextMessaje += runner_TextMessaje;
                r.ErrorMessaje += runner_TextMessaje;
                r.InfoMessaje += runner_TextMessaje;
                r.WarningMessaje += runner_TextMessaje;
                runners.Add(key, r);
                AddResultTab(r, sc.Name);
                return true;
            }
        }
        catch(Exception ex) 
        {
            MessageBox.Show($"{sc.Name}: {ex.ToString()}");
        }

        return false;
    }

    private void tsbExecute_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (var run in runners)
            {
                Task.Factory.StartNew(() => run.Value.RunCommand(txtCommand.Text));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void runner_TextMessaje(IPowerShellRunner runner, string msg)
    {
        try
        {
            var td = tabResults.TabPages[runner.Key].Tag as TabData;
            if (td != null)
            {
                if (td.TextBox.InvokeRequired)
                {
                    td.TextBox.Invoke(() => {
                        td.TextBox.Text += msg;
                        td.TextBox.SelectionStart = td.TextBox.Text.Length;
                        td.TextBox.ScrollToCaret();
                    });
                }
            }
            else
            {
                td.TextBox.Text += msg;
                td.TextBox.SelectionStart = td.TextBox.Text.Length;
                td.TextBox.ScrollToCaret();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        
    }

}
