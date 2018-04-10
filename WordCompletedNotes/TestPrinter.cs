using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletedNotes
{
    public class TestPrinter
    {
        TimeMeasurer timeMeasurer;
        int repetitions;
        
        public string Output { get; private set; }

        RandomString randomString = new RandomString(3, 8);
        int dictionarySize = 0;

        public TestPrinter(string algName, int repeatNumber, int dictSize)
        {
            timeMeasurer = new TimeMeasurer(algName);
            Output = timeMeasurer.Algorithm + "\n";
            repetitions = repeatNumber;
            dictionarySize = dictSize;
        }

        public void InsertSimple()
        {
            Output += "Inserting single word" + "\n";
            Output += "word" + "\t" + "word length" + "\t" + "time (ticks)" + "\n";
            for (int i = 0; i < repetitions; i++)
            {
                string randomWord = randomString.Generate().ToLower();
                Output += randomWord + "\t" + randomWord.Length + "\t";
                long execTime = timeMeasurer.InsertSingle(randomWord);
                Output += execTime + "\n";
            }
        }

        public void InsertDictionary()
        {
            Output += "Inserting words dictionary" + "\n";
            Output += "size: " + dictionarySize + "\n";
            if (dictionarySize < 2000000)
            {
                for (int i = 0; i < repetitions; i++)
                {
                    Dictionary<string, int> dictionary = new RandomStringsDictionary(randomString, dictionarySize).Dictionary;
                    long execTime = timeMeasurer.InsertDictionary(dictionary);
                    Output += execTime + "\n";
                }
            }
        }

    }
}
