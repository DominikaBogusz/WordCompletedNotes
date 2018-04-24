using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion;

namespace WordCompletedNotes
{
    public class TestPrinter
    {
        TimeMeasurer timeMeasurer;
        int repetitions;
        
        public string Output { get; private set; }

        RandomString randomWord = new RandomString(3, 8);
        RandomString randomPrefix = new RandomString(1, 3);
        int dictionarySize = 0;

        public TestPrinter(string algName, int repeatNumber, int dictSize)
        {
            timeMeasurer = new TimeMeasurer(algName);
            Output = timeMeasurer.Algorithm + "\n";
            repetitions = repeatNumber;
            dictionarySize = dictSize;
        }

        public void InsertSingle()
        {
            Output += "Inserting single word" + "\n";
            Output += "word" + "\t" + "word length" + "\t" + "time (ticks)" + "\n";
            for (int i = 0; i < repetitions; i++)
            {
                string random = randomWord.Generate().ToLower();
                Output += random + "\t" + random.Length + "\t";
                long execTime = timeMeasurer.InsertSingle(random);
                Output += execTime + "\n";
            }
        }

        public void InsertDictionary()
        {
            Output += "Inserting words dictionary" + "\n";
            Output += "size: " + dictionarySize + "\n";
            Dictionary<string, int> dictionary;
            if (dictionarySize < 2000000)
            {
                dictionary = new RandomStringsDictionary(randomWord, dictionarySize).Dictionary;
            }
            else
            {
                dictionary = new VocabularyFromTxt(DataReferences.VocabularyFile).GetVocabulary();
            }
            for (int i = 0; i < repetitions; i++)
            {
                long execTime = timeMeasurer.InsertDictionary(dictionary);
                Output += execTime + "\n";
            }
        }

        public void FindMatches10()
        {
            Output += "Finding 10 matches" + "\n";
            for (int i = 0; i < repetitions; i++)
            {
                string random = randomPrefix.Generate().ToLower();
                long execTime = timeMeasurer.FindMatches(random, 10);
                Output += execTime + "\n";
            }
        }

        public void FindMatchesAll()
        {
            Output += "Finding all matches" + "\n";
            for (int i = 0; i < repetitions; i++)
            {
                string random = randomPrefix.Generate().ToLower();
                long execTime = timeMeasurer.FindMatches(random);
                Output += execTime + "\n";
            }
        }

        public void FindMostUsedMatches10()
        {
            Output += "Finding 10 most frequent matches" + "\n";
            for (int i = 0; i < repetitions; i++)
            {
                string random = randomPrefix.Generate().ToLower();
                long execTime = timeMeasurer.FindMostUsedMatches(random, 10);
                Output += execTime + "\n";
            }
        }

        public void FindMostUsedMatchesAll()
        {
            Output += "Finding all most frequent matches" + "\n";
            for (int i = 0; i < repetitions; i++)
            {
                string random = randomPrefix.Generate().ToLower();
                long execTime = timeMeasurer.FindMostUsedMatches(random);
                Output += execTime + "\n";
            }
        }
    }
}
