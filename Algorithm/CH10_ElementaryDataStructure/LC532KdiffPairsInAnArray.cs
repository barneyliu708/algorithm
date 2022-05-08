using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC532KdiffPairsInAnArray
    {
        public int FindPairs(int[] nums, int k)
        {

            int total = 0;
            if (k == 0)
            {
                Dictionary<int, int> count = new Dictionary<int, int>();
                foreach (int num in nums)
                {
                    if (!count.ContainsKey(num))
                    {
                        count[num] = 0;
                    }
                    count[num]++;
                    // Console.WriteLine(num + " " + count[num]);
                }
                foreach (int num in count.Keys)
                {
                    if (count[num] > 1)
                    {
                        total++;
                    }
                }
                return total;
            }

            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (!map.ContainsKey(num))
                {
                    map[num] = new HashSet<int>();
                }
                if (map.ContainsKey(num + k))
                {
                    map[num + k].Add(num);
                    map[num].Add(num + k);
                }
                if (map.ContainsKey(num - k))
                {
                    map[num - k].Add(num);
                    map[num].Add(num - k);
                }
            }

            foreach (int num in map.Keys)
            {
                total += map[num].Count;
            }
            return total / 2;
        }
    }
}
