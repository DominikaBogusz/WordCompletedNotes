using System.Collections.Generic;
using WordCompletion;

namespace WordCompletedNotes
{
    public interface IStorable
    {
        Dictionary<string, int> ReadWords(string sourceFile);
        void SaveWords(Dictionary<string, int> words, string destFile);
    }
}
