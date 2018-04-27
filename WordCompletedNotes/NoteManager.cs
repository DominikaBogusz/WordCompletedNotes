using System.IO;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    class NoteManager
    {
        private string openFile = "";

        public void ResetFileName()
        {
            openFile = "";
        }

        public bool SaveNewTextFile(string text)
        {
            string fileName = FileKit.GetSaveDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
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
            string fileName = FileKit.GetOpenDialogFileName("txt files (*.txt)|*.txt|All files (*.*)|*.*");
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

    }
}
