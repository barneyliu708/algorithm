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

        public class ThirdDone
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                HashSet<int> numsSet = new HashSet<int>(nums);
                List<int> cur = new List<int>();
                List<IList<int>> ans = new List<IList<int>>();
                Permute(numsSet, cur, ans);
                return ans;
            }

            private void Permute(HashSet<int> nums, List<int> cur, List<IList<int>> ans)
            {
                if (nums.Count == 0)
                {
                    ans.Add(new List<int>(cur));
                    return;
                }

                HashSet<int> numsCopy = new HashSet<int>(nums);
                foreach (int num in numsCopy)
                {
                    cur.Add(num);
                    nums.Remove(num);
                    Permute(nums, cur, ans);
                    nums.Add(num);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }

        public class ForthDone
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                List<IList<int>> ans = new List<IList<int>>();
                Utility(nums, 0, ans);
                return ans;
            }

            private void Utility(int[] nums, int istart, List<IList<int>> ans)
            {
                if (istart == nums.Length)
                {
                    ans.Add(new List<int>(nums));
                    return;
                }

                for (int i = istart; i < nums.Length; i++)
                {
                    Swap(nums, istart, i);
                    Utility(nums, istart + 1, ans); // when passing to the next level, should pass istart + 1 rathe than i + 1
                    Swap(nums, istart, i);
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
