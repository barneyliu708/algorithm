using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC152MaximumProductSubarray
    {
        [TestFixture]
        public class BruteForceWithMemoization
        {
            public int MaxProduct(int[] nums)
            {

                int[,] dp = new int[nums.Length, nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        dp[i, j] = 1;
                    }
                }

                int maxProduct = int.MinValue;
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i; j < nums.Length; j++)
                    {
                        if (j == 0)
                        {
                            dp[i, j] = nums[0];
                        }
                        else
                        {
                            dp[i, j] = dp[i, j - 1] * nums[j];
                        }
                        maxProduct = Math.Max(maxProduct, dp[i, j]);
                    }
                }

                return maxProduct;
            }

            [Test]
            public void TestCase1()
            {
                int[] nums = new int[] { 2, 3, -2, 4 };
                Assert.AreEqual(6, MaxProduct(nums));
            }

            [Test]
            public void TestCase2()
            {
                int[] nums = new int[] { -2, 0, -1 };
                Assert.AreEqual(0, MaxProduct(nums));
            }
        }

    }
}
