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
using DevToolsNet.WinServicesManager;
using Microsoft.Extensions.Options;

namespace DevToolsNet.WindowsApp;

public partial class frmWinServices : Form
{
    WindowsServicesManager winServicesManager;

    public frmWinServices(WindowsServicesManager winServicesManager)
    {
        InitializeComponent();
        this.winServicesManager = winServicesManager;
        winServicesManager.ServiceStatusUpdate += ServiceStatusUpdate;
    }


    private void frmWinServices_Shown(object sender, EventArgs e)
    {
        Load();
    }

    private void tsbReload_Click(object sender, EventArgs e)
    {
        Load();
    }

    private void tsbStart_Click(object sender, EventArgs e)
    {
        var se = treeServ.SelectedNode?.Tag as WindowsServiceStatus;
        if(se != null) winServicesManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Play);
    }

    private void tsbStop_Click(object sender, EventArgs e)
    {
        var se = treeServ.SelectedNode?.Tag as WindowsServiceStatus;
        if (se != null) winServicesManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Stop);
    }

    private void tsbRestart_Click(object sender, EventArgs e)
    {
        var se = treeServ.SelectedNode?.Tag as WindowsServiceStatus;
        if (se != null) winServicesManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Restart);

    }

    private void tsbRefresh_Click(object sender, EventArgs e)
    {
        var se = treeServ.SelectedNode?.Tag as WindowsServiceStatus;
        if (se != null) winServicesManager.ManageService(se, WinServicesManagerConfig.ServiceAction.Refresh);
    }


    private void ServiceStatusUpdate(WindowsServiceStatus se)
    {
        if(se != null)
        {
            var n = treeServ.Nodes.Find(se.Server + se.Name, true).FirstOrDefault();
            if (n != null)
            {
                if (treeServ.InvokeRequired) treeServ.Invoke(() => setIcon(n, se.LastStatus, se.exception?.ToString()));
                else setIcon(n, se.LastStatus, se.exception?.ToString());
            }
        }
    }


    private async void Load()
    {
        treeServ.Nodes.Clear();
        txtMsg.Text = String.Empty;
        spltMain.Panel2Collapsed = true;

        if (winServicesManager != null)
        {
            var serv = await winServicesManager.LoadServices();
            foreach(var s in serv)
            {
                AddServiceNode(s);
            }
        }
    }

    private TreeNode AddServiceNode(WindowsServiceStatus se)
    {
        var servNode = treeServ.Nodes.Find(se.Server, false).FirstOrDefault();
        if (servNode == null) servNode = treeServ.Nodes.Add(se.Server, se.Server, 0);

        var sn = servNode.Nodes.Add(se.Server + se.Name, se.Name, 1);
        sn.Tag = se;
        setIcon(sn, se.LastStatus, se.exception?.ToString());

        return sn;
    }

    private void setIcon(TreeNode n, System.ServiceProcess.ServiceControllerStatus state, string? err)
    {
        n.ToolTipText = String.Empty;

        if(err != null)
        {
            n.ImageIndex = 4;
            n.ToolTipText = err;
        }
        else
        {
            switch (state)
            {
                case System.ServiceProcess.ServiceControllerStatus.Running: n.ImageIndex = 2; break;
                case System.ServiceProcess.ServiceControllerStatus.Stopped: n.ImageIndex = 3; break;
                default: n.ImageIndex=1; break;    
            }
        }

        n.SelectedImageIndex = n.ImageIndex;
    }

    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
    {

    }

    private void treeServ_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if(!string.IsNullOrEmpty(e.Node?.ToolTipText))
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
}
