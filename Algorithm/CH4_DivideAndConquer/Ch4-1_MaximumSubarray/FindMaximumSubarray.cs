using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConquer.Ch4_1_MaximumSubarray
{
    [TestFixture]
    public class Executor
    {
        public Tuple<int, int, int> FindMaximumSubarray(int[] A, int low, int high)
        {
            return new Tuple<int, int, int>(0, 0, 0);
        }

        [Test]
        public void Execute()
        {
            int[] A = new int[] { 13, -3, -25, 20, -3, -6, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            var result = FindMaximumSubarray(A, 0, A.Length - 1);
        }
    }
}
