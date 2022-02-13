using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC018_4Sum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return KSum(nums, target, 0, 4);
        }

        public IList<IList<int>> TwoSum(int[] nums, int target, int start)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            int lo = start;
            int hi = nums.Length - 1;

            while (lo < hi)
            {
                int curSum = nums[lo] + nums[hi];
                if (curSum < target || (lo > start && nums[lo] == nums[lo - 1]))
                {
                    lo++;
                }
                else if (curSum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
                {
                    hi--;
                }
                else
                {
                    ans.Add(new List<int>() { nums[lo], nums[hi] });
                    lo++;
                    hi--;
                }
            }

            return ans;
        }

        public IList<IList<int>> KSum(int[] nums, int target, int start, int k)
        {
            IList<IList<int>> ans = new List<IList<int>>();

            if (start == nums.Length)
            {
                return ans;
            }

            int avgValue = target / k;
            if (nums[start] > avgValue || nums[nums.Length - 1] < avgValue)
            {
                return ans;
            }

            if (k == 2)
            {
                return TwoSum(nums, target, start);
            }

            for (int i = start; i < nums.Length; i++)
            {
                if (i == start || nums[i - 1] != nums[i])
                {
                    foreach (IList<int> subset in KSum(nums, target - nums[i], i + 1, k - 1))
                    {
                        List<int> subans = new List<int>() { nums[i] };
                        subans.AddRange(subset);
                        ans.Add(subans);
                    }
                }
            }

            return ans;
        }
    }
}
