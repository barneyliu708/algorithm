using Algorithm.CH6_SortingAndOrderStatistics.Ch6_2_MaintainingTheHeapProperty;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH6_SortingAndOrderStatistics.Ch6_5_PriorityQueue
{
    [TestFixture]
    public class Exercises
    {
        [Test]
        public void Excercise6_5_1()
        {
            int[] A = new int[] { 15, 13, 9, 5, 12, 8, 7, 4, 0, 6, 2, 1 };
            Heap heap = new Heap(A);
            Assert.AreEqual(15, heap.ExtractMax());
            Assert.AreEqual(13, heap.ExtractMax());
            Assert.AreEqual(12, heap.ExtractMax());
            Assert.AreEqual(9, heap.ExtractMax());
            Assert.AreEqual(8, heap.ExtractMax());
            Assert.AreEqual(7, heap.ExtractMax());
            Assert.AreEqual(6, heap.ExtractMax());
            Assert.AreEqual(5, heap.ExtractMax());
            Assert.AreEqual(4, heap.ExtractMax());
            Assert.AreEqual(2, heap.ExtractMax());
            Assert.AreEqual(1, heap.ExtractMax());
            Assert.AreEqual(0, heap.ExtractMax());
        }

        [Test]
        public void Excercise6_5_2()
        {
            int[] A = new int[] { 15, 13, 9, 5, 12, 8, 7, 4, 0, 6, 2, 1 };
            Heap heap = new Heap(A);
            heap.Insert(10);
            Assert.AreEqual(15, heap.ExtractMax());
            Assert.AreEqual(13, heap.ExtractMax());
            Assert.AreEqual(12, heap.ExtractMax());
            Assert.AreEqual(10, heap.ExtractMax());
            Assert.AreEqual(9, heap.ExtractMax());
            Assert.AreEqual(8, heap.ExtractMax());
            Assert.AreEqual(7, heap.ExtractMax());
            Assert.AreEqual(6, heap.ExtractMax());
            Assert.AreEqual(5, heap.ExtractMax());
            Assert.AreEqual(4, heap.ExtractMax());
            Assert.AreEqual(2, heap.ExtractMax());
            Assert.AreEqual(1, heap.ExtractMax());
            Assert.AreEqual(0, heap.ExtractMax());
        }
    }
}
