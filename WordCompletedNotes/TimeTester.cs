using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion;

namespace WordCompletedNotes
{
    class TimeTester
    {
        delegate void SaveAction(IComplementarable dictionary, string destFile);
        delegate void ReadAction(ref IComplementarable dictionary, string sourceFile);

        public void OutputTimings(IComplementarable dictionary, IStorable storage, string sourceFile, string destFile)
        {
            Console.WriteLine("\t ~~~~~ " + dictionary.GetType() + " ~~~~~ ");
            Console.WriteLine("\t ~~~~~ " + storage.GetType() + " ~~~~~ \n");
            OutputSaveTime(new SaveAction(storage.SaveWords), dictionary, destFile);
            OutputReadTime(new ReadAction(storage.ReadWords), dictionary, sourceFile);
            Console.WriteLine();
        }

        private void OutputReadTime(ReadAction method, IComplementarable dictionary, string sourceFile)
        {
            Console.WriteLine("------" + method.Method + "------");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            method(ref dictionary, sourceFile);
            var elapsedMs = watch.ElapsedTicks;
            Console.WriteLine(elapsedMs + " ticks");
            Console.WriteLine("------\n");
        }

        private void OutputSaveTime(SaveAction method, IComplementarable dictionary, string destFile)
        {
            Console.WriteLine("------" + method.Method + "------");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            method(dictionary, destFile);
            var elapsedMs = watch.ElapsedTicks;
            Console.WriteLine(elapsedMs + " ticks");
            Console.WriteLine("------\n");
        }

        public void OutputCompletionTime(IComplementarable dictionary, string match)
        {
            Console.WriteLine("\t ~~ " + dictionary.GetType() + " ~~ ");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Dictionary<string, int> completions = dictionary.FindMostUsedMatches(match);
            var elapsedMs = watch.ElapsedTicks;
            Console.WriteLine("\tFinding '" + match + "' completions...");
            foreach (string c in completions.Keys)
            {
                Console.WriteLine("\t-" + c);
            }
            Console.WriteLine("\t...done.");
            Console.WriteLine("\t ~~ " + elapsedMs + " ticks ~~ \n");
        }
    }
}
