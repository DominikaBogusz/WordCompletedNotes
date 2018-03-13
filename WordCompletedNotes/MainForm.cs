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

        Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            dictionary = new SimpleCompletion();

            timer.Interval = 400;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)32 || e.KeyChar == (char)13)
            {
                if (nextWord != "")
                {
                    dictionary.Insert(nextWord);
                    nextWord = "";
                }
            }
            else if (e.KeyChar == (char)8)
            {
                if (nextWord != "")
                {
                    nextWord = nextWord.Remove(nextWord.Length - 1);
                }
            }
            else
            {
                nextWord += e.KeyChar;
            }

            listBox.Items.Clear();
            if (nextWord != "")
            {
                List<string> a = dictionary.FindMostUsedMatches(nextWord);
                listBox.Items.AddRange(a.ToArray());

                menuStrip.Items.Clear();
                foreach (string x in a)
                {
                    menuStrip.Items.Add(x);
                }

                var charIndex = textBox.SelectionStart > 0 ? textBox.SelectionStart - 1 : textBox.SelectionStart;

                var caretPos = textBox.GetPositionFromCharIndex(charIndex);
                menuStrip.Location = PointToScreen(new Point(textBox.Left + caretPos.X, textBox.Top + caretPos.Y));

                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            menuStrip.Show();
            timer.Stop();
        }
    }
}
