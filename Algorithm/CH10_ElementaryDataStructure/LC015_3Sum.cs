using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC015_3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> ans = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    TwoSum(nums, i, ans);
                }
            }

            return ans;
        }

        private void TwoSum(int[] nums, int i, List<IList<int>> ans)
        {
            HashSet<int> hashset = new HashSet<int>();
            for (int j = i + 1; j < nums.Length; j++)
            {
                int complement = -nums[i] - nums[j];
                if (hashset.Contains(complement))
                {
                    ans.Add(new List<int>() { nums[i], nums[j], complement });
                    while (j + 1 < nums.Length && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                }
                hashset.Add(nums[j]);
            }
        }

        public class SecondDone
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                List<IList<int>> ans = new List<IList<int>>();
                Array.Sort(nums);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i != 0 && nums[i] == nums[i - 1]) // avoid duplicate triple
                    { // to avoid duplicate
                        continue;
                    }
                    TwoSum(nums, i, ans);
                }

                return ans;
            }

            private void TwoSum(int[] nums, int i, List<IList<int>> ans)
            {
                Dictionary<int, int> map = new Dictionary<int, int>(); // num - indice of num
                int target = 0 - nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int num = nums[j];
                    if (map.ContainsKey(target - num))
                    {
                        ans.Add(new List<int> { nums[i], nums[map[target - num]], nums[j] });
                        while (j + 1 < nums.Length && nums[j + 1] == nums[j]) // avoid duplicate pair
                        {
                            j++;
                        }
                    }
                    map[num] = j;
                }
            }
        }
    }
}
