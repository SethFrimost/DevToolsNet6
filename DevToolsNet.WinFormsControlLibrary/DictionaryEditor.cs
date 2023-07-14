using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WinFormsControlLibrary
{
    public partial class DictionaryEditor : UserControl
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private const string newControlKey = "_new_";

        public bool AllowAdd { get; set; } = true;
        public bool AllowEditKey { get; set; } = true;
        public bool AllowEditValues { get; set; } = true;

        public int Gap { get; set; } = 3;

        private int top;
        private int tabIndex = 0;

        private string GetNameValue(string key) => "_v_" + key + "_v_";


        public Dictionary<string, string> Dictionary
        {
            get => dictionary;
            set
            {
                dictionary = value;
                ClearEditors();
                if (dictionary != null) CreateEditors();
            }
        }

        public DictionaryEditor()
        {
            InitializeComponent();

            pKeys.AutoScroll = true;
            pValues.AutoScroll = true;
            pKeys.VerticalScroll.Visible = false;
            pValues.VerticalScroll.Visible = true;
        }

        private void pValues_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue < 0) e.NewValue = 0;

            if (e.NewValue >= 0)
            {
                pKeys.VerticalScroll.Value = e.NewValue;
                pValues.VerticalScroll.Value = e.NewValue;
                pKeys.PerformLayout();
                pValues.PerformLayout();
                //pKeys.VerticalScroll.Minimum = 0;
            }

        }


        private void ClearEditors()
        {
            pKeys.Controls.Clear();
            pValues.Controls.Clear();
            /*foreach (Control c in pKeys.Controls)
            {
                if (!(c is Label)) pKeys.Controls.Remove(c);
            }
            foreach (Control c in pValues.Controls)
            {
                if (!(c is Label)) pValues.Controls.Remove(c);
            }*/
            tabIndex = 0;
            top = lblKey.Top + lblKey.Height + 4;
        }

        private void CreateEditors()
        {
            top = 4;
            tabIndex = 0;

            var keys = dictionary.Keys.ToList();
            keys.Sort();
            foreach (var k in keys)
            {
                AddDicItem(k, k, dictionary[k]);
                top += Gap;
            }

            if (AllowAdd)
            {
                AddDicItem(newControlKey, "", "");
                top += Gap;
            }
        }

        private void AddDicItem(string name, string key, string value)
        {
            var txtK = new TextBox();
            var txtV = new TextBox();
            txtK.Name = name;
            txtV.Name = GetNameValue(name);

            txtK.Tag = txtV.Tag = key;

            txtK.Text = key;
            txtV.Text = value;

            txtK.Dock = txtV.Dock = DockStyle.Top;

            txtK.ReadOnly = !AllowEditKey;
            txtV.ReadOnly = !AllowEditValues;

            pKeys.Controls.Add(txtK);
            pValues.Controls.Add(txtV);

            txtK.BringToFront();
            txtV.BringToFront();

            txtK.Validated += TxtK_Validated;
            txtV.TextChanged += TxtV_Validated;

            txtK.TabIndex = tabIndex;
            tabIndex++;
            txtK.TabIndex = tabIndex;
            tabIndex++;
        }

        private void TxtK_Validated(object? sender, EventArgs e)
        {
            try
            {
                var t = sender as TextBox;
                if (string.IsNullOrEmpty(t.Text))
                {
                    if (t.Name != newControlKey)
                    {
                        dictionary.Remove(t.Name);
                        pValues.Controls.RemoveByKey("_v_" + t.Name + "_v_");
                        pKeys.Controls.Remove(t);
                    }
                }
                else
                {
                    string val;
                    string valN = GetNameValue(t.Name);
                    bool newItem = t.Name == newControlKey;
                    val = pValues.Controls[valN].Text;
                    bool cancel = false; ;

                    if (newItem)
                    {
                        cancel = dictionary.ContainsKey(t.Text);
                        if (cancel) MessageBox.Show("Key allredy exists");
                    }
                    else
                    {
                        dictionary.Remove(t.Name);
                    }

                    if (!cancel)
                    {
                        dictionary.Add(t.Text, val);

                        var txtV = pValues.Controls[valN];
                        txtV.Name = GetNameValue(t.Text);
                        txtV.Tag = t.Text;

                        t.Name = t.Text;
                        t.Tag = t.Text;

                        if (newItem && AllowAdd) AddDicItem(newControlKey, "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtV_Validated(object? sender, EventArgs e)
        {
            var t = sender as TextBox;
            var k = t.Tag as string;
            if (k != newControlKey)
            {
                dictionary[k] = t.Text;
            }
        }



    }
}
