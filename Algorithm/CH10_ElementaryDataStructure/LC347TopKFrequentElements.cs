using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC347TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {

            Dictionary<int, int> map = new Dictionary<int, int>(); // num - count;
            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                {
                    map[num] = 0;
                }
                map[num]++;
            }

            PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
            foreach (var kv in map)
            {
                heap.Enqueue(kv.Key, kv.Value);
                if (heap.Count > k)
                {
                    heap.Dequeue(); // dequeue the element with the mininal count
                }
            }

            int[] ans = new int[k];
            for (int i = k - 1; i >= 0; i--)
            {
                ans[i] = heap.Dequeue();
            }

            return ans;
        }
    }
}
