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
    }
}
