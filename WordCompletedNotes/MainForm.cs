using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    public partial class MainForm : Form
    {
        CompletionController completion;

        public ViewFitter View { get; private set; }
        public WordProcessor WordProcessor { get; private set; }

        FileManager fileManager;

        AutocompletionForm autoForm;
        List<string> promptsList;

        WordsPreviewForm wordsPreviewForm;

        TestForm testForm;

        public MainForm()
        {
            InitializeComponent();

            completion = new CompletionController(CompletionType.SIMPLE);

            autoForm = new AutocompletionForm(this, textBox);
            wordsPreviewForm = new WordsPreviewForm();

            View = new ViewFitter(autoForm, autoForm.GetListBox(), textBox);
            WordProcessor = new WordProcessor();

            fileManager = new FileManager();
        }

        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (autoForm.Visible)
                    {
                        autoForm.TrySelectNextItem();
                        e.Handled = true;
                    }
                    break;
                case Keys.Up:
                    if (autoForm.Visible)
                    {
                        autoForm.TrySelectPreviousItem();
                        e.Handled = true;
                    }
                    break;
                default:
                    autoForm.Hide();
                    break;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            View.UpdateListBoxPosition();

            string lastWord = WordProcessor.GetLastWordMatch(textBox).Value.ToLower();

            if (char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == '\n')
            {
                completion.InsertWord(lastWord);
            }
            else
            {
                autoForm.ClearAndHide();

                string nextWord = lastWord + e.KeyChar;

                if (nextWord != "")
                {
                    promptsList = completion.GetWords(nextWord).Keys.ToList();
                    View.AdjustAndShowPrompts(promptsList);
                }
            }
        }

        private void MainForm_MoveOrResize(object sender, EventArgs e)
        {
            View.UpdateListBoxPosition();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            if (autoForm.Visible)
            {
                autoForm.Hide();
            }
        }

        private void textBox_MouseHover(object sender, EventArgs e)
        {
            textBox.Focus();
        }

        private void newMenu_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            fileManager.ResetFileName();
            saveMenu.Enabled = false;
        }

        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            if(fileManager.SaveNewTextFile(textBox.Text) == true)
            {
                saveMenu.Enabled = true;
            }
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            if(fileManager.SaveExistingTextFile(textBox.Text) == false)
            {
                Console.WriteLine("Something went wrong...");
            }
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if(fileManager.OpenTextFile(textBox) == true)
            {
                saveMenu.Enabled = true;
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void totxtFileMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetSaveDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName != "")
            {
                completion.SaveWords(new TxtStorage(), fileName);
            }
        }

        private void tomdfDatabaseMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetSaveDialogFileName("mdf files (*.mdf)|*.mdf|All files (*.*)|*.*");
            if (fileName != "")
            {
                completion.SaveWords(new DbStorage(), fileName);
            }
        }

        private void fromtxtFileMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetOpenDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName != "")
            {
                completion.ReadWords(new TxtStorage(), fileName);
            }
        }

        private void frommdfDatabaseMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetOpenDialogFileName("mdf files (*.mdf)|*.mdf|All files (*.*)|*.*");
            if (fileName != "")
            {
                completion.ReadWords(new DbStorage(), fileName);
            }
        }

        private void showUsedWordsMenu_Click(object sender, EventArgs e)
        {
            wordsPreviewForm.SetDataSource(completion.GetUsedWords());
            wordsPreviewForm.ShowDialog();
        }

        private void DeactivateAutoForm(object sender, EventArgs e)
        {
            autoForm.CheckMouseClick(MousePosition);
            Thread.Sleep(50);
            autoForm.ClearAndHide();
        }

        //detect clicking on title bar
        const int WM_NCLBUTTONDOWN = 0x00A1;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                Cursor = new Cursor(Cursor.Current.Handle);
                autoForm.ClearAndHide();
            }
        }

        private void useDictionaryPLMenu_CheckedChanged(object sender, EventArgs e)
        {
            completion.UseDictionary(useDictionaryPLMenu.Checked);
        }

        private void algSimpleMenu_Click(object sender, EventArgs e)
        {
            if (!algSimpleMenu.Checked)
            {
                completion = new CompletionController(CompletionType.SIMPLE, completion.GetUsedWords(), useDictionaryPLMenu.Checked, sortByUsesCountMenu.Checked);
                algSimpleMenu.Checked = true;
                algTrieMenu.Checked = false;
                algTrieHeapMenu.Checked = false;
            }
        }

        private void algTrieMenu_Click(object sender, EventArgs e)
        {
            if (!algTrieMenu.Checked)
            {
                completion = new CompletionController(CompletionType.TRIE, completion.GetUsedWords(), useDictionaryPLMenu.Checked, sortByUsesCountMenu.Checked);
                algTrieMenu.Checked = true;
                algSimpleMenu.Checked = false;
                algTrieHeapMenu.Checked = false;
            }
        }

        private void algTrieHeapMenu_Click(object sender, EventArgs e)
        {
            if (!algTrieHeapMenu.Checked)
            {
                completion = new CompletionController(CompletionType.HEAPTRIE, completion.GetUsedWords(), useDictionaryPLMenu.Checked, sortByUsesCountMenu.Checked);
                algTrieHeapMenu.Checked = true;
                algSimpleMenu.Checked = false;
                algTrieMenu.Checked = false;
            }
        }

        private void sortByUsesCountMenu_Click(object sender, EventArgs e)
        {
            completion.SortByUsesCount(sortByUsesCountMenu.Checked);
        }

        private void testsLibraryTimingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testForm = new TestForm();
            testForm.ShowDialog();
        }
    }
}
