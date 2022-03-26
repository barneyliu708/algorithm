using System.Collections.Generic;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC454_4SumII
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int count = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int n1 in nums1)
            {
                foreach (int n2 in nums2)
                {
                    if (!map.ContainsKey(n1 + n2))
                    {
                        map[n1 + n2] = 0;
                    }
                    map[n1 + n2]++;
                }
            }
            foreach (int n3 in nums3)
            {
                foreach (int n4 in nums4)
                {
                    if (map.ContainsKey(-(n3 + n4)))
                    {
                        count += map[-(n3 + n4)];
                    }
                }
            }
            return count;
        }
    }
}
