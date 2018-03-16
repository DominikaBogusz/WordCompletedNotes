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

        private float lineHeight;
        private float fontWidth;
        private float spaceWidth;

        Point textBoxCorner;

        AutocompletionForm autoForm = new AutocompletionForm();
        ListBox listBox;

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

            Console.WriteLine("LineHeight: " + lineHeight);
            Console.WriteLine("FontWidth: " + fontWidth);
            Console.WriteLine("SpaceWidth: " + spaceWidth);

            textBoxCorner = textBox.Parent.PointToScreen(textBox.Location);

            listBox = autoForm.GetListBox();
        }

        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Console.WriteLine("preview");

            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("down");

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (listBox.SelectedIndex < listBox.Items.Count - 1)
                    {
                        listBox.SetSelected(listBox.SelectedIndex + 1, true);
                    }
                    ChangeLastWordInTextBox();
                    e.Handled = true;
                    break;
                case Keys.Up:
                    if (listBox.SelectedIndex > 0)
                    {
                        listBox.SetSelected(listBox.SelectedIndex - 1, true);
                    }
                    ChangeLastWordInTextBox();
                    e.Handled = true;
                    break;
                default:
                    autoForm.Hide();
                    break;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("press");

            switch (e.KeyChar)
            {
                case (char)32: //Space
                    if (nextWord != "")
                    {
                        dictionary.Insert(nextWord);
                        nextWord = "";
                    }
                    break;
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

                    Point cursorPosition = textBox.GetPositionFromCharIndex(textBox.SelectionStart - 1);
                    Point relativeCursorPosition = new Point(cursorPosition.X + textBoxCorner.X + (int)(fontWidth + 1), cursorPosition.Y + textBoxCorner.Y + (int)(lineHeight + 1));

                    autoForm.Location = relativeCursorPosition;
                    autoForm.Show();
                }
            }
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("up");
        }

        private void ChangeLastWordInTextBox()
        {
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
        }

        private float MeasureStringWidth(string text)
        {
            using (Graphics g = textBox.CreateGraphics())
            {
                return g.MeasureString(text, textBox.Font).Width;
            }
        }
    }
}
