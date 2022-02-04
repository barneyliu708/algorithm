using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC349IntersectionOfTwoArrays
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {

            if (nums1.Length > nums2.Length)
            {
                return Intersection(nums2, nums1);
            }

            HashSet<int> set1 = new HashSet<int>();
            foreach (int num in nums1)
            {
                set1.Add(num);
            }

            HashSet<int> ans = new HashSet<int>();
            foreach (int num in nums2)
            {
                if (set1.Contains(num))
                {
                    ans.Add(num);
                }
            }

            return ans.ToArray();
        }
    }
}
