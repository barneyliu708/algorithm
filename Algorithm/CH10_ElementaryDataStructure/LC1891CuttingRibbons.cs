using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1891CuttingRibbons
    {
        public int MaxLength(int[] ribbons, int k)
        {
            int l = 1;
            int r = int.MaxValue;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (IsCutPossible(ribbons, mid, k))
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

        private bool IsCutPossible(int[] ribbons, int length, int k)
        {
            int count = 0;
            foreach (int ribbon in ribbons)
            {
                count += ribbon / length;
            }

            return count >= k;
        }
    }
}
