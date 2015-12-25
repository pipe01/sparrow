using Sparrow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Web;

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

        /// <summary>
        /// Translates a string into another language using Google's translate API JSON calls.
        /// <seealso>Class TranslationServices</seealso>
        /// </summary>
        /// <param name="Text">Text to translate. Should be a single word or sentence.</param>
        /// <param name="FromCulture">
        /// Two letter culture (en of en-us, fr of fr-ca, de of de-ch)
        /// </param>
        /// <param name="ToCulture">
        /// Two letter culture (as for FromCulture)
        /// </param>
        public string TranslateGoogle(string text, string fromCulture, string toCulture)
        {
            fromCulture = fromCulture.ToLower();
            toCulture = toCulture.ToLower();

            // normalize the culture in case something like en-us was passed 
            // retrieve only en since Google doesn't support sub-locales
            string[] tokens = fromCulture.Split('-');
            if (tokens.Length > 1)
                fromCulture = tokens[0];

            // normalize ToCulture
            tokens = toCulture.Split('-');
            if (tokens.Length > 1)
                toCulture = tokens[0];

            string url = string.Format(@"http://translate.google.com/translate_a/t?client=j&text={0}&hl=en&sl={1}&tl={2}",
                                       HttpUtility.UrlEncode(text), fromCulture, toCulture);

            // Retrieve Translation with HTTP GET call
            string html = null;
            try
            {
                WebClient web = new WebClient();

                // MUST add a known browser user agent or else response encoding doen't return UTF-8 (WTF Google?)
                web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

                // Make sure we have response encoding to UTF-8
                web.Encoding = Encoding.UTF8;
                html = web.DownloadString(url);
            }
            catch (Exception ex)
            {
                return null;
            }

            // Extract out trans":"...[Extracted]...","from the JSON string
            string result = Regex.Match(html, "trans\":(\".*?\"),\"", RegexOptions.IgnoreCase).Groups[1].Value;

            if (string.IsNullOrEmpty(result))
            {
                return null;
            }

            //return WebUtils.DecodeJsString(result);

            // Result is a JavaScript string so we need to deserialize it properly
            JavaScriptSerializer ser = new JavaScriptSerializer();
            return ser.Deserialize(result, typeof(string)) as string;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            cmsTranslate.Show(button6, e.Location);
        }

        private void googleTranslateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            InputForm input = new InputForm();
            input.lblDesc.Text = "Enter the language pair. For example, to translate from english to spanish type 'en|es'";
            if (input.ShowDialog() == DialogResult.Cancel ||
                input.txtInput.Text == "" || !input.txtInput.Text.Contains("|")) return;

            string[] langs = input.txtInput.Text.Split('|');

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string trans = TranslateGoogle(item.SubItems[1].Text, langs[0], langs[1]);
                item.SubItems[1].Text = trans;
                currentLang.SetValue(item.Text, trans);
            }

            if (MessageBox.Show("Apply?", "Translation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                currentLang.Save(localesFolder + @"\" + input.txtInput.Text + ".slf");
            }
        }
    }
}
