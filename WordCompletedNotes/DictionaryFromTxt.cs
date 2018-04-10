using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    public class DictionaryFromTxt
    {
        string dictionaryFile = Application.StartupPath + @"\slowa.txt";
        public Dictionary<string, int> Dictionary { get; private set; }

        public DictionaryFromTxt()
        {
            Dictionary = new Dictionary<string, int>();
            if (File.Exists(dictionaryFile) == true)
            {
                foreach (string word in File.ReadLines(dictionaryFile))
                {
                    Dictionary.Add(word, 1);
                }
            }
        }
    }
}
