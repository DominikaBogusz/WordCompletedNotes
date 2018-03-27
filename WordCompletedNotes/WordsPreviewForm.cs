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
    public partial class WordsPreviewForm : Form
    {
        public WordsPreviewForm()
        {
            InitializeComponent();
        }

        public void SetDataSource(Dictionary<string, int> dictionary)
        {
            var dictionaryData = from row in dictionary select new { Word = row.Key, UsesCount = row.Value };

            dataGridView.DataSource = dictionaryData.ToArray();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }
    }
}
