using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC362DesignHitCounter
    {
        public class HitCounter
        {

            private Queue<int> hits;

            public HitCounter()
            {
                hits = new Queue<int>();
            }

            public void Hit(int timestamp)
            {
                hits.Enqueue(timestamp);
            }

            public int GetHits(int timestamp)
            {
                while (hits.Count > 0 && timestamp - hits.Peek() >= 300)
                {
                    hits.Dequeue();
                }

                return hits.Count;
            }
        }
    }
}
