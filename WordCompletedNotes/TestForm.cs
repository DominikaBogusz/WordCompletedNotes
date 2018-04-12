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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            algComboBox.SelectedIndex = 0;
        }

        private void funcSelectionChange(object sender, EventArgs e)
        {
            saveButton.Enabled = insertSingleCB.Checked || insertDictCB.Checked
                || find10CB.Checked || findAllCB.Checked
                || findMostUsed10CB.Checked || findMostUsedAllCB.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int dictSize = GetDictSize();

            TestPrinter testPrinter = new TestPrinter(algComboBox.SelectedItem.ToString(),
                                      (int)repetitionsNumericUpDown.Value, dictSize);

            if (insertSingleCB.Checked)
            {
                testPrinter.InsertSingle();
            }
            if (insertDictCB.Checked)
            {
                testPrinter.InsertDictionary();
            }
            if (find10CB.Checked)
            {
                testPrinter.FindMatches10();
            }
            if (findAllCB.Checked)
            {
                testPrinter.FindMatchesAll();
            }
            if (findMostUsed10CB.Checked)
            {
                testPrinter.FindMostUsedMatches10();
            }
            if (findMostUsedAllCB.Checked)
            {
                testPrinter.FindMostUsedMatchesAll();
            }

            if (new FileManager().SaveNewTextFile(testPrinter.Output))
            {
                MessageBox.Show("Results of tests has been saved!");
            }
        }

        private int GetDictSize()
        {
            if (dictSmallRB.Checked)
            {
                return 500;
            }
            else if (dictMediumRB.Checked)
            {
                return 10000;
            }
            else
            {
                return 2000000;
            }
        }
    }
}
