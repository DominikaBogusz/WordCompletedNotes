using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WordCompletion;

namespace WordCompletedNotes
{
    static class TxtStorage
    {
        public static Dictionary<string, int> ReadWords(string sourceFile)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            if (File.Exists(sourceFile))
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

        public static void SaveWords(Dictionary<string, int> words, string destFile)
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

        public static bool IsValidStorage(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadLines(filePath).ToList();
                foreach (string line in lines)
                {
                    string[] columns = line.Split(';');
                    if (columns.Count() != 2)
                    {
                        return false;
                    }
                    try
                    {
                        int count = Int32.Parse(columns[1]);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool CreateNewStorage(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch
                {
                    return false;
                }
                
            }
            try
            {
                File.Create(filePath);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
