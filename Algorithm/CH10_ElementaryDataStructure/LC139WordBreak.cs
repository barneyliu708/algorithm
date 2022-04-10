using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC139WordBreak
    {
        public class RecursionWithMemoization_DP
        {
            public bool WordBreak(string s, IList<string> wordDict)
            {

                int[] dp = new int[s.Length];
                return WordBreak(s, 0, dp, new HashSet<string>(wordDict));
            }

            private bool WordBreak(string s, int i, int[] dp, HashSet<string> wordDict)
            {
                if (i >= s.Length)
                {
                    return true;
                }

                if (dp[i] != 0) // 0 = not visited, 1 = false, 2 = true;
                {
                    return dp[i] == 2;
                }

                for (int j = i; j < s.Length; j++)
                {

                    if (wordDict.Contains(s.Substring(i, j - i + 1)) && WordBreak(s, j + 1, dp, wordDict))
                    {
                        dp[i] = 2;
                        return true;
                    }
                }

                dp[i] = 1;
                return false;
            }

            [Test]
            public void TestCase1()
            {
                string s = "applepenapple";
                IList<string> wordDict = new List<string> { "apple", "pen" };

                Assert.AreEqual(true, WordBreak(s, wordDict));
            }

            [Test]
            public void TestCase2()
            {
                string s = "leetcodeleetcodeleetcodeleetapplecodeleetcodeleetcodeapple";
                IList<string> wordDict = new List<string> { "leet", "code", "apple" };

                Assert.AreEqual(true, WordBreak(s, wordDict));
            }

            [Test]
            public void TestCase3()
            {
                string s = "catsandog";
                IList<string> wordDict = new List<string> { "cats", "dog", "sand", "and", "cat" };

                Assert.AreEqual(false, WordBreak(s, wordDict));
            }
        }
        
        public class DynamicProgramming
        {
            public bool WordBreak(string s, IList<string> wordDict)
            {

                bool[] dp = new bool[s.Length + 1];
                dp[s.Length] = true;

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    for (int j = s.Length - 1; j >= i; j--)
                    {
                        if (dp[j + 1] && wordDict.Contains(s.Substring(i, j - i + 1)))
                        {
                            dp[i] = true;
                            break;
                        }
                    }
                }

                return dp[0];
            }
        }

        public class SecondDone_Dft_Memorization
        {
            public bool WordBreak(string s, IList<string> wordDict)
            {
                int[] memo = new int[s.Length];
                return WordBreak(s, 0, new HashSet<string>(wordDict), memo);
            }

            private bool WordBreak(string s, int start, HashSet<string> wordDict, int[] memo)
            {
                if (start == s.Length)
                {
                    return true;
                }
                if (memo[start] != 0)
                {
                    return memo[start] == 1;
                }
                for (int i = start; i < s.Length; i++)
                {
                    string word = s.Substring(start, i - start + 1);
                    if (!wordDict.Contains(word))
                    {
                        continue;
                    }
                    if (WordBreak(s, i + 1, wordDict, memo))
                    {
                        memo[start] = 1;
                        return true;
                    }
                }
                memo[start] = -1;
                return false;
            }
        }

        public class SecondDone_DynamicProgramming
        {
            public bool WordBreak(string s, IList<string> wordDict)
            {
                bool[] memo = new bool[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i; j >= -1; j--)
                    {
                        if ((j == -1 || memo[j]) && wordDict.Contains(s.Substring(j + 1, i - j)))
                        {
                            memo[i] = true;
                            break;
                        }
                    }
                }
                return memo[s.Length - 1];
            }
        }
    }
}
