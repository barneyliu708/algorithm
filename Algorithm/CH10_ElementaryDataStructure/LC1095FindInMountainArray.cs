using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1095FindInMountainArray
    {

        // This is MountainArray's API interface.
        // You should not implement it, or speculate about its implementation
        public class MountainArray
        {
            public int Get(int index) { return 0; }
            public int Length() { return 0; }
        }

        public int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int pi = FindPeekElement(mountainArr);
            if (mountainArr.Get(pi) == target)
            {
                return pi;
            }

            // find the target in the left half - ascending
            int l = 0;
            int r = pi - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (mountainArr.Get(mid) == target)
                {
                    return mid;
                }
                if (mountainArr.Get(mid) < target)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            // find the target in the right half - descending
            l = pi + 1;
            r = mountainArr.Length() - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (mountainArr.Get(mid) == target)
                {
                    return mid;
                }
                if (mountainArr.Get(mid) < target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return -1;
        }

        private int FindPeekElement(MountainArray arr)
        {
            int l = 0;
            int r = arr.Length() - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr.Get(mid) < arr.Get(mid + 1))
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return l;
        }
    }
}
