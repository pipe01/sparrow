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
        public bool LocalizeControl(Control ctrl, LangFile lang, bool children = true)
        {
            string tag = ctrl.Tag.ToString();
            if (tag.StartsWith("!"))
            {
                ctrl.Text = lang.GetValue(tag.Substring(1, tag.Length - 1));
            }

            if (ctrl.Controls.Count > 0 && children)
            {
                foreach (Control c in ctrl.Controls)
                {
                    LocalizeControl(c, lang, true);
                }
            }

            return true;
        }
    }
}
