using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH6_SortingAndOrderStatistics.Ch6_2_MaintainingTheHeapProperty
{
    public class Heap
    {
        public void MaxHeapify(int[] A, int i)
        {
            int maxIndex = i;
            int rightIndex = RightChildIndex(i);
            int leftIndex = LeftChildIndex(i);
            if (leftIndex < A.Length && A[leftIndex] > A[i])
            {
                maxIndex = leftIndex;
            }
            if (rightIndex < A.Length && A[rightIndex] > A[maxIndex])
            {
                maxIndex = rightIndex;
            }

            if (i != maxIndex)
            {
                int temp = A[i];
                A[i] = A[maxIndex];
                A[maxIndex] = temp;

                MaxHeapify(A, maxIndex);
            }
        }

        public int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }

        public int LeftChildIndex(int i)
        {
            return i * 2 + 1;
        }

        public int RightChildIndex(int i)
        {
            return i * 2 + 2;
        }
    }
}
