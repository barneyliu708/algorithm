using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC278FirstBadVersion
    {
        public bool IsBadVersion (int version)
        {
            return true;
        }

        public int FirstBadVersion(int n)
        {

            int start = 1;
            int end = n;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (IsBadVersion(mid))
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return start;
        }
    }
}
