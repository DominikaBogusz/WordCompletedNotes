using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    static class DbStorage
    {
        private static string referencedDbFile = Application.StartupPath + @"\WordsDatabase.mdf";

        public static Dictionary<string, int> ReadWords(string sourceFile)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + sourceFile + @";Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Words", cnn);
                SqlDataReader dataReader = cmdSelect.ExecuteReader();

                while (dataReader.Read())
                {
                    string word = dataReader["Word"].ToString();
                    int count = Int32.Parse(dataReader["UsesCount"].ToString());
                    output.Add(word, count);
                }
            }

            return output;
        }

        public static void SaveWords(Dictionary<string, int> words, string destFile)
        {
            bool isOverwrited = File.Exists(destFile);

            if (!isOverwrited)
            {
                File.Copy(referencedDbFile, destFile, false);
            }

            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + destFile + @";Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                if (isOverwrited)
                {
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM Words", cnn);
                    cmdDelete.ExecuteNonQuery();
                }

                for (int i = 0; i < words.Count; i++)
                {
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Words (Word,UsesCount) VALUES ('" + words.Keys.ElementAt(i) + "','" + words.Values.ElementAt(i) + "')", cnn);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }

        public static bool IsValidStorage(string filePath)
        {
            if (File.Exists(filePath) == true)
            {
                string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + filePath + @";Integrated Security=True";
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    try
                    {
                        cnn.Open();
                    }
                    catch
                    {
                        return false;
                    }

                    if (!IsCommandExecutingCorrectly("SELECT TOP(1) Id,Word,UsesCount FROM UserWords", cnn))
                        return false;

                    if (!IsCommandExecutingCorrectly("SELECT TOP(1) Id,Word,UsesCount FROM VocabularyWords", cnn))
                        return false;
                }
                return true;
            }
            return false;
        }

        private static bool IsCommandExecutingCorrectly(string command, SqlConnection cnn)
        {
            SqlCommand selectUserWords = new SqlCommand(command, cnn);
            SqlDataReader dataReader;
            try
            {
                dataReader = selectUserWords.ExecuteReader();
            }
            catch
            {
                return false;
            }
            dataReader.Close();
            return true;
        }
    }
}
