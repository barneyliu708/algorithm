using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC523ContinuousSubarraySum
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            int n = nums.Length;
            if (n <= 1)
            {
                return false;
            }
            int[] presum = new int[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                presum[i] = presum[i - 1] + nums[i - 1];
            }

            Dictionary<int, int> map = new Dictionary<int, int>(); // remainder - index
            for (int i = 1; i < n + 1; i++)
            {
                int remainder = presum[i] % k;
                if (remainder == 0 && i > 1)
                {
                    return true;
                }
                if (map.ContainsKey(remainder))
                {
                    if (i - map[remainder] >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    map[remainder] = i;
                }
            }

            return false;
        }

        public class SecondDone
        {
            public bool CheckSubarraySum(int[] nums, int k)
            {
                int n = nums.Length;
                int[] dp = new int[n + 1];
                for (int i = 0; i < n; i++)
                {
                    dp[i + 1] = dp[i] + nums[i];
                }

                Dictionary<int, int> map = new Dictionary<int, int>(); // remainder - index in dp
                map[0] = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (map.ContainsKey(dp[i] % k))
                    {
                        int j = map[dp[i] % k];
                        if (i - j > 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        map[dp[i] % k] = i;
                    }
                }

                return false;
            }
        }
    }
}
