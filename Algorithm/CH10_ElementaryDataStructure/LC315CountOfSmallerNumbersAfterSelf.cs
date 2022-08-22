using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC315CountOfSmallerNumbersAfterSelf
    {
        public IList<int> CountSmaller(int[] nums)
        {
            int n = nums.Length;
            int[] results = new int[n];
            int[] indices = new int[n];
            for (int i = 0; i < n; i++)
            {
                indices[i] = i;
            }
            MergeSort(nums, indices, 0, n - 1, results);
            // Console.WriteLine(string.Join(", ", indices));

            return results.ToList();
        }

        private void MergeSort(int[] nums, int[] indices, int l, int r, int[] results)
        {
            if (l >= r)
            {
                return;
            }

            int mid = l + (r - l) / 2;
            MergeSort(nums, indices, l, mid, results);
            MergeSort(nums, indices, mid + 1, r, results);

            Merge(nums, indices, l, mid, r, results);
        }

        private void Merge(int[] nums, int[] indices, int l, int mid, int r, int[] results)
        {
            int i = l;
            int j = mid + 1;
            List<int> temp = new List<int>();
            while (i <= mid && j <= r)
            {
                if (nums[indices[i]] <= nums[indices[j]])
                { // must include the equal as well
                    results[indices[i]] += j - mid - 1;
                    temp.Add(indices[i]);
                    i++;
                }
                else
                {
                    temp.Add(indices[j]);
                    j++;
                }
            }

            while (i <= mid)
            {
                results[indices[i]] += j - mid - 1;
                temp.Add(indices[i]);
                i++;
            }

            while (j <= r)
            {
                temp.Add(indices[j]);
                j++;
            }

            for (int k = l; k <= r; k++)
            {
                indices[k] = temp[k - l];
            }
        }
    }
}
