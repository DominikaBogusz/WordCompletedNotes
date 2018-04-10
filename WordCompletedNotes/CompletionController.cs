using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    public enum CompletionType
    {
        SIMPLE,
        TRIE,
        HEAPTRIE
    }

    public class CompletionController
    {
        IComplementarable completionSource;
        IComplementarable wordsFromUser;

        Dictionary<string, int> wordsFromDictionary = new Dictionary<string, int>();
        bool usingDictionary = false;

        bool sortingByUsesCount = true;

        public CompletionController(CompletionType completionType, Dictionary<string, int> initialWords = null, bool useDictionary = false, bool sortByUsesCount = true)
        {
            switch (completionType)
            {
                case CompletionType.SIMPLE:
                    completionSource = new SimpleCompletion();
                    wordsFromUser = new SimpleCompletion();
                    break;
                case CompletionType.TRIE:
                    completionSource = new TrieCompletion();
                    wordsFromUser = new TrieCompletion();
                    break;
                case CompletionType.HEAPTRIE:
                    completionSource = new HeapTrieCompletion();
                    wordsFromUser = new HeapTrieCompletion();
                    break;
            }

            if (initialWords != null)
            {
                completionSource.InsertWordsDictionary(initialWords);
            }

            if (useDictionary)
            {
                UseDictionary(true);
            }

            sortingByUsesCount = sortByUsesCount;
        }

        public void InsertWord(string word)
        {
            completionSource.Insert(word);
            if (usingDictionary)
            {
                wordsFromUser.Insert(word);
            }
        }

        public Dictionary<string, int> GetWords(string prefix)
        {
            if (sortingByUsesCount)
            {
                return GetMostUsedWords(prefix);
            }
            else
            {
                return GetUnorderedWords(prefix);
            }
        }

        private Dictionary<string, int> GetUnorderedWords(string prefix)
        {
            return completionSource.FindMatches(prefix.ToLower());
        }

        private Dictionary<string, int> GetMostUsedWords(string prefix)
        {
            return completionSource.FindMostUsedMatches(prefix.ToLower());
        }

        public void UseDictionary(bool enable)
        {
            usingDictionary = enable;

            if (enable)
            {
                wordsFromUser.ResetWordsDictionary(completionSource.GetAllWords());
                if (wordsFromDictionary.Count <= 0)
                {
                    wordsFromDictionary = new DictionaryFromTxt().Dictionary;
                }
                completionSource.InsertWordsDictionary(wordsFromDictionary);
            }
            else
            {
                completionSource.Clear();
                completionSource.InsertWordsDictionary(wordsFromUser.GetAllWords());
            }
        }

        public void SortByUsesCount(bool enable)
        {
            sortingByUsesCount = enable;
        }

        public Dictionary<string, int> GetUsedWords()
        {
            if (usingDictionary)
            {
                return wordsFromUser.GetAllWords();
            }
            return completionSource.GetAllWords();
        }

        public void SaveWords(IStorable storage, string fileName)
        {
            storage.SaveWords(wordsFromUser, fileName);
        }

        public void ReadWords(IStorable storage, string fileName)
        {
            storage.ReadWords(ref wordsFromUser, fileName);
        }
    }
}
