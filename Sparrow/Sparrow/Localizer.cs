using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparrow
{
    public class Localizer
    {
        public bool LocalizeControl<T>(T ctrl, LangFile lang, bool children = true)
            where T : Control
        {
            if (ctrl.Tag != null)
            {
                string tag = ctrl.Tag.ToString();
                if (tag.StartsWith("!"))
                {
                    ctrl.Text = lang.GetValue(tag.Substring(1, tag.Length - 1));
                }
            }

            if (ctrl.Controls.Count > 0 && children)
            {
                foreach (Control c in ctrl.Controls)
                {
                    LocalizeControl(c, lang, true);
                }
            }

            if (ctrl is ToolStrip)
            {
                ToolStrip ts = ctrl as ToolStrip;
                foreach (ToolStripItem item in ts.Items)
                {
                    dynamic f = (dynamic)item;
                    LocalizeControl(f, lang, true);
                }
            }

            if (ctrl is ToolStripMenuItem)
            {
                ToolStripMenuItem tsi = ctrl as ToolStripMenuItem;
                foreach (ToolStripItem item in tsi.DropDownItems)
                {
                    if (item.Tag != null)
                    {
                        string tag = item.Tag.ToString();
                        if (tag.StartsWith("!"))
                        {
                            item.Text = lang.GetValue(tag.Substring(1, tag.Length - 1));
                        }
                    }
                }
            }

            return true;
        }
    }
}
