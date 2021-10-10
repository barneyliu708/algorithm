using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConquer.Ch4_1_MaximumSubarray
{
    [TestFixture]
    public class Ch4_1_MaximumSubarrayEmpty
    {
        // 4.1-4
        // Find maximum subarray but allow return empty array
        public Tuple<int, int, int> FindMaximumSubarrayAllowEmpty(int[] A)
        {
            // scan throgh array, if there is any positive element, run as ususal, otherwise return empty array
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    return FindMaximumSubarrayAllowEmpty(A, 0, A.Length - 1);
                }
            }
            return new Tuple<int, int, int>(-1, -1, 0);
        }
        public Tuple<int, int, int> FindMaximumSubarrayAllowEmpty(int[] A, int low, int high)
        {
            if (low == high)
            {
                return new Tuple<int, int, int>(low, high, A[low]);
            }

            int mid = (low + high) / 2;
            var leftSubarray = FindMaximumSubarrayAllowEmpty(A, low, mid);
            var rightSubarray = FindMaximumSubarrayAllowEmpty(A, mid + 1, high);
            var crossSubarray = FindMaxCrossingSubarrayAllowEmpty(A, low, mid, high);
            
            if (leftSubarray.Item3 >= rightSubarray.Item3 && leftSubarray.Item3 >= crossSubarray.Item3)
            {
                return leftSubarray;
            }
            else if (rightSubarray.Item3 >= leftSubarray.Item3 && rightSubarray.Item3 >= crossSubarray.Item3)
            {
                return rightSubarray;
            }
            return crossSubarray;
        }

        public Tuple<int, int, int> FindMaxCrossingSubarrayAllowEmpty(int[] A, int low, int mid, int high)
        {
            int localSum = 0;
            int leftSum = int.MinValue;
            int max_left = mid;
            for(int i = mid; i >= low; i--)
            {
                localSum += A[i];
                if (localSum > leftSum)
                {
                    leftSum = localSum;
                    max_left = i;
                }
            }

            localSum = 0;
            int rightSum = int.MinValue;
            int max_right = mid + 1;
            for(int i = mid + 1; i <= high; i++)
            {
                localSum += A[i];
                if (localSum > rightSum)
                {
                    rightSum = localSum;
                    max_right = i;
                }
            }

            return new Tuple<int, int, int>(max_left, max_right, leftSum + rightSum);
        }

        [Test]
        public void Execute()
        {
            int[] A = new int[] { 13, -3, -25, 20, -3, -6, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
            var result = FindMaximumSubarrayAllowEmpty(A);

            Assert.AreEqual(7, result.Item1);
            Assert.AreEqual(10, result.Item2);
            Assert.AreEqual(43, result.Item3);
        }

        [Test]
        [Description("4.1-4 when all elements of A are neagtive")]
        public void AllNegativeElements()
        {
            int[] A = new int[] { -13, -3, -25, -20, -3, -6, -23, -18, -20, -1, -12, -5, -22, -15, -4, -7 };
            var result = FindMaximumSubarrayAllowEmpty(A);

            // will return only one element with the maxinum value
            Assert.AreEqual(-1, result.Item1);
            Assert.AreEqual(-1, result.Item2);
            Assert.AreEqual(0, result.Item3);
        }
    }
}
