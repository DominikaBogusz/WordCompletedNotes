using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    public partial class TestForm : Form
    {
        bool dictSelected = false;
        bool funcSelected = false;

        public TestForm()
        {
            InitializeComponent();

            algComboBox.SelectedIndex = 0;
        }


        private void dictSelectionChange(object sender, EventArgs e)
        {
            dictSelected = dictSmallCB.Checked || dictMediumCB.Checked || dictLargeCB.Checked;

            CheckIfEnableButon();
        }

        private void funcSelectionChange(object sender, EventArgs e)
        {
            funcSelected = insertDictCB.Checked || find10CB.Checked || findAllCB.Checked
                || findMostUsed10CB.Checked || findMostUsedAllCB.Checked;

            CheckIfEnableButon();
        }

        private void CheckIfEnableButon()
        {
            if (insertSingleCB.Checked && !funcSelected)
            {
                saveButton.Enabled = true;
            }
            else if (dictSelected && funcSelected)
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string output = "";

            IComplementarable completion = GetTestDictionary(algComboBox.SelectedItem.ToString());
            output += completion.GetType() + "\n";

            int repetitions = (int)repetitionsNumericUpDown.Value;

            if (insertSingleCB.Checked)
            {
                output += TestInsertSimple(completion, repetitions);
            }

            new FileManager().SaveNewTextFile(output);
        }

        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        Random random = new Random();

        private string GenerateRandomString(int min, int max)
        {
            char[] stringChars = new char[random.Next(min, max)];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }

        private IComplementarable GetTestDictionary(string algName)
        {
            switch (algName)
            {
                case "Simple":
                    return new SimpleCompletion();
                case "Trie":
                    return new TrieCompletion();
                case "HeapTrie":
                    return new HeapTrieCompletion();
                default:
                    throw new Exception("Something went wrong...");
            }
        }

        private string TestInsertSimple(IComplementarable completion, int times)
        {
            string output = "Inserting single word" + "\n";
            output += "word" + "\t" + "word length" + "\t" + "time (ticks)" + "\n";
            for (int i = 0; i < times; i++)
            {
                string randomWord = GenerateRandomString(3, 8).ToLower();
                output += randomWord + "\t" + randomWord.Length + "\t";
                long execTime = MeasureInsertSingleTime(completion, randomWord);
                output += execTime + "\n";
            }
            return output;
        }

        private long MeasureInsertSingleTime(IComplementarable completion, string word)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            completion.Insert(word);
            return watch.ElapsedTicks;
        }
    }
}
