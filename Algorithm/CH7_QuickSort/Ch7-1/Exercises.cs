using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH7_QuickSort.Ch7_1
{
    [TestFixture]
    public class Exercises
    {
        [Test]
        public void Exercise7_1()
        {
            int[] A = { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
            QuickSort.Sort(A);
            Assert.AreEqual(2, A[0]);
            Assert.AreEqual(4, A[1]);
            Assert.AreEqual(5, A[2]);
            Assert.AreEqual(6, A[3]);
            Assert.AreEqual(7, A[4]);
            Assert.AreEqual(8, A[5]);
            Assert.AreEqual(9, A[6]);
            Assert.AreEqual(11, A[7]);
            Assert.AreEqual(12, A[8]);
            Assert.AreEqual(13, A[9]);
            Assert.AreEqual(19, A[10]);
            Assert.AreEqual(21, A[11]);
        }
    }
}
