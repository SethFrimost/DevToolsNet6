using DevToolsNet.DB.Generator;
using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WindowsApp
{
    public partial class frmGenerador : Form
    {
        LocalXmlTemplateConfigSection settings;
        IGenerators generators;
        ITableDataInfoRecover dataInfoRecover;
        List<TabPage> tabs;

        //SqlDataInfoRecover dataInfoRecover;

        public frmGenerador(IOptions<LocalXmlTemplateConfigSection> settings, IGenerators Generators, ITableDataInfoRecover DataInfoRecover)
        {
            this.settings = settings.Value;
            generators = Generators;
            dataInfoRecover = DataInfoRecover;

            InitializeComponent();
        }

        private void frmGenerador_Load(object sender, EventArgs e)
        {

        }

        private void frmGenerador_Shown(object sender, EventArgs e)
        {
            loadConnections();
            reloadGenerators();
        }


        private void tsbReload_Click(object sender, EventArgs e)
        {
            loadConnections();
            reloadGenerators();
        }

        private void tscboConection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tscboConection.SelectedIndex > 0)
                {
                    var cs = tscboConection.SelectedItem as ConnectionString;
                    var conn = Program.ServiceProvider.GetService<IDbConnection>();
                    conn.ConnectionString = cs.Value;
                    dataInfoRecover.SetConnection(conn);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            generateCode(false);
        }

        private void tsbRunAdd_Click(object sender, EventArgs e)
        {
            generateCode(true);
        }



        private void chkPlantillas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //tabResults.TabPages[e.Index].Visible = (e.NewValue == CheckState.Chekced);
            if (e.NewValue == CheckState.Checked) tabResults.TabPages.Add(tabs[e.Index]);
            else tabResults.TabPages.Remove(tabs[e.Index]);
        }


        private void loadConnections()
        {
            tscboConection.Items.Clear();
            foreach (var cs in settings.connectionStrings)
            {
                tscboConection.Items.Add(cs);
            }

        }

        /// <summary>Reload generators, checks and tabs</summary>
        private void reloadGenerators()
        {
            try
            {
                if (tabs == null) tabs = new List<TabPage>();
                tabs.Clear();
                tabResults.TabPages.Clear();                
                chkPlantillas.Items.Clear();
                generators.LoadGenerators();
                foreach(var g in generators.CodeGenerators)
                {
                    chkPlantillas.Items.Add(g);
                    tabs.Add(generateTab(g));                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>Generate tab for code generator</summary>
        /// <param name="codeGenerator"></param>
        /// <returns>Created TabPage</returns>
        private TabPage generateTab(ICodeGenerator codeGenerator)
        {
            var tab = new TabPage();
            tab.Text = codeGenerator.Name;
            tab.Tag = codeGenerator;

            var txt = new TextBox();
            tab.Controls.Add(txt);
            txt.AcceptsReturn = true;
            txt.AcceptsTab = true;
            txt.Multiline = true;
            txt.MaxLength = int.MaxValue;
            txt.Dock = DockStyle.Fill;

            //tabResults.TabPages.Add(tab);

            return tab;
        }


        /// <summary>Call generators for visible tabs</summary>
        /// <param name="append">Append code or clear and set code</param>
        private void generateCode(bool append)
        {
            // Find tables
            List<DB.Objects.DataTable> tables;
            if (tsbLike.Checked) tables = dataInfoRecover.GetTableInfo(tstSchema.Text,tstTable.Text);
            else tables = dataInfoRecover.GetTableInfoLike(tstSchema.Text, tstTable.Text);

            if (tables.Any())
            {
                // Generate codes
                for (int i = 0; i < tabResults.TabPages.Count; i++)
                {
                    if (tabResults.TabPages[0].Visible)
                    {
                        var g = tabResults.TabPages[i].Tag as ICodeGenerator;
                        var code = g.GenerateCode(tables);
                        if (append) ((TextBox)tabResults.TabPages[i].Controls[0]).Text += code;
                        else ((TextBox)tabResults.TabPages[i].Controls[0]).Text = code;
                    }
                }
            }
            else MessageBox.Show("No se han encontrado tablas");
        }
    }
}
