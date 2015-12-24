using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sparrow
{
    class LangFile
    {
        protected internal Dictionary<string, string> Entries;

        public bool Load(string file)
        {
            if (!File.Exists(file)) return false;

            string[] lines = File.ReadAllLines(file);

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
    }
}
