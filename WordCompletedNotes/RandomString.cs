using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletedNotes
{
    public class RandomString
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        Random random = new Random();

        int minLength;
        int maxLength;

        public RandomString(int min, int max)
        {
            minLength = min;
            maxLength = max;
        }

        public string Generate()
        {
            char[] stringChars = new char[random.Next(minLength, maxLength)];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
    }
}
