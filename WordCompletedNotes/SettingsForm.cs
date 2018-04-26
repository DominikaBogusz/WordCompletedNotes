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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            algComboBox.SelectedIndex = 0;
        }

        private void fileSourceChanged(object sender, EventArgs e)
        {
            if (newFileRB.Checked)
            {
                fileTextBox.Enabled = fileButton.Enabled = false;
            }
            else
            {
                fileTextBox.Enabled = fileButton.Enabled = true;
            }
        }

        private void databaseSourceChanged(object sender, EventArgs e)
        {
            if (noSourceRB.Checked)
            {
                databaseTextBox.Enabled = databaseButton.Enabled = false;
            }
            else
            {
                databaseTextBox.Enabled = databaseButton.Enabled = true;
            }
        }
    }
}
