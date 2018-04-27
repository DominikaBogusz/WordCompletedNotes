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
    public partial class SettingsForm : Form
    {
        public SettingsForm(bool firstUse)
        {
            InitializeComponent();

            ControlBox = !firstUse;

            algComboBox.SelectedIndex = 0;
        }

        private void fileSourceChanged(object sender, EventArgs e)
        {
            fileTextBox.Enabled = fileButton.Enabled = existingFileRB.Checked;
        }

        private void databaseSourceChanged(object sender, EventArgs e)
        {
            databaseTextBox.Enabled = databaseButton.Enabled = existingSourceRB.Checked;
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            string fileName = FileKit.GetOpenDialogFileName("txt files (*.txt)|*.txt");
            if (fileName != "")
            {
                fileTextBox.Text = fileName;
            }
        }

        private void databaseButton_Click(object sender, EventArgs e)
        {
            string filter = "txt files (*.txt)|*.txt";
            if (algComboBox.SelectedIndex == 3) //DB
            {
                filter = "mdf files (*.mdf)|*.mdf";
            }
            string fileName = FileKit.GetOpenDialogFileName(filter);
            if (fileName != "")
            {
                databaseTextBox.Text = fileName;
            }
        }

        private void algComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algComboBox.SelectedIndex == 3) //DB
            {
                existingSourceRB.Text = "Select existing words database (.mdf):";
            }
            else
            {
                existingSourceRB.Text = "Select existing words database (.txt):";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Close();

            IComplementarable completion = SetCompletionType(algComboBox.SelectedText);

            CompletionManager completionManager;

            if (completion != null)
            {
                Dictionary<string, int> vocabularyWords = null;
                if (vocabularyCB.Checked)
                {
                    vocabularyWords = VocabularyFromTxt.GetVocabulary();
                }

                Dictionary<string, int> sourceWords = null;
                if (existingSourceRB.Checked)
                {
                    if (databaseTextBox.Text == "" || TxtStorage.IsValidStorage(databaseTextBox.Text) == false)
                    {
                        MessageBox.Show("Select valid database or check 'no initial words' option.");
                        databaseTextBox.Text = "";
                    }
                    else
                    {
                        sourceWords = TxtStorage.ReadWords(databaseTextBox.Text);
                    }
                }

                completionManager = new CompletionManager(completion, sortCB.Checked, vocabularyWords);
                completionManager.Insert(sourceWords);
            }

            if (completion == null)
            {
                string databasePath = "";
                if (existingSourceRB.Checked)
                {
                    if (databaseTextBox.Text == "" || DbStorage.IsValidStorage(databaseTextBox.Text) == false)
                    {
                        MessageBox.Show("Select valid database or check 'no initial words' option.");
                        databaseTextBox.Text = "";
                    }
                }
                else
                {
                    //databasePath = CopyReferencedDatabaseToTemporaryPath();
                }
                completionManager = new CompletionManager(new DatabaseCompletion(databasePath, vocabularyCB.Checked), sortCB.Checked, null);
            }
        }

        private IComplementarable SetCompletionType(string algName)
        {
            switch (algName)
            {
                case "Simple":
                    return new SimpleCompletion();
                case "Trie":
                    return new TrieCompletion();
                case "HeapTrie":
                    return new HeapTrieCompletion();
                case "Database":
                    return null;
            }
            return null;
        }
    }
}
