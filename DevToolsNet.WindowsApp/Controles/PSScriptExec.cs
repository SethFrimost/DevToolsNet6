using DevToolsNet.PowerShell;
using DevToolsNet.PowerShell.ScriptLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WindowsApp.Controles
{
    public partial class PSScriptExec : UserControl
    {
        IPowerShellRunner psr;
        public IPowerShellRunner PowerShellRunner
        {
            get => psr;
            set
            {
                psr = value;
                if (psr != null) initRunner();
            }
        }
        public PSScript script;
        public PSScript Script
        {
            get => script;
            set
            {
                script = value;
                psScriptEdit.Dictionary = script.Params;
                psScriptEdit.Code = script.Code;
            }
        }

        public PSScriptExec()
        {
            InitializeComponent();
            psScriptEdit.txtCode.TextChanged += TxtCode_TextChanged;
            psScriptEdit.dicEdit.AllowAdd = true;
            psScriptEdit.dicEdit.AllowEditKey = true;
            psScriptEdit.dicEdit.AllowEditValues = true;
        }

        private void TxtCode_TextChanged(object? sender, EventArgs e)
        {
            if (script != null) script.Code = psScriptEdit.Code;
        }

        public void RunScript()
        {
            try
            {
                if (psr != null && Script != null)
                {
                    psr.RunCommand(Script.GetScript());
                }
            }
            catch (Exception ex)
            {
                runner_TextMessaje(psr, ex.ToString());
            }

        }

        private void initRunner()
        {
            psr.TextMessaje += runner_TextMessaje;
            psr.ErrorMessaje += runner_TextMessaje;
            psr.InfoMessaje += runner_TextMessaje;
            psr.WarningMessaje += runner_TextMessaje;
        }

        private void runner_TextMessaje(IPowerShellRunner runner, string msg)
        {
            try
            {
                if (txtRes.InvokeRequired)
                {
                    txtRes.Invoke(() =>
                    {
                        txtRes.Text += msg;
                        txtRes.SelectionStart = txtRes.Text.Length;
                        txtRes.ScrollToCaret();
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
