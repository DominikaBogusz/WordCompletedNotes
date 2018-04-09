using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion;

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
                    return new SimpleCompletion();
                case "Trie":
                    return new TrieCompletion();
                case "HeapTrie":
                    return new HeapTrieCompletion();
                default:
                    throw new Exception("Something went wrong...");
            }
        }

        public long InsertSingle(string word)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            testedCompletion.Insert(word);
            return watch.ElapsedTicks;
        }
    }
}
