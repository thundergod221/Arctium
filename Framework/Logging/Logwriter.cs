using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Logging
{
    class Logwriter
    {
        string file;
        List<string> cnt;
        public Logwriter(string file)
        {
            this.file = file;
        }

        public void WriteToLog(LogType type, string text, params object[] args)
        {
            switch (type)
            {
                case LogType.NORMAL:
                    text = text.Insert(0, "System: ");
                    break;
                case LogType.ERROR:
                    text = text.Insert(0, "Error: ");
                    break;
                default:
                    break;
            }
            System.Collections.Generic.List<string> cnt = new System.Collections.Generic.List<string>();
            foreach (string line in System.IO.File.ReadAllLines(this.file))
            {
                cnt.Add(line);
            }
            cnt.Add(String.Format("[" + DateTime.Now.ToLongTimeString() + "] " + text, args));
            System.IO.File.WriteAllLines(this.file, cnt);
        }
    }
}
