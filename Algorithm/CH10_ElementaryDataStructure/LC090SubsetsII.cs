using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC090SubsetsII
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            SubsetsWithDup(nums, 0, comb, ans);
            return ans;
        }

        private void SubsetsWithDup(int[] nums, int start, List<int> comb, List<IList<int>> ans)
        {

            ans.Add(new List<int>(comb));

            for (int i = start; i < nums.Length; i++)
            {
                if (i != start && nums[i] == nums[i - 1])
                {
                    continue;
                }
                comb.Add(nums[i]);
                SubsetsWithDup(nums, i + 1, comb, ans);
                comb.Remove(nums[i]);
            }
        }
    }
}
