using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1048LongestStringChain
    {
        public int LongestStrChain(string[] words)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();

            Array.Sort(words, (string x, string y) => {
                return x.Length.CompareTo(y.Length);
            });

            int ans = 1;
            foreach (string word in words)
            {
                // initiate the count of word with 1
                dp[word] = 1;

                // iterate to check all the possible predecessor of the current word
                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(word);
                    sb.Remove(i, 1);
                    string predecessor = sb.ToString();

                    if (dp.ContainsKey(predecessor))
                    {
                        dp[word] = Math.Max(dp[word], dp[predecessor] + 1);
                    }
                }

                // update the global longest chain
                ans = Math.Max(ans, dp[word]);
            }

            return ans;
        }
    }
}
