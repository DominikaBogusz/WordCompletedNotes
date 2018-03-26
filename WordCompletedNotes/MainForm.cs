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
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    public partial class MainForm : Form
    {
        IComplementarable dictionary;

        public ViewFitter View { get; private set; }
        public WordProcessor WordProcessor { get; private set; }

        FileManager fileManager;
        IStorable storeManager;
        TimeTester timeTester;

        AutocompletionForm autoForm;

        public MainForm()
        {
            InitializeComponent();

            dictionary = new SimpleCompletion();

            autoForm = new AutocompletionForm(this, textBox);

            View = new ViewFitter(autoForm, autoForm.GetListBox(), textBox);
            WordProcessor = new WordProcessor();

            fileManager = new FileManager();

            timeTester = new TimeTester();
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
                dictionary.Insert(lastWord);
            }
            else
            {
                autoForm.ClearAndHide();

                string nextWord = lastWord + e.KeyChar;

                if (nextWord != "")
                {
                    List<string> list = dictionary.FindMostUsedMatches(nextWord.ToLower());
                    if (list.Any())
                    {
                        View.AdjustAndShowPrompts(list);
                    }
                }
            }
        }

        private void MainForm_MoveOrResize(object sender, EventArgs e)
        {
            View.UpdateListBoxPosition();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            autoForm.Hide();
            View.UpdateListBoxPosition();
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
                new TxtStorage().SaveWords(dictionary, fileName);
            }
        }

        private void tomdfDatabaseMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetSaveDialogFileName("mdf files (*.mdf)|*.mdf|All files (*.*)|*.*");
            if (fileName != "")
            {
                new DbStorage().SaveWords(dictionary, fileName);
            }
        }

        private void fromtxtFileMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetOpenDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName != "")
            {
                new TxtStorage().ReadWords(ref dictionary, fileName);
            }

            List<string> l = dictionary.FindMostUsedMatches("");
            foreach(string w in l)
            {
                Console.WriteLine(w);
            }
        }

        private void frommdfDatabaseMenu_Click(object sender, EventArgs e)
        {
            string fileName = fileManager.GetOpenDialogFileName("mdf files (*.mdf)|*.mdf|All files (*.*)|*.*");
            if (fileName != "")
            {
                new DbStorage().ReadWords(ref dictionary, fileName);
            }
        }
    }
}
