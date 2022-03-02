using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC046Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            Permute(nums, 0, ans);
            return ans;
        }

        private void Permute(int[] nums, int start, List<IList<int>> ans)
        {
            if (start == nums.Length)
            {
                ans.Add(new List<int>(nums));
            }

            for (int i = start; i < nums.Length; i++)
            {
                Swap(nums, start, i);
                Permute(nums, start + 1, ans);
                Swap(nums, start, i);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
