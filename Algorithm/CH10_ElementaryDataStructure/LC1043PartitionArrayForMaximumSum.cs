using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1043PartitionArrayForMaximumSum
    {
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            int n = arr.Length;

            int[] dp = new int[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                int max = arr[i - 1];
                for (int l = 1; l <= k && i - l + 1 > 0; l++)
                {
                    max = Math.Max(max, arr[i - l]);
                    dp[i] = Math.Max(dp[i], dp[i - l] + max * l);
                }
            }

            return dp[n];
        }
    }
}
