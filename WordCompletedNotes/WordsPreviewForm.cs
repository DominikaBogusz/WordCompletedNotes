using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            var dictionaryData = from row in dictionary select new WordRow(row.Key, row.Value);

            dataGridView.DataSource = dictionaryData.ToArray();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string column = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
            var sortDir = SetOrderDirection(column);

            WordRow[] rows = dataGridView.DataSource as WordRow[];
            WordRow[] sortedRows;
            if (column == "Word")
            {
                if(sortDir == SortOrder.Ascending)
                {
                    sortedRows = rows.OrderBy(x => x.Word).ToArray();
                }
                else
                {
                    sortedRows = rows.OrderByDescending(x => x.Word).ToArray();
                }
            }
            else if (column == "UsesCount")
            {
                if (sortDir == SortOrder.Ascending)
                {
                    sortedRows = rows.OrderBy(x => x.UsesCount).ToArray();
                }
                else
                {
                    sortedRows = rows.OrderByDescending(x => x.UsesCount).ToArray();
                }
            }
            else
            {
                sortedRows = rows;
            }

            dataGridView.DataSource = sortedRows;
            dataGridView.Refresh();
        }

        ListDictionary sortOrderLD = new ListDictionary(); //if less than 10 columns
        private SortOrder SetOrderDirection(string column)
        {
            if (sortOrderLD.Contains(column))
            {
                sortOrderLD[column] = (SortOrder)sortOrderLD[column] == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                sortOrderLD.Add(column, SortOrder.Ascending);
            }

            return (SortOrder)sortOrderLD[column];
        }
    }

    class WordRow
    {
        public string Word { get; private set; }
        public int UsesCount { get; private set; }

        public WordRow(string word, int usesCount)
        {
            Word = word;
            UsesCount = usesCount;
        }
    }
}
