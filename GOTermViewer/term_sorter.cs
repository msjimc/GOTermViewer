using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOTermViewer
{
    class term_sorter : IComparer<term>
    {
        int IComparer<term>.Compare(term x, term y)
        {
            if (y == null || x == null)
            {
                if (y == null)
                { return -1; }
                else if (x == null)
                { return 1; }
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}

