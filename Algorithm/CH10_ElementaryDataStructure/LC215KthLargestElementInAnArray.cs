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
    }
}
