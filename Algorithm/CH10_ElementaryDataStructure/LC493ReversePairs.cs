using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC493ReversePairs
    {
        public class DivideAndConquer
        {
            public int ReversePairs(int[] nums)
            {
                return Divide(nums, 0, nums.Length - 1);
            }

            private int Divide(int[] nums, int l, int r)
            {
                if (l >= r)
                {
                    return 0;
                }

                int mid = l + (r - l) / 2;
                int ans = Divide(nums, l, mid) + Divide(nums, mid + 1, r);

                // count reverse pairs that i from the left subarray while the j is from the right subarray
                int i = mid;
                int j = r;
                while (i >= l)
                {
                    while (j >= mid + 1 && nums[i] <= (long)2 * nums[j])
                    {
                        j--;
                    }
                    ans += j - (mid + 1) + 1;
                    i--;
                }

                Merge(nums, l, mid, r);

                return ans;
            }

            private void Merge(int[] nums, int l, int mid, int r)
            {
                // merge two sorted subarray to one big sorted subarray
                List<int> list = new List<int>();
                int i = l;
                int j = mid + 1;
                while (i <= mid && j <= r)
                {
                    if (nums[i] < nums[j])
                    {
                        list.Add(nums[i]);
                        i++;
                    }
                    else
                    {
                        list.Add(nums[j]);
                        j++;
                    }
                }
                while (i <= mid)
                {
                    list.Add(nums[i]);
                    i++;
                }
                while (j <= r)
                {
                    list.Add(nums[j]);
                    j++;
                }

                for (int k = 0; k < list.Count; k++)
                {
                    nums[l + k] = list[k];
                }
            }
        }
    }
}
