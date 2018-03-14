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
    public partial class MainForm : Form
    {
        private IComplementarable dictionary;
        string nextWord = "";

        public MainForm()
        {
            InitializeComponent();

            dictionary = new SimpleCompletion();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)32: //Space
                case (char)13: //Enter
                    if (nextWord != "")
                    {
                        dictionary.Insert(nextWord);
                        nextWord = "";
                    }
                    break;
                case (char)8: //Backspace
                    if (nextWord != "")
                    {
                        nextWord = nextWord.Remove(nextWord.Length - 1);
                    }
                    break;
                default:
                    nextWord += e.KeyChar;
                    break;

            }

            listBox.Items.Clear();
            if (nextWord != "")
            {
                List<string> a = dictionary.FindMostUsedMatches(nextWord);
                listBox.Items.AddRange(a.ToArray());
                if (listBox.Items.Count > 0)
                {
                    listBox.SetSelected(0, true);
                }
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (listBox.SelectedIndex < listBox.Items.Count - 1)
                    {
                        listBox.SetSelected(listBox.SelectedIndex + 1, true);
                    }
                    break;
                case Keys.Up:
                    if (listBox.SelectedIndex > 0)
                    {
                        listBox.SetSelected(listBox.SelectedIndex - 1, true);
                    }
                    break;
                case Keys.Right:
                    if (textBox.TextLength == textBox.SelectionStart && listBox.SelectedItem != null)
                    {
                        if (textBox.Text.Length > 0)
                        {
                            int p = textBox.Text.LastIndexOf(" ") + 1;
                            textBox.Text = textBox.Text.Substring(0, p);
                        }

                        textBox.Text += listBox.SelectedItem.ToString();
                        textBox.SelectionStart = textBox.TextLength;
                    }
                    break;
            }
        }

        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
