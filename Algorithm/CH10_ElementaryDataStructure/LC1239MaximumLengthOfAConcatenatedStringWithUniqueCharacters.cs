using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1239MaximumLengthOfAConcatenatedStringWithUniqueCharacters
    {
        public int MaxLength(IList<string> arr)
        {
            return MaxLength(arr, 0, new Dictionary<char, int>());
        }

        private int MaxLength(IList<string> arr, int start, Dictionary<char, int> counts)
        {

            foreach (char key in counts.Keys)
            {
                if (counts[key] > 1)
                {
                    return 0;
                }
            }

            int ans = counts.Count;
            for (int i = start; i < arr.Count; i++)
            {

                foreach (char ch in arr[i])
                {
                    if (!counts.ContainsKey(ch))
                    {
                        counts[ch] = 0;
                    }
                    counts[ch]++;
                }

                ans = Math.Max(ans, MaxLength(arr, i + 1, counts));

                foreach (char ch in arr[i])
                {
                    counts[ch]--;
                    if (counts[ch] == 0)
                    {
                        counts.Remove(ch);
                    }
                }
            }

            return ans;
        }

        public class SecondDone
        {
            public int MaxLength(IList<string> arr)
            {
                return MaxLength(arr, 0, new int[26]);
            }

            private int MaxLength(IList<string> arr, int istart, int[] count)
            {
                int curLen = 0;
                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] > 1)
                    {
                        return 0;
                    }
                    if (count[i] == 1)
                    {
                        curLen++;
                    }
                }

                int ans = curLen;
                for (int i = istart; i < arr.Count; i++)
                {
                    foreach (char ch in arr[i])
                    {
                        count[ch - 'a']++;
                    }

                    ans = Math.Max(ans, MaxLength(arr, i + 1, count));

                    foreach (char ch in arr[i])
                    {
                        count[ch - 'a']--;
                    }
                }

                return ans;
            }
        }
    }
}
