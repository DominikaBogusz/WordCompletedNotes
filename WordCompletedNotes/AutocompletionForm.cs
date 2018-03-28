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

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox.Invalidate();
            mainForm.WordProcessor.ChangeEditedWord(textBox, listBox.SelectedItem.ToString());
            textBox.Focus();
        }

        public void CheckMouseClick(Point point)
        {
            //Point relativePoint = listBox.PointToClient(point);
            //int index = listBox.IndexFromPoint(relativePoint);
            //if (index != ListBox.NoMatches)
            //{
            //    listBox.SetSelected(index, true);
            //    Hide();
            //}
            //else if(point.X < (this.Location.X) || point.X > (this.Location.X + this.Width)
            //    || point.Y < (this.Location.Y) || point.Y > (this.Location.Y + this.Height))
            //{
            //    Hide();
            //}
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
