using WordCompletion;

namespace WordCompletedNotes
{
    public interface IStorable
    {
        void ReadWords(ref IComplementarable dictionary, string sourceFile);
        void SaveWords(IComplementarable dictionary, string destFile);
    }
}
