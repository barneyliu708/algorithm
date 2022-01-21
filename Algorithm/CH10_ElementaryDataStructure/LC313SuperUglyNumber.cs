using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC313SuperUglyNumber
    {
        public int NthSuperUglyNumber(int n, int[] primes)
        {

            int[] indexs = new int[primes.Length];
            List<int> ans = new List<int>();
            ans.Add(1);

            while (ans.Count < n)
            {

                int minValue = int.MaxValue;
                int minIndex = indexs.Length;
                for (int i = 0; i < indexs.Length; i++)
                {
                    int val = ans[indexs[i]] * primes[i];
                    if (val < minValue)
                    {
                        minValue = val;
                        minIndex = i;
                    }
                }

                indexs[minIndex]++;
                if (minValue > ans[ans.Count - 1])
                {
                    ans.Add(minValue);
                }
            }

            return ans[ans.Count - 1];
        }
    }
}
