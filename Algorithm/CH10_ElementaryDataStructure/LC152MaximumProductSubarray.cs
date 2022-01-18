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

        public class DynamicProgramming
        {
            public int MaxProduct(int[] nums)
            {

                int[] max = new int[nums.Length];
                int[] min = new int[nums.Length];

                max[0] = nums[0];
                min[0] = nums[0];
                int ans = max[0];

                for (int i = 1; i < nums.Length; i++)
                {
                    max[i] = Math.Max(nums[i], Math.Max(max[i - 1] * nums[i], min[i - 1] * nums[i]));
                    min[i] = Math.Min(nums[i], Math.Min(max[i - 1] * nums[i], min[i - 1] * nums[i]));
                    ans = Math.Max(ans, max[i]);
                }

                return ans;
            }
        }

    }
}
