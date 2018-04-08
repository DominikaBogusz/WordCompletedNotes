using System.IO;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    class FileManager
    {
        string openFile = "";

        public void ResetFileName()
        {
            openFile = "";
        }

        public bool SaveNewTextFile(string text)
        {
            string fileName = GetSaveDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName != "")
            {
                File.WriteAllText(fileName, text);
                openFile = fileName;
                return true;
            }
            return false;
        }

        public bool SaveExistingTextFile(string text)
        {
            if (openFile != "")
            {
                if (File.Exists(openFile) == true)
                {
                    File.WriteAllText(openFile, text);
                    return true;
                }
            }
            return false;
        }

        public bool OpenTextFile(TextBox textBox)
        {
            string fileName = GetOpenDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName != "")
            {
                if (File.Exists(fileName) == true)
                {
                    textBox.Text = File.ReadAllText(fileName);
                    openFile = fileName;
                    return true;
                }
            }
            return false;
        }

        public string GetSaveDialogFileName(string filter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = filter;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return "";
        }

        public string GetOpenDialogFileName(string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return "";
        }
    }
}
