using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC274HIndex
    {
        public int HIndex(int[] citations)
        {

            Array.Sort(citations, (int x, int y) => {
                return y.CompareTo(x); // decending order
            });

            int h = 0;
            while (h < citations.Length && citations[h] > h)
            {
                h++;
            }

            return h;
        }
    }
}
