﻿using NUnit.Framework;
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
    }
}
