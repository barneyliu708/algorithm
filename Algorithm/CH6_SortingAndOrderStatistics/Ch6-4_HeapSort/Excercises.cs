using Algorithm.CH6_SortingAndOrderStatistics.Ch6_2_MaintainingTheHeapProperty;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH6_SortingAndOrderStatistics.Ch6_4_HeapSort
{
    [TestFixture]
    public class Excercises
    {
        [Test]
        public void Ex6_1_HeapSort()
        {
            int[] A = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
            Heap heap = new Heap();
            heap.HeapSort(A);
            Assert.AreEqual(1, A[0]);
            Assert.AreEqual(2, A[1]);
            Assert.AreEqual(3, A[2]);
            Assert.AreEqual(4, A[3]);
            Assert.AreEqual(7, A[4]);
            Assert.AreEqual(8, A[5]);
            Assert.AreEqual(9, A[6]);
            Assert.AreEqual(10, A[7]);
            Assert.AreEqual(14, A[8]);
            Assert.AreEqual(16, A[9]);
        }
    }
}
