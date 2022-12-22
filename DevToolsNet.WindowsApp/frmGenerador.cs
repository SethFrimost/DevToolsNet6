using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;

namespace DevToolsNet.WindowsApp
{
    public partial class frmGenerador : Form
    {
        LocalXmlTemplateConfigSection settings;
        IGenerators generators;
        ITableDataInfoRecover dataInfoRecover;
        List<TabPage> tabs;
        TabPage tabManual;
        ICodeGenerator genManual;
        //SqlDataInfoRecover dataInfoRecover;

        public frmGenerador(IOptions<LocalXmlTemplateConfigSection> settings, IGenerators Generators, ITableDataInfoRecover DataInfoRecover)
        {
            this.settings = settings.Value;
            generators = Generators;
            dataInfoRecover = DataInfoRecover;
            
            InitializeComponent();

            spcData.Panel1Collapsed = true;
            loadItemTemplates();
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

        private void tsbManual_CheckedChanged(object sender, EventArgs e)
        {
            spcData.Panel1Collapsed = !tsbManual.Checked;
            tsbGenTabManual.Visible = tsbManual.Checked;

            if (!tsbManual.Checked && tabResults.TabPages.Contains(tabManual)) tabResults.TabPages.Remove(tabManual);
        }

        private void tsbGenTabManual_Click(object sender, EventArgs e)
        {
            generarPlantillaManual();
        }


        private void tscboConection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tscboConection.SelectedIndex >= 0)
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

        private void tsbToFiles_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                generateToFiles(fbd.SelectedPath, tstFileTemplate.Text, false); 
            }
        }


        private void chkPlantillas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //tabResults.TabPages[e.Index].Visible = (e.NewValue == CheckState.Chekced);
            if (e.NewValue == CheckState.Checked) tabResults.TabPages.Add(tabs[e.Index]);
            else tabResults.TabPages.Remove(tabs[e.Index]);
        }


        private void tvTags_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag != null) txtManual.Paste(e.Node.Tag.ToString());
            txtManual.Focus();
        }

        private void lblGenerarPlantilla_Click(object sender, EventArgs e)
        {
            if (generarPlantillaManual()) lblGenerarPlantilla.Visible = false;
        }


        private void loadItemTemplates()
        {
            var gen = Program.ServiceProvider.GetService<ICodeGenerator>();
            tvTags.Nodes.Clear();
            var ni = tvTags.Nodes.Add("Items","Items",0,0);
            var no = ni.Nodes.Add("Opciones", "Opciones", 1,1);
            foreach (var x in gen.Items) ni.Nodes.Add(x.Key).Tag=x.Value;
            foreach (var x in gen.ItemsOptions) no.Nodes.Add(x.Key).Tag = x.Value;
            ni = tvTags.Nodes.Add("Datos", "Datos",2,2);
            foreach (var x in gen.DataTags) ni.Nodes.Add(x.Key).Tag = x.Value;
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
            txt.ScrollBars = ScrollBars.Both;
            txt.WordWrap = false;
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
            if(tstTable.Text.Contains(','))
            {
                tables = new List<DB.Objects.DataTable>();
                foreach (var t in tstTable.Text.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                {
                    if (tsbLike.Checked) tables.AddRange(dataInfoRecover.GetTableInfoLike(tstSchema.Text, t));
                    else tables.AddRange(dataInfoRecover.GetTableInfo(tstSchema.Text, t));
                }
            }
            else
            {
                if (tsbLike.Checked) tables = dataInfoRecover.GetTableInfoLike(tstSchema.Text, tstTable.Text);
                else tables = dataInfoRecover.GetTableInfo(tstSchema.Text, tstTable.Text);
            }

            string? tabFolder = null;

            if (tables.Any())
            {
                // Generate codes
                for (int i = 0; i < tabResults.TabPages.Count; i++)
                {
                    var g = tabResults.TabPages[i].Tag as ICodeGenerator;
                    var code = g.GenerateCode(tables);
                    code = code.Replace("\n\r","\n").Replace("\n", Environment.NewLine);

                    if (append) ((TextBox)tabResults.TabPages[i].Controls[0]).Text += code;
                    else ((TextBox)tabResults.TabPages[i].Controls[0]).Text = code;
                }
            }
            else MessageBox.Show("No se han encontrado tablas");
        }


        private void generateToFiles(string baseFolder, string fileTemplate, bool append)
        {
            // Find tables
            List<DB.Objects.DataTable> tables;
            if (tsbLike.Checked) tables = dataInfoRecover.GetTableInfo(tstSchema.Text, tstTable.Text);
            else tables = dataInfoRecover.GetTableInfoLike(tstSchema.Text, tstTable.Text);

            if (tables.Any())
            {
                string tabFolder;
                string tableFile;

                // Generate codes
                for (int i = 0; i < tabResults.TabPages.Count; i++)
                {
                    if (tabResults.TabPages[i].Visible)
                    {
                        var g = tabResults.TabPages[i].Tag as ICodeGenerator;
                        var codes = g.GenerateCodeList(tables);

                        codes.ForEach(x => x.Code = x.Code.Replace("\n\r", "\n").Replace("\n", Environment.NewLine));

                        tabFolder = GetTabPageFolder(baseFolder, g.Name);
                        foreach (var ct in codes)
                        {
                            tableFile = $"{tabFolder}\\{fileTemplate.Replace("[t]",ct.Table)}";

                            if (append) File.AppendAllText(tableFile, ct.Code);
                            else File.WriteAllText(tableFile, ct.Code);
                        }



                    }
                }
            }
            else MessageBox.Show("No se han encontrado tablas");

        }

        private string GetTabPageFolder(string? baseFolder, string folderName)
        {
            var res = baseFolder + "\\" + folderName;

            if(!System.IO.Directory.Exists(res)) System.IO.Directory.CreateDirectory(res);

            return res;
        }

        private bool generarPlantillaManual()
        {
            try
            {
                if (genManual == null)
                {
                    genManual = Program.ServiceProvider.GetService<ICodeGenerator>();
                    genManual.Name = "Manual";
                }
                genManual.LoadXML(txtManual.Text);

                if (tabManual == null) tabManual = generateTab(genManual);
                else
                {
                    tabManual.Tag = genManual;
                }

                if (!tabResults.TabPages.Contains(tabManual)) tabResults.TabPages.Add(tabManual);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (tabManual != null && !tsbManual.Checked && tabResults.TabPages.Contains(tabManual)) tabResults.TabPages.Remove(tabManual);
                return false;
            }
        }

        private void txtManual_TextChanged(object sender, EventArgs e)
        {
            lblGenerarPlantilla.Visible = true;
        }

        private void tsbCopyFromTemplate_Click(object sender, EventArgs e)
        {

        }
    }
}
