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

        private int lineHeight;
        private int fontWidth;
        private int spaceWidth;

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
            listBox.Visible = false;
            if (nextWord != "")
            {
                List<string> a = dictionary.FindMostUsedMatches(nextWord);
                listBox.Items.AddRange(a.ToArray());
                if (listBox.Items.Count > 0)
                {
                    listBox.Visible = true;
                    int wordsInLastLine = textBox.Lines[textBox.Lines.Length - 1].Split(' ').Length;
                    listBox.Location = new Point(textBox.Bounds.X + (textBox.Lines[textBox.Lines.Length - 1].Length - wordsInLastLine - 1) * fontWidth + wordsInLastLine * spaceWidth, textBox.Bounds.Y + (textBox.Lines.Length * lineHeight + 1));

                    listBox.SetSelected(0, true);
                }

                if (textBox.TextLength > 0)
                {
                    Console.Clear();
                    Console.WriteLine(textBox.Lines.Length);
                    Console.WriteLine(textBox.Lines[0].Length);
                    Console.WriteLine(textBox.Lines[0]);
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
                    ChangeLastWordInTextBox();
                    break;
                case Keys.Up:
                    if (listBox.SelectedIndex > 0)
                    {
                        listBox.SetSelected(listBox.SelectedIndex - 1, true);
                    }
                    ChangeLastWordInTextBox();
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
    }
}
