using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC215KthLargestElementInAnArray
    {
        public int FindKthLargest(int[] nums, int k)
        {

            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(); // element - priority

            for (int i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i], nums[i]);
                if (queue.Count > k)
                {
                    queue.Dequeue();
                }
            }

            return queue.Dequeue();
        }

        public class QuickSelectApproach
        {
            public int FindKthLargest(int[] nums, int k)
            {
                return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
            }

            private void Swap(int[] nums, int l, int r)
            {
                int temp = nums[l];
                nums[l] = nums[r];
                nums[r] = temp;
            }

            private int Partition(int[] nums, int l, int r, int pi)
            {
                int pivot = nums[pi];

                // move pivot to the end
                Swap(nums, pi, r);

                // move all smaller elements to the left
                int inserti = l;
                for (int i = l; i <= r; i++)
                {
                    if (nums[i] < pivot)
                    {
                        Swap(nums, inserti, i);
                        inserti++;
                    }
                }

                // move pivot to its final place
                Swap(nums, inserti, r);

                return inserti;
            }

            private int QuickSelect(int[] nums, int l, int r, int kSmallest)
            {
                if (l == r)
                {
                    return nums[l];
                }

                Random rand = new Random();
                int pi = l + rand.Next(r - l);
                pi = Partition(nums, l, r, pi);

                if (kSmallest == pi)
                {
                    return nums[kSmallest];
                }
                if (kSmallest < pi)
                {
                    return QuickSelect(nums, l, pi - 1, kSmallest);
                }
                return QuickSelect(nums, pi + 1, r, kSmallest);
            }
        }

        public class QuickSelectApproach2ndDone // with different pick-pivot approach
        {
            public int FindKthLargest(int[] nums, int k)
            {
                return FindKthLargest(nums, 0, nums.Length - 1, k);
            }

            // pick the right most element as the pivot
            // return the indice of the pivot element after sorted
            private int Partition(int[] nums, int l, int r)
            {
                int pivot = nums[r];
                int p = l;
                for (int i = l; i <= r; i++)
                {
                    if (nums[i] > pivot)
                    {
                        Swap(nums, p, i);
                        p++;
                    }
                }
                Swap(nums, p, r);
                return p;
            }

            // return the value of the kth largest element
            private int FindKthLargest(int[] nums, int l, int r, int k)
            {
                if (l == r)
                {
                    return nums[r];
                }

                int p = Partition(nums, l, r);
                if (p + 1 == k) // p is 0-based index
                {
                    return nums[p];
                }
                if (p + 1 < k)
                {
                    return FindKthLargest(nums, p + 1, r, k);
                }
                return FindKthLargest(nums, l, p - 1, k);
            }

            private void Swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
