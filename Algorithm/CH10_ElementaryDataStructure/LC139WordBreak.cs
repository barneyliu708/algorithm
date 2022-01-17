using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC139WordBreak
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {

            return WordBreak(s, 0, new bool[s.Length], new HashSet<string>(wordDict));
        }

        private bool WordBreak(string s, int i, bool[] dp, HashSet<string> wordDict)
        {
            Console.WriteLine(i);
            if (i >= s.Length)
            {
                return true;
            }

            if (dp[i])
            {
                return true;
            }

            for (int j = i; j < s.Length; j++)
            {

                if (wordDict.Contains(s.Substring(i, j - i + 1)) && WordBreak(s, j + 1, dp, wordDict))
                {
                    return dp[i] = true;
                }
            }

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
}
