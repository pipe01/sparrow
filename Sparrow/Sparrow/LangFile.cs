using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sparrow
{
    public class LangFile
    {
        protected internal Dictionary<string, string> Entries;

        public string[] AvailableLanguages(string dir)
        {
            if (!Directory.Exists(dir)) return null;

            List<string> l = new List<string>();

            foreach (string item in Directory.EnumerateFiles(dir, "*.lang"))
            {
                l.Add(Path.GetFileNameWithoutExtension(item));
            }

            return l.ToArray();
        }

        public bool Load(string lang)
        {
            if (!File.Exists(lang + ".lang")) return false;

            string[] lines = File.ReadAllLines(lang + ".lang");

            foreach (string l in lines)
            {
                int ePos = l.IndexOf('=');

                if (ePos == -1) return false;

                string key = l.Substring(0, ePos);
                string val = l.Substring(ePos, l.Length - ePos);

                Entries.Add(key, val);
            }

            return true;
        }

        public string GetValue(string key)
        {
            if (Entries.ContainsKey(key))
                return Entries[key];
            else
                return "Error";
        }
    }
}
