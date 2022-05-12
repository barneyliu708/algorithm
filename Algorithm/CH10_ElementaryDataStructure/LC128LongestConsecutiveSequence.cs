using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC128LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {

            HashSet<int> hashset = new HashSet<int>();
            foreach (int num in nums)
            {
                hashset.Add(num);
            }

            int ans = 0;
            foreach (int num in hashset)
            {
                if (!hashset.Contains(num - 1))
                {
                    int curNum = num;
                    int curLength = 1;

                    while (hashset.Contains(curNum + 1))
                    {
                        curNum++;
                        curLength++;
                    }

                    ans = Math.Max(ans, curLength);
                }
            }

            return ans;
        }

        public class SecondDone
        {
            public int LongestConsecutive(int[] nums)
            {
                HashSet<int> hashset = new HashSet<int>();
                foreach (int num in nums)
                {
                    hashset.Add(num);
                }

                int ans = 0;
                foreach (int num in nums)
                {
                    if (!hashset.Contains(num - 1))
                    {
                        int count = 0;
                        int n = num;
                        while (hashset.Contains(n))
                        {
                            count++;
                            n++;
                        }
                        ans = Math.Max(ans, count);
                    }
                }

                return ans;
            }
        }
    }
}
