using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletedNotes
{
    public class RandomStringsDictionary
    {
        RandomString randomString;
        public Dictionary<string, int> Dictionary { get; private set; }

        public RandomStringsDictionary(RandomString randString, int size)
        {
            randomString = randString;

            Dictionary = new Dictionary<string, int>();
            for (int i = 0; i < size; i++)
            {
                string newRandomString = randomString.Generate();
                if (Dictionary.ContainsKey(newRandomString))
                {
                    Dictionary[newRandomString]++;
                }
                else
                {
                    Dictionary.Add(newRandomString, 1);
                }
            }
        }
    }
}
