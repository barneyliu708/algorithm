using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC004MedianOfTwoSortedArraycs
    {
        /// <summary>
        /// https://leetcode.com/problems/median-of-two-sorted-arrays/
        /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        /// The overall run time complexity should be O(log (m+n)).
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            int mn = nums1.Length + nums2.Length;
            if (mn % 2 == 0)
            {
                double first = FindKthSortedArray(nums1, 0, nums2, 0, mn / 2 - 1);
                double second = FindKthSortedArray(nums1, 0, nums2, 0, mn / 2);
                return (first + second) / 2.0;
            }
            return FindKthSortedArray(nums1, 0, nums2, 0, mn / 2);
        }

        public double FindKthSortedArray(int[] nums1, int i, int[] nums2, int j, int kth)
        {

            if (i >= nums1.Length)
            {
                return nums2[j + kth];
            }
            else if (j >= nums2.Length)
            {
                return nums1[i + kth];
            }
            else if (kth == 0)
            {
                return Math.Min(nums1[i], nums2[j]);
            }

            int mid1 = Math.Min(nums1.Length - i, (kth + 1) / 2);
            int mid2 = Math.Min(nums2.Length - j, (kth + 1) / 2);
            int a = nums1[i + mid1 - 1];
            int b = nums2[j + mid2 - 1];

            if (a < b)
            {
                return FindKthSortedArray(nums1, i + mid1, nums2, j, kth - mid1);
            }
            return FindKthSortedArray(nums1, i, nums2, j + mid2, kth - mid2);
        }
        [Test]
        public void PositiveCaase1()
        {
            int[] nums1 = new int[] { 2, 2, 4, 4 };
            int[] nums2 = new int[] { 2, 2, 4, 4 };
            var result = FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void PositiveCaase2()
        {
            int[] nums1 = new int[] { 1, 3 };
            int[] nums2 = new int[] { 2 };
            var result = FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(2, result);
        }
    }
}
