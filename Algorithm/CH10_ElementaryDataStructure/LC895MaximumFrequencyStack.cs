using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC895MaximumFrequencyStack
    {
        public class FreqStack
        {

            private Dictionary<int, int> freq;
            private Dictionary<int, Stack<int>> grp;
            private int maxfreq;

            public FreqStack()
            {
                freq = new Dictionary<int, int>();
                grp = new Dictionary<int, Stack<int>>();
                maxfreq = 0;
            }

            public void Push(int val)
            {
                if (!freq.ContainsKey(val))
                {
                    freq[val] = 0;
                }
                freq[val]++;

                if (freq[val] > maxfreq)
                {
                    maxfreq = freq[val];
                }

                if (!grp.ContainsKey(freq[val]))
                {
                    grp[freq[val]] = new Stack<int>();
                }
                grp[freq[val]].Push(val);
            }

            public int Pop()
            {
                int val = grp[maxfreq].Pop();
                freq[val]--;
                if (grp[maxfreq].Count == 0)
                {
                    maxfreq--;
                }
                return val;
            }
        }

    }
}
