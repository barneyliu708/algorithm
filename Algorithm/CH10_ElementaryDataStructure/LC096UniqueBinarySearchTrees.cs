using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC096UniqueBinarySearchTrees
    {
        public int NumTrees(int n)
        {

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }

            return dp[n];
        }

        public class SecondDone
        {
            public int NumTrees(int n)
            {

                int[] dp = new int[n + 1];
                dp[0] = 1;
                dp[1] = 1;

                for (int i = 2; i <= n; i++)
                {
                    for (int j = 0; j <= i - 1; j++) // left subtree's total node number [0, i - 1]
                    {
                        dp[i] += dp[j] * dp[i - j - 1];
                    }
                }

                return dp[n];
            }
        }

        public class ThirdDone
        {
            public int NumTrees(int n)
            {
                int[] dp = new int[n + 1];
                dp[0] = 1;
                for (int i = 1; i <= n; i++)
                {
                    for (int l = 0; l <= i - 1; l++)
                    {
                        int r = i - l - 1;
                        dp[i] += dp[l] * dp[r];
                    }
                }
                return dp[n];
            }
        }
    }
}
