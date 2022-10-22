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

        public class SecondDone
        {
            public int MaxSubArrayLen(int[] nums, int k)
            {
                int[] presum = new int[nums.Length + 1];
                for (int i = 0; i < nums.Length; i++)
                {
                    presum[i + 1] = presum[i] + nums[i];
                }
                Dictionary<int, int> map = new Dictionary<int, int>(); // value - index
                int ans = 0;
                for (int i = 0; i < presum.Length; i++)
                {
                    if (map.ContainsKey(presum[i] - k))
                    {
                        int leftIdx = map[presum[i] - k];
                        ans = Math.Max(ans, i - leftIdx);
                    }
                    if (!map.ContainsKey(presum[i]))
                    {
                        map[presum[i]] = i;
                    }
                }
                return ans;
            }
        }
    }
}
