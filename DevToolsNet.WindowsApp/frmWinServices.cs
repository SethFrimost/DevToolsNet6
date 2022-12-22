using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.Shared.Configs;
using DevToolsNet.WindowsApp.ServerTreeManager;
using DevToolsNet.WinServicesManager;
using Microsoft.Extensions.Options;
using Namotion.Reflection;

namespace DevToolsNet.WindowsApp;

public partial class frmWinServices : Form
{
    ServersConfig<WindowsServiceConfig> servers;
    ServerTreeManager.TreeServerServices treeServicesManager;
    WindowsServicesManager2 swManager;

    public frmWinServices(IOptions<ServersConfig<WindowsServiceConfig>> settings)
    {
        InitializeComponent();

        servers = settings.Value;

        treeServicesManager = new ServerTreeManager.TreeServerServices();
        treeServicesManager.InitializeTree(treeServerServices.Tree);

        swManager = new WindowsServicesManager2();
        swManager.ServiceStatusUpdate += ServiceStatusUpdate;
    }


    private void frmWinServices_Shown(object sender, EventArgs e)
    {
        Load();
    }

    private void treeServ_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Node?.ToolTipText))
        {
            txtMsg.Text = e.Node.ToolTipText;
            spltMain.Panel2Collapsed = false;
        }
        else
        {
            txtMsg.Text = String.Empty;
            spltMain.Panel2Collapsed = true;

        }
    }


    private void treeServerServices_AfterNodeCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Parent?.Tag is ServerConfig && e.Node?.Tag is string)
        {
            var sc = e.Node.Parent.Tag as ServerConfig;
            var name = e.Node.Tag as string;
            e.Node.ImageKey= e.Node.SelectedImageKey = "Wait";
            if (sc != null && name != null) swManager.TrackService(e.Node.Name, sc.IP, name);
        }

    }

    private void treeServerServices_AfterNodeSelect(object sender, TreeViewEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Node?.ToolTipText))
        {
            txtMsg.Text = e.Node.ToolTipText;
            spltMain.Panel2Collapsed = false;
        }
        else
        {
            txtMsg.Text = String.Empty;
            spltMain.Panel2Collapsed = true;
        }
    }


    private void tsbReload_Click(object sender, EventArgs e)
    {
        Load();
    }

    private void tsbStart_Click(object sender, EventArgs e)
    {
        var se = treeServerServices.Tree.SelectedNode?.Tag as WindowsServiceStatus;
        setIcon(treeServerServices.Tree.SelectedNode, System.ServiceProcess.ServiceControllerStatus.StartPending, null);
        if (se != null) swManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Play);
    }

    private void tsbStop_Click(object sender, EventArgs e)
    {
        var se = treeServerServices.Tree.SelectedNode?.Tag as WindowsServiceStatus;
        setIcon(treeServerServices.Tree.SelectedNode, System.ServiceProcess.ServiceControllerStatus.StopPending, null);
        if (se != null) swManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Stop);
    }

    private void tsbRestart_Click(object sender, EventArgs e)
    {
        var se = treeServerServices.Tree.SelectedNode?.Tag as WindowsServiceStatus;
        setIcon(treeServerServices.Tree.SelectedNode, System.ServiceProcess.ServiceControllerStatus.StartPending, null);
        if (se != null) swManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Restart);

    }

    private void tsbRefresh_Click(object sender, EventArgs e)
    {
        var se = treeServerServices.Tree.SelectedNode?.Tag as WindowsServiceStatus;
        setIcon(treeServerServices.Tree.SelectedNode, System.ServiceProcess.ServiceControllerStatus.StartPending, null);
        if (se != null) swManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Refresh);
    }


    private void ServiceStatusUpdate(WindowsServiceStatus se)
    {
        if(se != null)
        {
            var n = treeServerServices.Nodes.Find(se.Key, true).FirstOrDefault();
            if (n != null)
            {
                if (treeServerServices.InvokeRequired) treeServerServices.Invoke(() => setIcon(n, se.LastStatus, se.exception?.ToString()));
                else setIcon(n, se.LastStatus, se.exception?.ToString());
            }
        }
    }


    private async void Load()
    {
        treeServerServices.Tree.Nodes.Clear();
        txtMsg.Text = String.Empty;
        spltMain.Panel2Collapsed = true;
        if(swManager != null) swManager.Clear();
        treeServicesManager.LoadNodes(treeServerServices.Tree, servers);

    }

    private void setIcon(TreeNode n, System.ServiceProcess.ServiceControllerStatus state, string? err)
    {
        n.ToolTipText = String.Empty;

        if (err != null)
        {
            n.ToolTipText = err;
            n.ForeColor = Color.Red;
            n.ImageKey = n.SelectedImageKey = "Error";
        }
        else
        {
            n.ImageKey = n.SelectedImageKey = state.ToString();
            n.ForeColor = Color.Empty;
        }

        checkServerIcon(n.Parent, err);
    }

    private void checkServerIcon(TreeNode n, string? err)
    {
        bool withErr = false;
        if (err != null) withErr = true;
        else
        {
            foreach(TreeNode x in n.Nodes)
            {
                if(!string.IsNullOrEmpty(x.ToolTipText))
                {
                    withErr = true;
                    break;
                }
            }            
        }

        if(withErr)
        {
            n.ImageKey = n.SelectedImageKey = "server_error";
            n.ForeColor = Color.Red;
        }
        else
        {
            n.ImageKey = n.SelectedImageKey = "server";
            n.ForeColor = Color.Empty;
        }
    }


}
