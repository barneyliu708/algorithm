using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC350IntersectionOfTwoArraysII
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return Intersect(nums2, nums1);
            }

            Dictionary<int, int> map1 = new Dictionary<int, int>();
            foreach (int num in nums1)
            {
                if (!map1.ContainsKey(num))
                {
                    map1[num] = 0;
                }
                map1[num]++;
            }

            IList<int> ans = new List<int>();
            foreach (int num in nums2)
            {
                if (map1.ContainsKey(num) && map1[num] > 0)
                {
                    ans.Add(num);
                    map1[num]--;
                }
            }

            return ans.ToArray();
        }
    }
}
