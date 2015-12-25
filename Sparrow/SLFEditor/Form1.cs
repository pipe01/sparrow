using Sparrow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLFEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string localesFolder;

        private string[] languages;

        LangFile currentLang;

        private void btnCreateLan_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm();
            input.lblDesc.Text = "Input the locale. Example: en_GB";
            input.ShowDialog();

            LangFile lFile = new LangFile();

            lFile.Save(localesFolder + @"\" + input.txtInput.Text + ".slf");

            LoadLanguages();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            localesFolder = folderBrowser.SelectedPath;

            LoadLanguages();
        }

        private void LoadLanguages()
        {
            languages = LangFile.AvailableLanguages(localesFolder);
            lbLangs.Items.Clear();
            if (languages != null)
                lbLangs.Items.AddRange(languages);
        }

        private void LoadEntries(LangFile lFile)
        {
            currentLang = lFile;
            Dictionary<string, string> dic = lFile.GetDictionary();

            listView1.Items.Clear();
            foreach (string item in dic.Keys)
            {
                listView1.Items.Add(item).SubItems.Add(dic[item]);
            }
        }

        private void lbLangs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbLangs.SelectedItem == null) return;
            LangFile lang = new LangFile();
            lang.Load(localesFolder + "\\" + lbLangs.SelectedItem.ToString() + ".slf");
            LoadEntries(lang);
        }

        private void listView1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            InputForm input = new InputForm();
            input.lblDesc.Text = "Enter the new value";
            input.txtInput.Text = currentLang.GetValue(listView1.SelectedItems[0].Text);
            input.ShowDialog();

            currentLang.SetValue(listView1.SelectedItems[0].Text, input.txtInput.Text);
            currentLang.Save(localesFolder + "\\" + lbLangs.SelectedItem.ToString() + ".slf");

            LoadEntries(currentLang);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm();
            input.lblDesc.Text = "Enter the entry's key (separate with @ to add multiple)";
            if (input.ShowDialog() == DialogResult.Cancel) return;

            string[] keys =
                input.txtInput.Text.Contains("@") ?
                input.txtInput.Text.Split('@') : 
                new string[] { input.txtInput.Text };

            foreach (string item in keys)
            {
                currentLang.SetValue(item, "EDIT");
            }
            LoadEntries(currentLang);

            currentLang.Save(localesFolder + "\\" + lbLangs.SelectedItem.ToString() + ".slf");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                currentLang.DeleteValue(item.Text);
                LoadEntries(currentLang);
            }
            currentLang.Save(localesFolder + "\\" + lbLangs.SelectedItem.ToString() + ".slf");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbLangs.SelectedItem == null) return;

            InputForm input = new InputForm();
            input.lblDesc.Text = "Enter the language's locale";
            if (input.ShowDialog() == DialogResult.Cancel || !input.txtInput.Text.Contains("_")) return;

            LangFile lFile = new LangFile();
            LangFile temp = new LangFile(localesFolder + @"\" + lbLangs.SelectedItem.ToString() + ".slf");

            foreach (string item in temp.GetDictionary().Keys)
            {
                lFile.SetValue(item, "");
            }

            lFile.Save(localesFolder + @"\" + input.txtInput.Text + ".slf");

            LoadLanguages();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                button5_Click(sender, e);
            }
        }
    }
}
