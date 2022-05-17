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

        public class SecondDone
        {
            public class MedianFinder
            {

                private PriorityQueue<int, int> lo;
                private PriorityQueue<int, int> hi;
                public MedianFinder()
                {
                    lo = new PriorityQueue<int, int>(Comparer<int>.Create((int x, int y) => {
                        return y.CompareTo(x);
                    })); // max-heap
                    hi = new PriorityQueue<int, int>(); // min-heap
                }

                public void AddNum(int num)
                {
                    lo.Enqueue(num, num);

                    // rebalancing
                    hi.Enqueue(lo.Peek(), lo.Peek());
                    lo.Dequeue();

                    if (lo.Count < hi.Count)
                    {
                        lo.Enqueue(hi.Peek(), hi.Peek());
                        hi.Dequeue();
                    }
                }

                public double FindMedian()
                {
                    return lo.Count > hi.Count ? lo.Peek() : (double)(lo.Peek() + hi.Peek()) / 2;
                }
            }

        }
    }
}
