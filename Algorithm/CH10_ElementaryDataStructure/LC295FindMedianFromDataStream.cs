using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC295FindMedianFromDataStream
    {
        public class MedianFinder
        {

            private PriorityQueue<int, int> maxheap;
            private PriorityQueue<int, int> minheap;

            public MedianFinder()
            {
                maxheap = new PriorityQueue<int, int>();
                minheap = new PriorityQueue<int, int>();
            }

            public void AddNum(int num)
            {
                maxheap.Enqueue(num, -num);

                // rebalancing
                minheap.Enqueue(maxheap.Peek(), maxheap.Peek());
                maxheap.Dequeue();

                if (maxheap.Count < minheap.Count)
                {
                    maxheap.Enqueue(minheap.Peek(), -minheap.Peek());
                    minheap.Dequeue();
                }
            }

            public double FindMedian()
            {
                return maxheap.Count > minheap.Count ? maxheap.Peek() : ((double)maxheap.Peek() + (double)minheap.Peek()) / 2;
            }
        }
    }
}
