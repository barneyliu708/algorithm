using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC078Subsets
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            Subsets(nums, 0, comb, ans);
            return ans;
        }

        private void Subsets(int[] nums, int start, List<int> comb, List<IList<int>> ans)
        {

            ans.Add(new List<int>(comb));

            for (int i = start; i < nums.Length; i++)
            {
                comb.Add(nums[i]);
                Subsets(nums, i + 1, comb, ans);
                comb.Remove(nums[i]);
            }
        }
    }
}
