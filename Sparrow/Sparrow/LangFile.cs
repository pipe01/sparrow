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
        private string Locale;

        public LangFile() { }
        public LangFile(string file) { Load(file); }

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

            Locale = Path.GetFileNameWithoutExtension(file);

            return true;
        }

        public string GetValue(string key)
        {
            if (Entries.ContainsKey(key))
                return Entries[key];
            else
                return "Error";
        }

        public void DeleteValue(string key)
        {
            if (Entries.ContainsKey(key))
                Entries.Remove(key);
            else
                return;
        }

        public Dictionary<string, string> GetDictionary()
        {
            return Entries;
        }

        /// <summary>
        /// You shouldn't use this method, it's intended for SLFEditor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, string value)
        {
            Entries[key] = value;
        }

        /// <summary>
        /// You shouldn't use this method, it's intended for SLFEditor
        /// </summary>
        /// <param name="file"></param>
        public void Save(string file)
        {
            File.Delete(file);
            StreamWriter writer = File.CreateText(file);
            writer.WriteLine(LangFileHeader);

            foreach (string item in Entries.Keys)
            {
                writer.WriteLine(item + "=" + Entries[item]);
            }

            writer.Flush();
            writer.Close();
        }
    }
}
