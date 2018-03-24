using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCompletion;

namespace WordCompletedNotes
{
    class DbStorage : IStorable
    {
        public void ReadWords(ref IComplementarable dictionary)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\WordsDatabase.mdf;Integrated Security=True";
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

        public void SaveWords(IComplementarable dictionary)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\WordsDatabase.mdf;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Words", cnn);
            cmdDelete.ExecuteNonQuery();

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
