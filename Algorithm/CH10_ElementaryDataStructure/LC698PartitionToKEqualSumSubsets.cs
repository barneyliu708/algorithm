using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC698PartitionToKEqualSumSubsets
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            if (sum % k != 0)
            {
                return false;
            }

            Array.Sort(nums, (int x, int y) => {
                return y.CompareTo(x); // decending order
            });

            int targetsum = sum / k;
            bool[] visited = new bool[nums.Length];

            return CanPartition(nums, k, targetsum, 0, 0, 0, visited);
        }

        private bool CanPartition(int[] nums, int k, int targetsum, int index, int cursum, int count, bool[] visited)
        {

            // We made k - 1 subsets with target sum and last subset will also have target sum.
            if (count == k - 1)
            {
                return true;
            }

            if (cursum > targetsum)
            {
                return false;
            }

            if (cursum == targetsum)
            {
                return CanPartition(nums, k, targetsum, 0, 0, count + 1, visited);
            }

            for (int i = index; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    if (CanPartition(nums, k, targetsum, i + 1, cursum + nums[i], count, visited))
                    {
                        return true;
                    }
                    visited[i] = false;
                }
            }

            return false;
        }
    }
}
