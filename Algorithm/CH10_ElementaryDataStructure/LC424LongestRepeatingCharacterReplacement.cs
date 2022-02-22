using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    internal class LC424LongestRepeatingCharacterReplacement
    {
        public int CharacterReplacement(string s, int k)
        {
            int start = 0;
            int mainCount = 0;
            int ans = 0;
            int[] counts = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'A']++;
                mainCount = Math.Max(mainCount, counts[s[i] - 'A']);
                while (i - start + 1 - mainCount > k) // this also guarantees that start index is always at the left side of i
                { 
                    counts[s[start] - 'A']--;
                    start++;
                }
                ans = Math.Max(ans, i - start + 1);
            }
            return ans;
        }
    }
}
