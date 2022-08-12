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

        public class SecondDone_BinarySearch
        {
            public int HIndex(int[] citations)
            {

                Array.Sort(citations, (int x, int y) => {
                    return y.CompareTo(x);
                });
                int l = 0;
                int r = citations.Length - 1;
                while (l <= r)
                {
                    int h = l + (r - l) / 2;
                    if (citations[h] > h)
                    {
                        l = h + 1;
                    }
                    else
                    {
                        r = h - 1;
                    }
                }

                return l;
            }
        }
    }
}
