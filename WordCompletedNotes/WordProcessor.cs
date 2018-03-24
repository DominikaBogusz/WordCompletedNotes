using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    public class WordProcessor
    {
        public void ChangeEditedWord(TextBox textBox, string wordToInsert)
        {
            Match lastWordMatch = GetLastWordMatch(textBox);
            string lastWord = lastWordMatch.Value;
            textBox.Text = textBox.Text.Remove(lastWordMatch.Index, textBox.SelectionStart - lastWordMatch.Index);
            for (int i = 0; i < lastWord.Length; i++)
            {
                if (char.IsUpper(lastWord[i]))
                {
                    wordToInsert = UpperStringAt(wordToInsert, i);
                }
            }
            textBox.Text = textBox.Text.Insert(lastWordMatch.Index, wordToInsert);
            textBox.SelectionStart = lastWordMatch.Index + wordToInsert.Length;
        }

        public Match GetLastWordMatch(TextBox textBox)
        {
            string fromBeginToSelection = textBox.Text.Substring(0, textBox.SelectionStart);
            Match lastWordMatch = Regex.Match(fromBeginToSelection, @"\w+\Z");
            return lastWordMatch;
        }

        private string UpperStringAt(string input, int index)
        {
            char[] array = input.ToCharArray();
            array[index] = char.ToUpper(array[index]);
            return new string(array);
        }
    }
}
