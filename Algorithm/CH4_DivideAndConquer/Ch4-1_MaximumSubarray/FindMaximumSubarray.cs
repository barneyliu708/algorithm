using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConquer.Ch4_1_MaximumSubarray
{
    [TestFixture]
    public class Ch4_1_MaximumSubarray
    {
        public Tuple<int, int, int> FindMaximumSubarray(int[] A, int low, int high)
        {
            if (low == high)
            {
                return new Tuple<int, int, int>(low, high, A[low]);
            }

            int mid = (low + high) / 2;
            var leftSubarray = FindMaximumSubarray(A, low, mid);
            var rightSubarray = FindMaximumSubarray(A, mid + 1, high);
            var crossSubarray = FindMaxCrossingSubarray(A, low, mid, high);
            
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

        public Tuple<int, int, int> FindMaxCrossingSubarray(int[] A, int low, int mid, int high)
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
            var result = FindMaximumSubarray(A, 0, A.Length - 1);

            Assert.AreEqual(7, result.Item1);
            Assert.AreEqual(10, result.Item2);
            Assert.AreEqual(43, result.Item3);
        }

        [Test]
        [Description("4.1-1 when all elements of A are neagtive")]
        public void AllNegativeElements()
        {
            int[] A = new int[] { -13, -3, -25, -20, -3, -6, -23, -18, -20, -1, -12, -5, -22, -15, -4, -7 };
            var result = FindMaximumSubarray(A, 0, A.Length - 1);

            // will return only one element with the maxinum value
            Assert.AreEqual(9, result.Item1);
            Assert.AreEqual(9, result.Item2);
            Assert.AreEqual(-1, result.Item3);
        }
    }
}
