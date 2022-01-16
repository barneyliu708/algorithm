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
        
    }
}
