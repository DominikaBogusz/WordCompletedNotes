using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    public partial class MainForm : Form
    {
        private CompletionManager completion;

        public ViewFitter View { get; private set; }
        public WordProcessor WordProcessor { get; private set; }

        private FileManager fileManager;

        private AutocompletionForm autoForm;
        private List<string> promptsList;

        private WordsPreviewForm wordsPreviewForm;

        private SettingsForm settingsForm;

        public MainForm()
        {
            InitializeComponent();

            completion = new CompletionManager(new SimpleCompletion());

            autoForm = new AutocompletionForm(this, textBox);
            wordsPreviewForm = new WordsPreviewForm();

            View = new ViewFitter(autoForm, autoForm.GetListBox(), textBox);
            WordProcessor = new WordProcessor();

            fileManager = new FileManager();

            settingsForm = new SettingsForm();
            settingsForm.Show();
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
                if(lastWord != "") completion.InsertWord(lastWord);
            }
            else
            {
                autoForm.ClearAndHide();

                string nextWord = lastWord + e.KeyChar;

                if (nextWord != "")
                {
                    promptsList = completion.GetMatches(nextWord).Keys.ToList();
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
            else
            {
                Console.WriteLine("Something went wrong...");
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
                new TxtStorage().SaveWords(completion.GetAllWords(), fileName);
            }
        }

        private void tomdfDatabaseMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetSaveDialogFileName("mdf files (*.mdf)|*.mdf|All files (*.*)|*.*");
            if (fileName != "")
            {
                new DbStorage().SaveWords(completion.GetAllWords(), fileName);
            }
        }

        private void fromtxtFileMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetOpenDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName != "")
            {
                completion.ResetUserWords(new TxtStorage().ReadWords(fileName));
            }
        }

        private void frommdfDatabaseMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetOpenDialogFileName("mdf files (*.mdf)|*.mdf|All files (*.*)|*.*");
            if (fileName != "")
            {
                completion.ResetUserWords(new DbStorage().ReadWords(fileName));
            }
        }

        private void showUsedWordsMenu_Click(object sender, EventArgs e)
        {
            wordsPreviewForm.SetDataSource(completion.GetAllWords());
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
            //completion.UsePLVocabulary(useDictionaryPLMenu.Checked);
        }

        private void algSimpleMenu_Click(object sender, EventArgs e)
        {
            if (!algSimpleMenu.Checked)
            {
                completion = new CompletionManager(new SimpleCompletion(), completion.GetAllWords(), sortByUsesCountMenu.Checked);
                algSimpleMenu.Checked = true;
                algTrieMenu.Checked = false;
                algTrieHeapMenu.Checked = false;
            }
        }

        private void algTrieMenu_Click(object sender, EventArgs e)
        {
            if (!algTrieMenu.Checked)
            {
                completion = new CompletionManager(new TrieCompletion(), completion.GetAllWords(), sortByUsesCountMenu.Checked);
                algTrieMenu.Checked = true;
                algSimpleMenu.Checked = false;
                algTrieHeapMenu.Checked = false;
            }
        }

        private void algTrieHeapMenu_Click(object sender, EventArgs e)
        {
            if (!algTrieHeapMenu.Checked)
            {
                completion = new CompletionManager(new HeapTrieCompletion(), completion.GetAllWords(), sortByUsesCountMenu.Checked);
                algTrieHeapMenu.Checked = true;
                algSimpleMenu.Checked = false;
                algTrieMenu.Checked = false;
            }
        }

        private void sortByUsesCountMenu_Click(object sender, EventArgs e)
        {
            completion.SortByUsesCount(sortByUsesCountMenu.Checked);
        }
    }
}
