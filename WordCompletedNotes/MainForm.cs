using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private IComplementarable dictionary;

        private float lineHeight;
        private float fontWidth;
        private float spaceWidth;

        Point textBoxCorner;

        AutocompletionForm autoForm = new AutocompletionForm();
        ListBox listBox;

        private bool newStart;
        private int startIndex;

        public MainForm()
        {
            InitializeComponent();

            dictionary = new SimpleCompletion();

            using (Graphics g = textBox.CreateGraphics())
            {
                lineHeight = Convert.ToInt32(g.MeasureString("A", textBox.Font).Height);
                fontWidth = Convert.ToInt32(g.MeasureString("A", textBox.Font).Width);
                spaceWidth = Convert.ToInt32(g.MeasureString(" ", textBox.Font).Width);
            }

            textBoxCorner = textBox.Parent.PointToScreen(textBox.Location);

            listBox = autoForm.GetListBox();
        }

        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Console.WriteLine("preview");

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
            //Console.WriteLine("down");

            newStart = char.IsControl((char)e.KeyCode) || ((int)e.KeyCode < 41 && (int)e.KeyCode > 36);

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (autoForm.Visible)
                    {
                        if (listBox.SelectedIndex < listBox.Items.Count - 1)
                        {
                            listBox.SetSelected(listBox.SelectedIndex + 1, true);
                        }
                        ChangeEditedWord();
                        e.Handled = true;
                    }
                    break;
                case Keys.Up:
                    if (autoForm.Visible)
                    {
                        if (listBox.SelectedIndex > 0)
                        {
                            listBox.SetSelected(listBox.SelectedIndex - 1, true);
                        }
                        ChangeEditedWord();
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
            //Console.WriteLine("press");

            string fromBeginToSelection = textBox.Text.Substring(startIndex, textBox.SelectionStart);
            Console.WriteLine("\n" + fromBeginToSelection + " " + textBox.SelectionStart + "\n");
            string lastWord = Regex.Match(fromBeginToSelection, @"\w+\Z").Value.ToLower();
            Console.WriteLine(lastWord + "\n");

            if (char.IsWhiteSpace(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                newStart = true;

                dictionary.Insert(lastWord);
                Console.WriteLine("\n" + lastWord + "\n");
            }
            else
            {
                string nextWord = lastWord + e.KeyChar;
                Console.WriteLine("\n" + nextWord + "\n");

                autoForm.Hide();
                listBox.Items.Clear();

                if (nextWord != "")
                {
                    List<string> list = dictionary.FindMostUsedMatches(nextWord);
                    if (list.Any())
                    {
                        int height = (list.Count + 1) * listBox.ItemHeight;
                        autoForm.Height = listBox.Height = height;
                        listBox.Items.AddRange(list.ToArray());
                        listBox.SetSelected(0, true);

                        UpdateListBoxPosition();
                        autoForm.Show();
                    }
                } 
            }
        }

        private void textBox_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("selection changed");

            if (newStart) startIndex = textBox.SelectionStart - 1;
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("up");

            newStart = true;
        }

        private void ChangeEditedWord()
        {
            string fromBeginToSelection = textBox.Text.Substring(startIndex, textBox.SelectionStart);
            Match lastWord = Regex.Match(fromBeginToSelection, @"\w+\Z");
            int indexOfLastWord = lastWord.Index;
            bool isFirstUpper = char.IsUpper(lastWord.Value[0]);
            textBox.Text = textBox.Text.Remove(indexOfLastWord, textBox.SelectionStart - indexOfLastWord);
            string wordToInsert = listBox.SelectedItem.ToString();
            if (isFirstUpper)
            {
                wordToInsert = char.ToUpper(wordToInsert[0]) + wordToInsert.Substring(1);
            }
            textBox.Text = textBox.Text.Insert(indexOfLastWord, wordToInsert);
            textBox.SelectionStart = indexOfLastWord + wordToInsert.Length;
        }

        private void UpdateListBoxPosition()
        {
            textBoxCorner = textBox.Parent.PointToScreen(textBox.Location);

            Point cursorPosition = textBox.GetPositionFromCharIndex(textBox.SelectionStart - 1);
            Point relativeCursorPosition = new Point(cursorPosition.X + textBoxCorner.X + (int)(fontWidth + 1), cursorPosition.Y + textBoxCorner.Y + (int)(lineHeight + 1));

            if (textBox.Text.Length > 0 && (textBox.Text[textBox.Text.Length - 1]) == 10)
            {
                relativeCursorPosition = new Point(textBoxCorner.X + (int)(fontWidth + 1), relativeCursorPosition.Y + (int)(lineHeight + 1));
            }

            autoForm.Location = relativeCursorPosition;
        }

        private float MeasureStringWidth(string text)
        {
            using (Graphics g = textBox.CreateGraphics())
            {
                return g.MeasureString(text, textBox.Font).Width;
            }
        }

        private void MainForm_MoveOrResize(object sender, EventArgs e)
        {
            UpdateListBoxPosition();
        }
    }
}
