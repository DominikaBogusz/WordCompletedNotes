using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                File.WriteAllText(path, text);
                openFile = path;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                if (File.Exists(path) == true)
                {
                    textBox.Text = File.ReadAllText(openFileDialog.FileName);
                    openFile = path;
                    return true;
                }
            }

            return false;
        }
    }
}
