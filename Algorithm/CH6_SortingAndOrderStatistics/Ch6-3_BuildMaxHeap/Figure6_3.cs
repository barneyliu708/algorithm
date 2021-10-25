using Algorithm.CH6_SortingAndOrderStatistics.Ch6_2_MaintainingTheHeapProperty;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH6_SortingAndOrderStatistics.Ch6_3_BuildMaxHeap
{
    [TestFixture]
    public class Figure6_3
    {
        [Test]
        public void Figure6_3_BuildMaxHeapExample()
        {
            int[] A = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
            Heap heap = new Heap();

            heap.BuildMaxHeap(A);
            Assert.AreEqual(16, A[0]);
            Assert.AreEqual(14, A[1]);
            Assert.AreEqual(10, A[2]);
            Assert.AreEqual(8, A[3]);
            Assert.AreEqual(7, A[4]);
            Assert.AreEqual(9, A[5]);
            Assert.AreEqual(3, A[6]);
            Assert.AreEqual(2, A[7]);
            Assert.AreEqual(4, A[8]);
            Assert.AreEqual(1, A[9]);
        }
    }
}
