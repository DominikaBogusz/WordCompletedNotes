using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCompletion
{
    public static class VocabularyFromTxt
    {
        static string vocabularyFile = Application.StartupPath + @"\VocabularyPL.txt";

        public static Dictionary<string, int> GetVocabulary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            if (File.Exists(vocabularyFile) == true)
            {
                foreach (string word in File.ReadLines(vocabularyFile))
                {
                    dictionary.Add(word, 0);
                }
            }
            return dictionary;
        }
    }
}
