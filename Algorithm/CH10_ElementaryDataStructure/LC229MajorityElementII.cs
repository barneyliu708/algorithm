using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC229MajorityElementII
    {
        public IList<int> MajorityElement(int[] nums)
        {

            int floor = nums.Length / 3;
            Dictionary<int, int> map = new Dictionary<int, int>();
            HashSet<int> ans = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                {
                    map[num] = 0;
                }
                map[num]++;

                if (map[num] > floor)
                {
                    ans.Add(num);
                }
            }

            return ans.ToList();
        }
    }
}
