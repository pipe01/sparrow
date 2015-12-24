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
        private const string LangFileHeader = "Sparrow Language File v0.0.1";

        protected internal Dictionary<string, string> Entries = new Dictionary<string, string>();

        public static string[] AvailableLanguages(string dir)
        {
            if (!Directory.Exists(dir)) return null;

            List<string> l = new List<string>();

            LangFile tester = new LangFile();

            foreach (string item in Directory.EnumerateFiles(dir, "*.slf"))
            {
                if (tester.Load(item, true))
                    l.Add(Path.GetFileNameWithoutExtension(item));
            }

            return l.ToArray();
        }

        public bool Load(string file, bool test = false)
        {
            if (!File.Exists(file)) return false;

            string[] linesTmp = File.ReadAllLines(file);
            string[] lines;

            if (linesTmp[0] == LangFileHeader)
                lines = linesTmp.Skip(1).ToArray();
            else
                return false;

            foreach (string l in lines)
            {
                int ePos = l.IndexOf('=');

                if (ePos == -1) return false;

                string key = l.Substring(0, ePos);
                string val = l.Substring(ePos + 1, l.Length - ePos - 1);

                if (!test)
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
