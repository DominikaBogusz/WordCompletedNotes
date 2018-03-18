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
        private MainForm mainForm;

        public AutocompletionForm(MainForm mf)
        {
            InitializeComponent();

            mainForm = mf;
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

        public ListBox GetListBox()
        {
            return listBox;
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
            mainForm.ChangeEditedWord();
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
    }
}
