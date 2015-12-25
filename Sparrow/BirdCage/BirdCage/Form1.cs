using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sparrow;

namespace BirdCage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        LangFile langFile = new LangFile();
        Localizer localizer = new Localizer();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(LangFile.AvailableLanguages(
                System.IO.Directory.GetCurrentDirectory() + @"\locale"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            localizer.LocalizeControl(this, langFile);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            langFile.Load(@".\locale\" + listBox1.SelectedItem.ToString() + ".slf");
        }
    }
}
