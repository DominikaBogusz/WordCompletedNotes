using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    public partial class AutocompletionForm : Form
    {
        MainForm mainForm;
        TextBox textBox;

        public AutocompletionForm(MainForm mf, TextBox tb)
        {
            InitializeComponent();

            mainForm = mf;
            textBox = tb;
        }

        public ListBox GetListBox()
        {
            return listBox;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            e.DrawFocusRectangle();

            foreach (int selectedIndex in listBox.SelectedIndices)
            {
                if (e.Index == selectedIndex)
                {
                    e.DrawBackground();
                    e.Graphics.FillRectangle(new SolidBrush(Color.DeepSkyBlue), e.Bounds);
                    e.DrawFocusRectangle();
                }
            }

            e.Graphics.DrawString(
                listBox.Items[e.Index].ToString(),
                listBox.Font,
                new SolidBrush(Color.Black),
                0,
                e.Index * listBox.ItemHeight
            );
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox.Invalidate();
            mainForm.WordProcessor.ChangeEditedWord(textBox, listBox.SelectedItem.ToString());
        }

        private void AutocompletionForm_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                listBox.SetSelected(index, true);
                Hide();
            }
            else
            {
                mainForm.Focus();
            }
        }

        public void TrySelectNextItem()
        {
            if (listBox.SelectedIndex < listBox.Items.Count - 1)
            {
                listBox.SetSelected(listBox.SelectedIndex + 1, true);
            }
        }

        public void TrySelectPreviousItem()
        {
            if (listBox.SelectedIndex > 0)
            {
                listBox.SetSelected(listBox.SelectedIndex - 1, true);
            }
        }

        public void ClearAndHide()
        {
            listBox.Items.Clear();
            Hide();
        }
    }
}
