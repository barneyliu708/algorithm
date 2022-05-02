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

        public class SecondDone
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                List<IList<int>> ans = new List<IList<int>>();
                Permute(nums, 0, ans);
                return ans;
            }

            private void Permute(int[] nums, int i, List<IList<int>> ans)
            {
                if (i == nums.Length)
                {
                    ans.Add(new List<int>(nums));
                }

                for (int j = i; j < nums.Length; j++)
                {
                    Swap(nums, i, j);
                    Permute(nums, i + 1, ans); // use i + 1 to the next level, rather than the j + 1
                    Swap(nums, i, j);
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
}
