using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletedNotes
{
    public static class DataReferences
    {
        public static string VocabularyFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\data\VocabularyPL.txt";
        public static string DatabaseFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\data\WordsDatabase.mdf";
    }
}
