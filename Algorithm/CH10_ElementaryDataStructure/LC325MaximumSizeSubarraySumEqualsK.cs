using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC325MaximumSizeSubarraySumEqualsK
    {
        public int MaxSubArrayLen(int[] nums, int k)
        {

            int[] prefix = new int[nums.Length + 1];
            prefix[0] = 0;
            for (int i = 1; i < prefix.Length; i++)
            {
                prefix[i] = prefix[i - 1] + nums[i - 1];
            }

            int ans = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < prefix.Length; i++)
            {
                if (map.ContainsKey(prefix[i] - k))
                {
                    ans = Math.Max(ans, i - map[prefix[i] - k]);
                }
                // only add kv pair when it is not exist to get the longest result
                if (!map.ContainsKey(prefix[i]))
                {
                    map[prefix[i]] = i;
                }
            }

            return ans;
        }
    }
}
