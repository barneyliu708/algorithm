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

        public class SecondDone
        {
            public IList<IList<int>> FourSum(int[] nums, int target)
            {
                Array.Sort(nums);
                return KSum(nums, 0, target, 4);
            }

            private IList<IList<int>> KSum(int[] nums, int start, int target, int k)
            {
                IList<IList<int>> ans = new List<IList<int>>();

                if (start >= nums.Length)
                {
                    return ans;
                }

                // since nums is sorted, we can check the minimum and maxmum element to the target
                if (nums[start] > target / k || nums[nums.Length - 1] < target / k) // target / k to avoid int overflow
                {
                    return ans;
                }

                if (k == 2)
                {
                    return TwoSum(nums, start, target);
                }

                for (int i = start; i < nums.Length; i++)
                {
                    if (i != start && nums[i] == nums[i - 1])
                    {
                        continue;
                    }
                    int num = nums[i];
                    foreach (IList<int> subset in KSum(nums, i + 1, target - num, k - 1))
                    {
                        List<int> subAns = new List<int>() { num };
                        subAns.AddRange(subset);
                        ans.Add(subAns);
                    }
                }

                return ans;
            }

            private IList<IList<int>> TwoSum(int[] nums, int start, int target)
            {
                IList<IList<int>> ans = new List<IList<int>>();
                int l = start;
                int r = nums.Length - 1;
                while (l < r)
                {
                    int sum = nums[l] + nums[r];
                    if (sum < target || (l != start && nums[l] == nums[l - 1]))
                    {
                        l++;
                    }
                    else if (sum > target || r != nums.Length - 1 && nums[r] == nums[r + 1])
                    {
                        r--;
                    }
                    else
                    {
                        ans.Add(new List<int> { nums[l], nums[r] });
                        l++;
                        r--;
                    }
                }
                return ans;
            }
        }

        public class ThirdDone
        {
            public IList<IList<int>> FourSum(int[] nums, int target)
            {
                Array.Sort(nums);
                return KSum(nums, target, 0, 4);
            }

            private List<IList<int>> KSum(int[] nums, long target, int istart, int k)
            {
                List<IList<int>> ans = new List<IList<int>>();
                if (istart == nums.Length)
                {
                    return ans;
                }

                if (k == 2)
                {
                    return TwoSum(nums, target, istart);
                }

                for (int i = istart; i < nums.Length; i++)
                {
                    if (i == istart || nums[i] != nums[i - 1])
                    {
                        foreach (List<int> sublist in KSum(nums, target - nums[i], i + 1, k - 1))
                        {
                            List<int> list = new List<int>() { nums[i] };
                            list.AddRange(sublist);
                            ans.Add(list);
                        }
                    }
                }

                return ans;
            }

            private List<IList<int>> TwoSum(int[] nums, long target, int istart)
            {
                List<IList<int>> ans = new List<IList<int>>();
                HashSet<long> hashset = new HashSet<long>();
                for (int i = istart; i < nums.Length; i++)
                {
                    if (ans.Count == 0 || nums[i] != ans[ans.Count - 1][1])
                    {
                        if (hashset.Contains(target - nums[i]))
                        {
                            ans.Add(new List<int>() { (int)target - nums[i], nums[i] });
                        }
                    }
                    hashset.Add((long)nums[i]);
                }
                return ans;
            }
        }
    }
}
