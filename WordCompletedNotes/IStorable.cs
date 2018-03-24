using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion;

namespace WordCompletedNotes
{
    interface IStorable
    {
        void ReadWords(ref IComplementarable dictionary);
        void SaveWords(IComplementarable dictionary);
    }
}
