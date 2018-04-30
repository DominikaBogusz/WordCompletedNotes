using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    public partial class SettingsForm : Form
    {
        private MainForm mainForm;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            ControlBox = false;
            algComboBox.SelectedIndex = 0;
        }

        private void databaseButton_Click(object sender, EventArgs e)
        {
            string filter = "txt files (*.txt)|*.txt";
            if (algComboBox.SelectedIndex == 3) //DB
            {
                filter = "mdf files (*.mdf)|*.mdf";
            }
            string fileName = "";
            if (newSourceRB.Checked)
            {
                fileName = FileKit.GetSaveDialogFileName(filter);
            }
            else
            {
                fileName = FileKit.GetOpenDialogFileName(filter);
            }
            sourceTextBox.Text = fileName;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            IComplementarable completion = SetCompletionType(algComboBox.SelectedIndex);

            if (completion != null)
            {
                Dictionary<string, int> vocabularyWords = GetTxtVocabularyWords();

                Dictionary<string, int> sourceWords = GetTxtSourceWords();

                CompletionManager completionManager = new CompletionManager(completion, sortCB.Checked, vocabularyWords);
                if (sourceWords != null)
                {
                    completionManager.Insert(sourceWords);
                }
                mainForm.Initialize(completionManager, (int)limitNum.Value);
                Close();
            }
            else
            {
                string databasePath = GetDbPath();
                if (databasePath != "")
                {
                    CompletionManager completionManager = new CompletionManager(new DatabaseCompletion(databasePath, vocabularyCB.Checked), sortCB.Checked, null);
                    mainForm.Initialize(completionManager, (int)limitNum.Value);
                    Close();
                }
            }
        }

        private IComplementarable SetCompletionType(int index)
        {
            switch (index)
            {
                case 0:
                    return new SimpleCompletion();
                case 1:
                    return new TrieCompletion();
                case 2:
                    return new HeapTrieCompletion();
                case 3:
                    return null;
            }
            return null;
        }

        private Dictionary<string, int> GetTxtVocabularyWords()
        {
            if (vocabularyCB.Checked)
            {
                return VocabularyFromTxt.GetVocabulary();
            }
            return null;
        }

        private Dictionary<string, int> GetTxtSourceWords()
        {
            if (existingSourceRB.Checked)
            {
                if (sourceTextBox.Text == "" || TxtStorage.IsValidStorage(sourceTextBox.Text) == false)
                {
                    MessageBox.Show("Select valid storage or check 'no initial words' option.");
                }
                else
                {
                    return TxtStorage.ReadWords(sourceTextBox.Text);
                }
            }
            else
            {
                TxtStorage.CreateNewStorage(sourceTextBox.Text);              
            }
            return null;
        }

        private string GetDbPath()
        {
            if (existingSourceRB.Checked)
            {
                if (sourceTextBox.Text == "" || DbStorage.IsValidStorage(sourceTextBox.Text) == false)
                {
                    MessageBox.Show("Select valid database or check 'create new storage' option.");
                }
                else
                {
                    return sourceTextBox.Text;
                }
            }
            else
            {
                if (sourceTextBox.Text != "")
                {
                    if (DbStorage.CreateNewStorage(sourceTextBox.Text) == true)
                    {
                        return sourceTextBox.Text;
                    }
                    else
                    {
                        MessageBox.Show("Could not create database. Check if selected path is correct.");
                    }
                }
                else
                {
                    MessageBox.Show("Select path to create new database.");
                }
            }
            return "";
        }

        private void limitCB_CheckedChanged(object sender, EventArgs e)
        {
            limitNum.Enabled = limitCB.Checked;
            if (!limitCB.Checked)
            {
                limitNum.Value = 0;
            }
        }

        private void algComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourceTextBox.Text != "" && newSourceRB.Checked)
            {
                sourceTextBox.Text = sourceTextBox.Text.Remove(sourceTextBox.Text.Length - 4);
                if (algComboBox.SelectedIndex == 3) //DB
                { 
                    sourceTextBox.Text += ".mdf";
                }
                else
                {
                    sourceTextBox.Text += ".txt";
                }
            }
            else if(sourceTextBox.Text != "" && existingSourceRB.Checked)
            {
                sourceTextBox.Text = "";
            }
        }

        private void wordsSource_CheckedChange(object sender, EventArgs e)
        {
            sourceTextBox.Text = "";
        }
    }
}
