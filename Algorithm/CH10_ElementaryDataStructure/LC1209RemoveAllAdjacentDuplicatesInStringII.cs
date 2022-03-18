using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1209RemoveAllAdjacentDuplicatesInStringII
    {
        public string RemoveDuplicates(string s, int k)
        {
            // sb:    [a,b,b,b,c,d,d,e]
            // stack: [1,1,2,3,1,1,2,1]
            Stack<int> counts = new Stack<int>();
            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < sb.Length; i++)
            {
                // update the counts
                if (i == 0 || sb[i] != sb[i - 1])
                {
                    counts.Push(1);
                }
                else
                {
                    counts.Push(counts.Peek() + 1);
                }

                if (counts.Peek() == k)
                { // trigger the k duplicate removal
                    sb.Remove(i - k + 1, k);
                    i = i - k;
                    while (counts.Count > i + 1)
                    { // i + 1 = current valid length after the removal 
                        counts.Pop();
                    }
                }
            }

            return sb.ToString();
        }
    }
}
