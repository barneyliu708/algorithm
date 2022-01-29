using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC219ContainsDuplicateII
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]) && i - map[nums[i]] <= k)
                {
                    return true;
                }
                map[nums[i]] = i;
            }

            return false;
        }
    }
}
