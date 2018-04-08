using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    class DbStorage : IStorable
    {
        private string referencedDbFile = Application.StartupPath + @"\WordsDatabase.mdf";

        public void ReadWords(ref IComplementarable dictionary, string sourceFile)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + sourceFile + @";Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Words", cnn);
            SqlDataReader dataReader = cmdSelect.ExecuteReader();

            while (dataReader.Read())
            {
                string word = dataReader["Word"].ToString();
                int count = Int32.Parse(dataReader["UsesCount"].ToString());
                dictionary.Insert(word, count);
            }
            cnn.Close();
        }

        public void SaveWords(IComplementarable dictionary, string destFile)
        {
            bool isOverwrited = File.Exists(destFile);

            if (!isOverwrited)
            {
                File.Copy(referencedDbFile, destFile, false);
            }

            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + destFile + @";Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (isOverwrited)
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM Words", cnn);
                cmdDelete.ExecuteNonQuery();
            }

            Dictionary<string, int> words = dictionary.GetAllWords();
            for (int i = 0; i < words.Count; i++)
            {
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Words (Word,UsesCount) VALUES ('" + words.Keys.ElementAt(i) + "','" + words.Values.ElementAt(i) + "')", cnn);
                cmdInsert.ExecuteNonQuery();
            }
            cnn.Close();
        }
    }
}
