using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1062LongestRepeatingSubstring
    {
        class Approach_1
        {
            public int LongestRepeatingSubstring(string s)
            {
                // if there is a duplicate substring of length k, that means there is a duplicate substring of k - 1
                // can use binary search to find the max length that has a duplicate substring
                int l = 1;
                int r = s.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (HasDuplicate(s, mid))
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                return r;
            }

            private bool HasDuplicate(string s, int length)
            {
                HashSet<string> hashset = new HashSet<string>();
                for (int i = 0; i < s.Length - length + 1; i++)
                {
                    string substr = s.Substring(i, length);
                    if (hashset.Contains(substr))
                    {
                        return true;
                    }
                    hashset.Add(substr);
                }
                return false;
            }
        }

        class Approach_2_HashSetOfHash
        {
            public int LongestRepeatingSubstring(string s)
            {
                // if there is a duplicate substring of length k, that means there is a duplicate substring of k - 1
                // can use binary search to find the max length that has a duplicate substring
                int l = 1;
                int r = s.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (HasDuplicate2(s, mid))
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                return r;
            }

            private bool HasDuplicate2(string s, int length)
            {
                HashSet<int> hashset = new HashSet<int>();
                for (int i = 0; i < s.Length - length + 1; i++)
                {
                    int substrHash = s.Substring(i, length).GetHashCode();
                    if (hashset.Contains(substrHash))
                    {
                        return true;
                    }
                    hashset.Add(substrHash);
                }
                return false;
            }
        }
    }
}
