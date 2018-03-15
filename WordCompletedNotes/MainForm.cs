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

        int positionY;
        int positionX;

        bool notEnoughSpace = false;

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

            positionY = textBox.Bounds.Top + Convert.ToInt32(lineHeight);
            positionX = textBox.Bounds.Left;
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
                    positionX = textBox.Location.X;
                    positionY = Convert.ToInt32(textBox.Location.Y + (textBox.Lines.Length + 1) * lineHeight);
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
                List<string> list = dictionary.FindMostUsedMatches(nextWord);
                if (list.Any())
                {
                    listBox.Height = (list.Count + 1) * listBox.ItemHeight;
                    listBox.Items.AddRange(list.ToArray());

                    int edgeAreaX = textBox.Right - listBox.Width;
                    int edgeAreaY = textBox.Bottom - listBox.Height;

                    if (positionX > edgeAreaX)
                    {
                        positionX = edgeAreaX;
                        notEnoughSpace = true;
                    }
                    else if (positionX < edgeAreaX)
                    {
                        positionX = Convert.ToInt32(textBox.Location.X + MeasureStringWidth(textBox.Lines[textBox.Lines.Length - 1]));
                    }

                    if (positionY >= edgeAreaY)
                    {
                        positionY = edgeAreaY;
                        using (Graphics g = textBox.CreateGraphics())
                        {
                            g.DrawLine(Pens.Red, new Point(textBox.Left, Convert.ToInt32((textBox.Lines.Length - 1.5) * lineHeight)), new Point(textBox.Right, Convert.ToInt32((textBox.Lines.Length - 1.5) * lineHeight)));
                        }
                    }
                    else
                    {
                        using (Graphics g = textBox.CreateGraphics())
                        {
                            g.DrawLine(Pens.Black, new Point(textBox.Left, Convert.ToInt32(textBox.Lines.Length * lineHeight)), new Point(textBox.Right, Convert.ToInt32(textBox.Lines.Length * lineHeight)));
                        }
                    }

                    listBox.Location = new Point(positionX, positionY);
                    listBox.SetSelected(0, true);
                    listBox.Visible = true;
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("up");

            if (notEnoughSpace)
            {
                string fill = "              ";
                textBox.AppendText(fill);
                textBox.SelectionStart = textBox.Text.Length - fill.Length;
                notEnoughSpace = false;
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

        private float MeasureStringWidth(string text)
        {
            using (Graphics g = textBox.CreateGraphics())
            {
                return g.MeasureString(text, textBox.Font).Width;
            }
        }
    }
}
