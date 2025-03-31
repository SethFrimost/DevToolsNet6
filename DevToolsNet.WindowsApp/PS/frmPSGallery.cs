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
using DevToolsNet.PowerShell.ScriptLibrary;
using DevToolsNet.WindowsApp.Properties;
using DevToolsNet.WindowsApp.Controles;
using DevToolsNet.WinFormsControlLibrary.Dialogs;

namespace DevToolsNet.WindowsApp;

public partial class frmPSGallery : Form
{
    Dictionary<string, PSScriptExec> psExec = new Dictionary<string, PSScriptExec>();
    SecureString passSecure = new SecureString();
    PSGalleryConfig settings;
    List<PSGallery> psGalleries;

    #region Events

    private frmPSGallery()
    {
        InitializeComponent();
        spcData.Panel1Collapsed = true;
        initTree();
    }

    public frmPSGallery(IOptions<PSGalleryConfig> settings) : this()
    {
        this.settings = settings.Value;
    }


    private void frmPSGallery_Load(object sender, EventArgs e)
    {
        LoadGalleries();
    }


    private async void treeServers_AfterNodeCheck(object sender, TreeViewEventArgs e)
    {
        PSScript? sc = e?.Node?.Tag as PSScript;
        if (sc != null && e?.Node != null)
        {
            if (e.Node.Checked)
            {
                if (!(await createRunner(sc, e.Node.Name)))
                {
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (psExec.ContainsKey(e.Node.Name))
                {
                    var r = psExec[e.Node.Name];
                    psExec.Remove(e.Node.Name);
                    r.Dispose();
                    tabData.TabPages.RemoveByKey(e.Node.Name);
                }
            }
        }
    }


    private void tsbAddGallery_Click(object sender, EventArgs e)
    {
        dlgText dTxt = new dlgText("New Gallery");
        if (dTxt.ShowDialog() == DialogResult.OK)
        {
            PSGallery g = new PSGallery();
            g.Name = dTxt.ResultText;
            psGalleries.Add(g);
            AddToTree(g);
            g.SaveToDirectory(settings.BaseDirectory);
        }
    }

    private void tsbRemGallery_Click(object sender, EventArgs e)
    {
        if (treeGaleries.Tree.SelectedNode != null)
        {
            var n = treeGaleries.Tree.SelectedNode;
            if (n.Tag is PSGallery)
            {
                var g = n.Tag as PSGallery;
                psGalleries.Remove(g);
                g.RemoveFromDirectory(settings.BaseDirectory);
                treeGaleries.Tree.Nodes.Remove(n);
            }
            else if (n.Tag is PSScript)
            {
                var g = n.Parent.Tag as PSGallery;
                var s = n.Tag as PSScript;

                g.RemoveScript(settings.BaseDirectory, s);
                treeGaleries.Tree.Nodes.Remove(n);
            }
        }
    }

    private void tsbReload_Click(object sender, EventArgs e)
    {
        LoadGalleries();
    }

    private void tsbSave_Click(object sender, EventArgs e)
    {
        psGalleries.ForEach(g => g.SaveToDirectory(settings.BaseDirectory));
    }

    private void tsbAddScript_Click(object sender, EventArgs e)
    {
        if (treeGaleries.Tree.SelectedNode != null)
        {
            var n = treeGaleries.Tree.SelectedNode;
            TreeNode ng = null;
            PSGallery g = null;
            if (n.Tag is PSGallery)
            {
                g = n.Tag as PSGallery;
                ng = n;
            }
            else if (n.Tag is PSScript)
            {
                g = n.Parent.Tag as PSGallery;
                ng = n.Parent;
            }

            if (g != null)
            {
                dlgText dTxt = new dlgText("New script");
                if (dTxt.ShowDialog() == DialogResult.OK)
                {
                    PSScript s = new PSScript();
                    s.Name = dTxt.ResultText;
                    g.Scripts.Add(s);
                    g.SaveToDirectory(settings.BaseDirectory);
                    AddToTree(s, ng);
                }
            }

        }
    }

    private void tsbExecute_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (var pse in psExec)
            {
                pse.Value.RunScript();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void tsbClear_Click(object sender, EventArgs e)
    {
        foreach (var pse in psExec)
        {
            pse.Value.txtRes.Text = string.Empty;
        }
    }

    #endregion


    #region Functions

    private void LoadGalleries()
    {
        psGalleries = new List<PSGallery>();
        treeGaleries.Nodes.Clear();
        tabData.TabPages.Clear();

        var bd = settings?.BaseDirectory ?? string.Empty;
        if (!System.IO.Directory.Exists(bd)) System.IO.Directory.CreateDirectory(bd);

        foreach (var d in System.IO.Directory.GetDirectories(bd))
        {
            PSGallery gal = new PSGallery(d);
            psGalleries.Add(gal);
            AddToTree(gal);
        }

    }

    private void initTree()
    {
        treeGaleries.Tree.ImageList.Images.Add("galery", Resources.folder);
        treeGaleries.Tree.ImageList.Images.Add("script", Resources.text_align_left);
    }

    private void AddToTree(PSGallery gal)
    {
        var ng = treeGaleries.Nodes.Add(gal.Name);
        ng.Tag = gal;
        ng.ImageKey = "galery";
        ng.SelectedImageKey = "galery";

        foreach (var s in gal.Scripts)
        {
            s.InheritParams = gal.GlobalParams;
            AddToTree(s, ng);
        }
    }

    private void AddToTree(PSScript s, TreeNode node)
    {
        var ns = node.Nodes.Add(s.Name);
        ns.ImageKey = "script";
        ns.SelectedImageKey = "script";
        ns.Tag = s;
        ns.Name = s.Name;
    }

    private async Task<bool> createRunner(PSScript script, string key)
    {
        try
        {
            var r = await Task.Factory.StartNew<IPowerShellRunner>(() => new PowerShellRunner()).WaitAsync(CancellationToken.None);
            if (r != null)
            {
                AddResultTab(r, script, key);
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{script.Name}: {ex.ToString()}");
        }

        return false;
    }

    private void AddResultTab(IPowerShellRunner psr, PSScript script, string key)
    {
        var tab = new TabPage(script.Name);
        tab.Name = key;

        var psej = new PSScriptExec()
        {
            Dock = DockStyle.Fill,
            PowerShellRunner = psr,
            Script = script
        };

        psExec.Add(key, psej);

        tab.Controls.Add(psej);

        tabData.TabPages.Add(tab);
    }

    #endregion


    private void treeGaleries_AfterNodeSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Tag is PSGallery)
        {
            var g = e.Node.Tag as PSGallery;
            spcData.Panel1Collapsed = false;
            dicEdGlobal.Dictionary = g.GlobalParams;
        }
        else
        {
            spcData.Panel1Collapsed = true;
            dicEdGlobal.Dictionary = new Dictionary<string, string>();
        }
    }
}
