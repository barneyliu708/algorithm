using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC279PerfectSquares
    {
        public int NumSquares(int n)
        {

            int[] dp = new int[n + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;

            int maxSqrIndx = (int)Math.Sqrt(n) + 1;
            int[] squares = new int[maxSqrIndx];
            for (int i = 1; i < maxSqrIndx; i++)
            {
                squares[i] = i * i;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s < maxSqrIndx; s++)
                {
                    if (i < squares[s])
                    {
                        break;
                    }

                    dp[i] = Math.Min(dp[i], dp[i - squares[s]] + 1);
                }
            }

            return dp[n];
        }

        public class SecondDone
        {
            public int NumSquares(int n)
            {
                int[] dp = new int[n + 1];
                for (int i = 0; i <= n; i++)
                {
                    dp[i] = int.MaxValue;
                }
                int[] squars = new int[(int)Math.Sqrt(n) + 1];
                for (int i = 0; i < squars.Length; i++)
                {
                    squars[i] = i * i;
                }

                dp[0] = 0;
                for (int i = 1; i <= n; i++)
                {
                    for (int s = 1; s < squars.Length; s++)
                    {
                        if (i < squars[s])
                        {
                            break;
                        }
                        dp[i] = Math.Min(dp[i], dp[i - squars[s]] + 1);
                    }
                }

                return dp[n];
            }
        }

        public class ThirdDone_DP_Memorization
        {
            public int NumSquares(int n)
            {
                Dictionary<int, int> memo = new Dictionary<int, int>();
                for (int i = 1; i * i <= n; i++)
                {
                    memo[i * i] = 1;
                }
                int[] squars = new int[(int)Math.Sqrt(n) + 1];
                for (int i = 0; i < squars.Length; i++)
                {
                    squars[i] = i * i;
                }
                return NumSquares(n, memo, squars);
            }

            private int NumSquares(int n, Dictionary<int, int> memo, int[] squars)
            {
                if (memo.ContainsKey(n))
                {
                    // Console.WriteLine(n + " - " + memo[n]);
                    return memo[n];
                }
                int root = (int)Math.Sqrt(n);
                if (root * root == n)
                { // n is perfect square
                    memo[n] = 1;
                    return memo[n];
                }

                int min = n;
                for (int s = 1; s < squars.Length && squars[s] < n; s++)
                {
                    min = Math.Min(min, 1 + NumSquares(n - squars[s], memo, squars));
                }

                memo[n] = min;
                // Console.WriteLine(n + " - " + memo[n]);
                return memo[n];
            }
        }
    }
}
