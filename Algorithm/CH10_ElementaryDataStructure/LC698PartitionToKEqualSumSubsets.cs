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

        public class SecondDone
        {
            public bool CanPartitionKSubsets(int[] nums, int k)
            {

                // calculate the sume
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
                    return y.CompareTo(x);
                });
                int targetSum = sum / k;
                bool[] visited = new bool[nums.Length];
                Dictionary<string, bool> memo = new Dictionary<string, bool>();
                return CanPartition(nums, k, targetSum, 0, 0, 0, visited, memo);
            }

            private bool CanPartition(int[] nums, int k, int targetSum, int curSum, int starti, int count, bool[] visited, Dictionary<string, bool> memo)
            {

                if (count == k - 1)
                {
                    return true;
                }

                if (curSum > targetSum)
                {
                    return false;
                }

                string subsethash = string.Join("", visited);
                if (memo.ContainsKey(subsethash))
                {
                    return memo[subsethash];
                }

                if (curSum == targetSum)
                {
                    memo[subsethash] = CanPartition(nums, k, targetSum, 0, 0, count + 1, visited, memo);
                    return memo[subsethash];
                }

                for (int i = starti; i < nums.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        subsethash = string.Join("", visited);
                        memo[subsethash] = CanPartition(nums, k, targetSum, curSum + nums[i], i + 1, count, visited, memo);
                        if (memo[subsethash])
                        {
                            return true;
                        }
                        visited[i] = false;
                    }
                }

                subsethash = string.Join("", visited);
                memo[subsethash] = false;
                return false;
            }
        }

        public class ThirdDone
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

                bool[] visited = new bool[nums.Length];
                return Backtracking(nums, k, 0, 0, sum / k, 0, visited);
            }

            private bool Backtracking(int[] nums, int k, int curSum, int istart, int targetSum, int count, bool[] visited)
            {

                if (count == k - 1)
                {
                    return true;
                }

                if (curSum == targetSum)
                {
                    return Backtracking(nums, k, 0, 0, targetSum, count + 1, visited);
                }

                if (curSum > targetSum)
                {
                    return false;
                }

                for (int i = istart; i < nums.Length; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }
                    visited[i] = true;
                    if (Backtracking(nums, k, curSum + nums[i], i + 1, targetSum, count, visited))
                    {
                        return true;
                    }
                    visited[i] = false;
                }
                return false;
            }
        }
    }
}
