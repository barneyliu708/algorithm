using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConquer.Ch4_1_MaximumSubarrayEmpty_LinearTime
{
    [TestFixture]
    public class Executor
    {
        // 4.1-4
        // Find maximum subarray but allow return empty array
        public Tuple<int, int, int> FindMaximumSubarrayAllow_LinearTime(int[] A)
        {
            int global_max_sum = int.MinValue;
            int local_max_sum = 0;
            int max_left = -1;
            int max_right = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (local_max_sum < 0)
                {
                    local_max_sum = 0;
                    max_left = i;
                }
                local_max_sum += A[i];
                if (global_max_sum < local_max_sum)
                {
                    global_max_sum = local_max_sum;
                    max_right = i;
                }
            }
            if (max_left == A.Length - 1)
            {
                max_left = max_right;
            }
            return new Tuple<int, int, int>(max_left, max_right, global_max_sum);
        }

      
        [Test]
        public void Positive_Case()
        {
            int[] A = new int[] { 13, -3, -25, 20, -3, -6, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            var result = FindMaximumSubarrayAllow_LinearTime(A);

            Assert.AreEqual(7, result.Item1);
            Assert.AreEqual(10, result.Item2);
            Assert.AreEqual(43, result.Item3);
        }

        [Test]
        [Description("4.1-4 when all elements of A are neagtive")]
        public void AllNegativeElements()
        {
            int[] A = new int[] { -13, -3, -25, -20, -3, -6, -23, -18, -20, -1, -12, -5, -22, -15, -4, -7 };
            var result = FindMaximumSubarrayAllow_LinearTime(A);

            // will return only one element with the maxinum value
            Assert.AreEqual(9, result.Item1);
            Assert.AreEqual(9, result.Item2);
            Assert.AreEqual(-1, result.Item3);
        }
    }
}
