using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC131PalindromePartitioning
    {
        public IList<IList<string>> Partition(string s)
        {

            bool[,] dp = new bool[s.Length, s.Length];
            IList<IList<string>> ans = new List<IList<string>>();

            Partition(s, 0, dp, new List<string>(), ans);

            return ans;
        }

        private void Partition(string s, int i, bool[,] dp, IList<string> curList, IList<IList<string>> ans)
        {
            if (i >= s.Length)
            {
                ans.Add(new List<string>(curList));
            }

            for (int j = i; j < s.Length; j++)
            {
                if (s[i] == s[j] && (j <= i + 1 || dp[i + 1, j - 1]))
                {
                    dp[i, j] = true;
                    curList.Add(s.Substring(i, j - i + 1));
                    Partition(s, j + 1, dp, curList, ans);
                    curList.RemoveAt(curList.Count - 1);
                }
            }
        }
    }
}
