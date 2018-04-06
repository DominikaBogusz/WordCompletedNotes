using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        string dictionaryFile = Application.StartupPath + @"\slowa.txt";
        Dictionary<string, int> wordsFromDictionary = new Dictionary<string, int>();
        bool usingDictionary = false;

        public CompletionController(CompletionType completionType, Dictionary<string, int> initialWords = null, bool useDictionary = false)
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
        }

        public void InsertWord(string word)
        {
            completionSource.Insert(word);
            if (usingDictionary)
            {
                wordsFromUser.Insert(word);
            }
        }

        public List<string> GetListOfMostUsedWords(string word)
        {
            return completionSource.FindMostUsedMatchesList(word.ToLower());
        }

        public void UseDictionary(bool enable)
        {
            usingDictionary = enable;
            
            if (enable)
            {
                wordsFromUser.ResetWordsDictionary(completionSource.GetAllWords());
                if (wordsFromDictionary.Count <= 0)
                {
                    ReadWordsFromDictionaryFile(wordsFromDictionary);
                }
                completionSource.InsertWordsDictionary(wordsFromDictionary);
            }
            else
            {
                completionSource.Clear();
                completionSource.InsertWordsDictionary(wordsFromUser.GetAllWords());
            }
        }

        public Dictionary<string, int> GetUsedWords()
        {
            if (usingDictionary)
            {
                return wordsFromUser.GetAllWords();
            }
            return completionSource.GetAllWords();
        }

        private void ReadWordsFromDictionaryFile(Dictionary<string, int> dictionary)
        {
            if (File.Exists(dictionaryFile) == true)
            {
                foreach (string word in File.ReadLines(dictionaryFile))
                {
                    dictionary.Add(word, 1);
                }
            }
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
