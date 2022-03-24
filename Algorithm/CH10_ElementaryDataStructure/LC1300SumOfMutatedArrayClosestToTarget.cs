using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1300SumOfMutatedArrayClosestToTarget
    {
        public int FindBestValue(int[] arr, int target)
        {

            Array.Sort(arr);

            // prepare the presum
            int[] presum = new int[arr.Length + 1];
            int pre = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                presum[i + 1] = pre + arr[i];
                pre = presum[i + 1];
            }

            // find the closest value
            int minv = int.MaxValue;
            int diff = int.MaxValue;
            int lv = 0;
            int rv = arr[arr.Length - 1];
            while (lv <= rv)
            {
                int midv = lv + (rv - lv) / 2;
                int i = FindIndex(arr, midv);
                int totalsum = presum[i] + midv * (arr.Length - i);

                if (totalsum == target)
                {
                    return midv;
                }
                // update binary bounary
                if (totalsum > target)
                {
                    rv = midv - 1;
                }
                else
                {
                    lv = midv + 1;
                }

                // update the best answer so far 
                if (Math.Abs(target - totalsum) < diff || (Math.Abs(target - totalsum) == diff && midv < minv))
                {
                    minv = midv;
                    diff = Math.Abs(target - totalsum);
                }
            }

            return minv;
        }

        // LC035. Search Insert Position
        private int FindIndex(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == target)
                {
                    return mid;
                }
                if (arr[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}
