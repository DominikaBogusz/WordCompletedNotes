using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion;
using System.Diagnostics;

namespace WordCompletedNotes
{
    public class TimeMeasurer
    {
        private IComplementarable testedCompletion;
        public string Algorithm { get; private set; }

        public TimeMeasurer(string algName)
        {
            testedCompletion = GetTestedCompletion(algName);
            Algorithm = algName + " algorithm";
        }

        private IComplementarable GetTestedCompletion(string algName)
        {
            switch (algName)
            {
                case "Simple":
                    return new SimpleCompletion(DataReferences.VocabularyFile);
                case "Trie":
                    return new TrieCompletion(DataReferences.VocabularyFile);
                case "HeapTrie":
                    return new HeapTrieCompletion(DataReferences.VocabularyFile);
                case "Database":
                    return new HeapTrieCompletion(DataReferences.VocabularyFile);
                default:
                    throw new Exception("Something went wrong...");
            }
        }

        public long InsertSingle(string word)
        {
            Stopwatch watch = Stopwatch.StartNew();
            testedCompletion.Insert(word);
            return watch.ElapsedTicks;
        }

        public long InsertDictionary(Dictionary<string, int> dict)
        {
            testedCompletion.Clear();
            Stopwatch watch = Stopwatch.StartNew();
            testedCompletion.InsertWords(dict);
            return watch.ElapsedTicks;
        }

        public long FindMatches(string prefix, int max = 0)
        {
            testedCompletion.Clear();
            Stopwatch watch = Stopwatch.StartNew();
            testedCompletion.FindMatches(prefix, max);
            return watch.ElapsedTicks;
        }

        public long FindMostUsedMatches(string prefix, int max = 0)
        {
            testedCompletion.Clear();
            Stopwatch watch = Stopwatch.StartNew();
            testedCompletion.FindMostUsedMatches(prefix, max);
            return watch.ElapsedTicks;
        }
    }
}
