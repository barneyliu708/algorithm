using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC368LargestDivisibleSubset
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {

            if (nums.Length == 0)
            {
                return new List<int>();
            }

            Array.Sort(nums);
            IList<int> ans = new List<int>();
            IList<IList<int>> EDS = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                EDS.Add(new List<int>());
            }
            for (int i = 0; i < nums.Length; i++)
            {
                IList<int> maxSubset = new List<int>();

                for (int k = 0; k < i; k++)
                {
                    if (nums[i] % nums[k] == 0 && maxSubset.Count < EDS[k].Count)
                    {
                        maxSubset = EDS[k];
                    }
                }

                // EDS[i].AddRange(maxSubset);
                foreach (var el in maxSubset)
                {
                    EDS[i].Add(el);
                }
                EDS[i].Add(nums[i]);

                if (ans.Count < EDS[i].Count)
                {
                    ans = EDS[i];
                }
            }

            return ans;
        }
    }
}
