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
    public partial class TestForm : Form
    {
        bool dictSelected = false;
        bool funcSelected = false;

        public TestForm()
        {
            InitializeComponent();

            algComboBox.SelectedIndex = 0;
        }


        private void dictSelectionChange(object sender, EventArgs e)
        {
            dictSelected = dictSmallCB.Checked || dictMediumCB.Checked || dictLargeCB.Checked;

            CheckIfEnableButon();
        }

        private void funcSelectionChange(object sender, EventArgs e)
        {
            funcSelected = insertDictCB.Checked || find10CB.Checked || findAllCB.Checked
                || findMostUsed10CB.Checked || findMostUsedAllCB.Checked;

            CheckIfEnableButon();
        }

        private void CheckIfEnableButon()
        {
            if (insertSingleCB.Checked && !funcSelected)
            {
                saveButton.Enabled = true;
            }
            else if(dictSelected && funcSelected)
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //todo
        }
    }
}
