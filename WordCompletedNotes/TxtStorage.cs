using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WordCompletion;

namespace WordCompletedNotes
{
    class TxtStorage : IStorable
    {
        public Dictionary<string, int> ReadWords(string sourceFile)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            if (File.Exists(sourceFile) == true)
            {  
                List<string> lines = File.ReadLines(sourceFile).ToList();
                foreach (string line in lines)
                {
                    string[] columns = line.Split(';');
                    string word = columns[0];
                    int count = Int32.Parse(columns[1]);
                    output.Add(word, count);
                }
            }
            return output;
        }

        public void SaveWords(Dictionary<string, int> words, string destFile)
        {
            using (FileStream fs = File.Create(destFile))
            {
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
