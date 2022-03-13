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
    }
}
