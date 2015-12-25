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

            if (ctrl is MenuStrip)
            {
                LocalizeMenuStrip(ctrl as MenuStrip, lang);
            }

            return true;
        }

        private void LocalizeMenuStrip(MenuStrip s, LangFile lang)
        {
            List<ToolStripItem> allItems = new List<ToolStripItem>();
            foreach (ToolStripItem toolItem in s.Items)
            {
                allItems.Add(toolItem);
                //add sub items
                allItems.AddRange(GetItems(toolItem));
            }

            foreach (ToolStripItem item in allItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem tsmi = (item as ToolStripMenuItem);
                    if (tsmi.Tag != null)
                    {
                        string tag = tsmi.Tag.ToString();
                        if (tag.StartsWith("!"))
                        {
                            tsmi.Text = lang.GetValue(tag.Substring(1, tag.Length - 1));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Recursively get SubMenu Items. Includes Separators.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private IEnumerable<ToolStripItem> GetItems(ToolStripItem item)
        {
            if (item is ToolStripMenuItem)
            {
                foreach (ToolStripItem tsi in (item as ToolStripMenuItem).DropDownItems)
                {
                    if (tsi is ToolStripMenuItem)
                    {
                        if ((tsi as ToolStripMenuItem).HasDropDownItems)
                        {
                            foreach (ToolStripItem subItem in GetItems((tsi as ToolStripMenuItem)))
                                yield return subItem;
                        }
                        yield return (tsi as ToolStripMenuItem);
                    }
                    else if (tsi is ToolStripSeparator)
                    {
                        yield return (tsi as ToolStripSeparator);
                    }
                }
            }
            else if (item is ToolStripSeparator)
            {
                yield return (item as ToolStripSeparator);
            }
        }
    }
}
