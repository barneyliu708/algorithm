using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC372SuperPow
    {
        public int SuperPow(int a, int[] b)
        {

            int ans = 1;
            for (int i = 0; i < b.Length; i++)
            {
                ans = Pow(ans, 10) * Pow(a, b[i]) % 1337;
            }

            return ans;
        }

        private int Pow(int x, int n)
        {

            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return x % 1337;
            }

            return Pow(x % 1337, n / 2) * Pow(x % 1337, n - n / 2) % 1337;
        }

        public class SecondDone
        {
            public int SuperPow(int a, int[] b)
            {
                int MOD = 1337;
                int n = b.Length;
                int[] dp = new int[n];
                dp[n - 1] = a % MOD;
                for (int i = n - 2; i >= 0; i--)
                {
                    dp[i] = 1;
                    for (int j = 0; j < 10; j++)
                    {
                        dp[i] = (dp[i] * dp[i + 1]) % MOD;
                    }
                }
                int ans = 1;
                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = 0; j < b[i]; j++)
                    {
                        ans = (ans * dp[i]) % MOD;
                    }
                }

                return ans;
            }
        }
    }
}
