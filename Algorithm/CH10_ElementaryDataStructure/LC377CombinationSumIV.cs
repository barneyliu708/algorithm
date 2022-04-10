using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC377CombinationSumIV
    {
        public int CombinationSum4(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            return Combination(nums, target, map);
        }

        private int Combination(int[] nums, int target, Dictionary<int, int> map)
        {
            if (target == 0)
            {
                return 1;
            }

            if (map.ContainsKey(target))
            {
                return map[target];
            }

            int ans = 0;
            foreach (int num in nums)
            {
                if (target - num >= 0)
                {
                    ans += Combination(nums, target - num, map);
                }
            }

            map[target] = ans;

            return ans;
        }

        public class SecondDone
        {
            public int CombinationSum4(int[] nums, int target)
            {
                Dictionary<int, int> memo = new Dictionary<int, int>();
                return Combination(nums, target, memo);
            }

            private int Combination(int[] nums, int target, Dictionary<int, int> memo)
            {
                if (target < 0)
                {
                    return 0;
                }

                if (target == 0)
                {
                    // add one more result
                    return 1;
                }

                if (memo.ContainsKey(target))
                {
                    return memo[target];
                }

                int ans = 0;
                foreach (int num in nums)
                {
                    ans += Combination(nums, target - num, memo);
                }

                memo[target] = ans;
                return ans;
            }
        }

        public class SecondDone_DP
        {
            public int CombinationSum4(int[] nums, int target)
            {
                int[] dp = new int[target + 1];
                dp[0] = 1;
                for (int sum = 1; sum <= target; sum++)
                {
                    foreach (int num in nums)
                    {
                        if (sum - num >= 0)
                        {
                            dp[sum] += dp[sum - num];
                        }
                    }
                }
                return dp[target];
            }
        }
    }
}
