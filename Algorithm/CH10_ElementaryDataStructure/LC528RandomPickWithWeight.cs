using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC528RandomPickWithWeight
    {
        public class Solution
        {

            private int[] presum;
            private int total;
            private Random rand = new Random();

            public Solution(int[] w)
            {
                presum = new int[w.Length];

                int pre = 0;
                for (int i = 0; i < w.Length; i++)
                {
                    pre += w[i];
                    presum[i] = pre;
                }
                total = pre;
            }

            public int PickIndex()
            {
                double target = total * rand.NextDouble();
                int l = 0;
                int r = presum.Length;
                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if (target > presum[mid])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid;
                    }
                }
                return l;
            }
        }
    }
}
