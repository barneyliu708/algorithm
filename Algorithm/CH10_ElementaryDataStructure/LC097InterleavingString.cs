using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC097InterleavingString
    {
        public class BruteForceRecursion
        {
            public bool IsInterleave(string s1, string s2, string s3)
            {
                if (s1.Length + s2.Length != s3.Length)
                {
                    return false;
                }

                return IsInterleave(s1, 0, s2, 0, "", s3);
            }

            public bool IsInterleave(string s1, int i, string s2, int j, string output, string s3)
            {
                if (output != s3.Substring(0, output.Length))
                {
                    return false;
                }

                if (output == s3 && i == s1.Length && j == s2.Length)
                {
                    return true;
                }

                bool ans = false;
                if (i < s1.Length)
                {
                    ans = IsInterleave(s1, i + 1, s2, j, output + s1[i], s3);
                }
                if (j < s2.Length)
                {
                    ans = ans || IsInterleave(s1, i, s2, j + 1, output + s2[j], s3);
                }

                return ans;
            }
        }

        public class RecursionWithMemoization_DynamicProgramming
        {
            public bool IsInterleave(string s1, string s2, string s3)
            {
                if (s1.Length + s2.Length != s3.Length)
                {
                    return false;
                }

                int[,] dp = new int[s1.Length, s2.Length];
                for (int i = 0; i < dp.GetLength(0); i++)
                {
                    for (int j = 0; j < dp.GetLength(1); j++)
                    {
                        dp[i, j] = -1;
                    }
                }

                return IsInterleave(s1, 0, s2, 0, dp, s3);
            }

            public bool IsInterleave(string s1, int i, string s2, int j, int[,] dp, string s3)
            {

                if (i == s1.Length)
                {
                    return s2.Substring(j) == s3.Substring(i + j);
                }

                if (j == s2.Length)
                {
                    return s1.Substring(i) == s3.Substring(i + j);
                }

                if (dp[i, j] != -1)
                {
                    return dp[i, j] == 1;
                }

                bool ans = (s3[i + j] == s1[i] && IsInterleave(s1, i + 1, s2, j, dp, s3)) ||
                           (s3[i + j] == s2[j] && IsInterleave(s1, i, s2, j + 1, dp, s3));

                dp[i, j] = ans ? 1 : 0;

                return ans;
            }
        }
        public class DynamicProgramming_2D
        {
            public bool IsInterleave(string s1, string s2, string s3)
            {
                if (s1.Length + s2.Length != s3.Length)
                {
                    return false;
                }

                bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
                for (int i = 0; i <= s1.Length; i++)
                {
                    for (int j = 0; j <= s2.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            dp[i, j] = true;
                        }
                        else if (i == 0)
                        {
                            dp[i, j] = dp[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                        }
                        else if (j == 0)
                        {
                            dp[i, j] = dp[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                        }
                        else
                        {
                            dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                        }
                    }
                }

                return dp[s1.Length, s2.Length];
            }
        }

        public class ForthDone
        {
            public bool IsInterleave(string s1, string s2, string s3)
            {

                int m = s1.Length;
                int n = s2.Length;

                if (s3.Length != m + n)
                {
                    return false;
                }

                bool[,] dp = new bool[m + 1, n + 1];
                dp[0, 0] = true;
                for (int i = 1; i <= m; i++)
                {
                    dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
                }
                for (int j = 1; j <= n; j++)
                {
                    dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];
                }
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
                return dp[m, n];
            }
        }
    }
}
