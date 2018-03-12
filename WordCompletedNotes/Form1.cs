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
    public partial class Form1 : Form
    {
        private IComplementarable dictionary;

        public Form1()
        {
            InitializeComponent();

            TestCompletion(new SimpleCompletion());
            TestCompletion(new TrieCompletion());
        }

        private void TestCompletion(IComplementarable dictionary)
        {
            Console.WriteLine("---" + dictionary.GetType() + "---");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            dictionary.Insert("ala");
            dictionary.Insert("alinka");
            dictionary.Insert("ma");
            dictionary.Insert("wielkiego");
            dictionary.Insert("kota");
            dictionary.Insert("alibabę");
            dictionary.Insert("ale");
            dictionary.Insert("astma");
            dictionary.Insert("alarmuje");
            dictionary.Insert("aldonka");
            dictionary.Insert("elDiablo");
            dictionary.Insert("alpaka");
            dictionary.Insert("Alpy");

            var completions = dictionary.FindMatches("al");

            foreach (var word in completions.Keys)
            {
                Console.WriteLine(word);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedTicks;
            Console.WriteLine(elapsedMs + " ticks");
            Console.WriteLine("------\n");
        }
    }
}
