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

        public class TopDowm_DP
        {
            public IList<int> LargestDivisibleSubset(int[] nums)
            {
                Array.Sort(nums);
                Dictionary<int, List<int>> memo = new Dictionary<int, List<int>>();
                List<int> maxSubset = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    List<int> curSubset = Backtracking(nums, i, memo);
                    if (curSubset.Count > maxSubset.Count)
                    {
                        maxSubset = curSubset;
                    }
                }
                return maxSubset;
            }

            private List<int> Backtracking(int[] nums, int i, Dictionary<int, List<int>> memo)
            {

                if (memo.ContainsKey(i))
                {
                    return memo[i];
                }

                List<int> maxSubset = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % nums[j] == 0)
                    {
                        List<int> curSubset = Backtracking(nums, j, memo);
                        if (curSubset.Count > maxSubset.Count)
                        {
                            maxSubset = curSubset;
                        }
                    }
                }

                memo[i] = new List<int>(maxSubset);
                memo[i].Add(nums[i]);
                return memo[i];
            }
        }

        public class ThirdDone
        {
            public IList<int> LargestDivisibleSubset(int[] nums)
            {
                Array.Sort(nums);

                int n = nums.Length;
                List<int>[] dp = new List<int>[n];
                // for (int i = 0; i < n; i++) {
                //     dp[i] = new List<int>();
                // }

                List<int> ans = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new List<int>() { nums[i] };
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (nums[i] % nums[k] == 0)
                        { // we have sorted the nums, so nums[i] always is greater than nums[k]
                            if (dp[k].Count + 1 > dp[i].Count)
                            {
                                dp[i] = new List<int>(dp[k]);
                                dp[i].Add(nums[i]);
                                // Console.WriteLine(i + ": " + string.Join(' ', dp[i]));
                            }
                        }
                    }
                    // Console.WriteLine(i + ": " + string.Join(' ', dp[i]));
                    if (dp[i].Count > ans.Count)
                    {
                        ans = dp[i];
                    }
                }
                return ans;
            }
        }
    }
}
