using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC2007FindOriginalArrayFromDoubledArray
    {
        public int[] FindOriginalArray(int[] changed)
        {

            Array.Sort(changed);

            if (changed.Length % 2 == 1)
            {
                return new int[0];
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (int num in changed)
            {
                if (!counts.ContainsKey(num))
                {
                    counts[num] = 0;
                }
                counts[num]++;
            }

            if (counts.ContainsKey(0) && counts[0] % 2 == 1)
            {
                return new int[0];
            }

            List<int> ans = new List<int>();
            foreach (int num in changed)
            {
                if (counts[num] > 0 && counts.ContainsKey(2 * num) && counts[2 * num] > 0)
                {
                    ans.Add(num);
                    counts[num]--;
                    counts[2 * num]--;
                }
            }

            if (ans.Count * 2 == changed.Length)
            {
                return ans.ToArray();
            }

            return new int[0];
        }
    }
}
