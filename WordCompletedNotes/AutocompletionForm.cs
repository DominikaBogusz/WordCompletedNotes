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
        private TextBox textBox;

        public AutocompletionForm()
        {
            InitializeComponent();
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

        public void SetTextBox(TextBox t)
        {
            textBox = t;
        }
    }
}
