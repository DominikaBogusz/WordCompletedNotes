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
        RandomString randomString = new RandomString(3, 8);
        public string Output { get; private set; }

        public TestPrinter(string algName)
        {
            timeMeasurer = new TimeMeasurer(algName);
            Output = timeMeasurer.Algorithm + "\n";
        }

        public void InsertSimple(int times)
        {
            Output += "Inserting single word" + "\n";
            Output += "word" + "\t" + "word length" + "\t" + "time (ticks)" + "\n";
            for (int i = 0; i < times; i++)
            {
                string randomWord = randomString.Generate().ToLower();
                Output += randomWord + "\t" + randomWord.Length + "\t";
                long execTime = timeMeasurer.InsertSingle(randomWord);
                Output += execTime + "\n";
            }
        }

    }
}
