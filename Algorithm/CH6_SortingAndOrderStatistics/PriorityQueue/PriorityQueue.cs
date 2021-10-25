using Algorithm.CH6_SortingAndOrderStatistics.Ch6_2_MaintainingTheHeapProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH6_SortingAndOrderStatistics.PriorityQueue
{
    public class PriorityQueue
    {
        private Heap A;

        public PriorityQueue(int size)
        {
            A = new Heap(size);
        }

        public int Maximum()
        {
            return A[1];
        }

       

    }
}
