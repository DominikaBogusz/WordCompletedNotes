using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    class TxtStorage : IStorable
    {
        public void ReadWords(ref IComplementarable dictionary, string sourceFile)
        {
            if (File.Exists(sourceFile) == true)
            {
                List<string> lines = File.ReadLines(sourceFile).ToList();
                foreach (string line in lines)
                {
                    string[] columns = line.Split(';');
                    string word = columns[0];
                    int count = Int32.Parse(columns[1]);
                    dictionary.Insert(word, count);
                }
            }
        }

        public void SaveWords(IComplementarable dictionary, string destFile)
        {
            using (FileStream fs = File.Create(destFile))
            {
                Dictionary<string, int> words = dictionary.GetAllWords();
                for (int i = 0; i < words.Count; i++)
                {
                    Byte[] line = new UTF8Encoding(true).GetBytes(words.Keys.ElementAt(i) + ";" + words.Values.ElementAt(i) + "\n");
                    if (i == words.Count - 1)
                    {
                        byte[] tmp = new byte[line.Length - 1];
                        Array.Copy(line, tmp, line.Length - 1);
                        line = tmp;
                    }
                    fs.Write(line, 0, line.Length);
                }
            }
        }
    }
}
