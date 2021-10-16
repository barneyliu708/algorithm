using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC169MajorityElement
    {
        public int MajorityElement(int[] nums)
        {
            return MajorityElement(nums, 0, nums.Length - 1);
        }

        private int MajorityElement(int[] nums, int left, int right)
        {

            if (left == right)
            {
                return nums[left];
            }

            int mid = (right - left) / 2 + left;
            int majority_left = MajorityElement(nums, left, mid);
            int majority_right = MajorityElement(nums, mid + 1, right);

            // conbine: if left and right majoriy elements are the same, it will be the same element after conbined
            if (majority_left == majority_right)
            {
                return majority_left;
            }

            // if left and right majoriy elements are different, the majority element will be one of them after conbined
            int count_left = CountTargetElement(nums, left, right, majority_left);
            int count_right = CountTargetElement(nums, left, right, majority_right);

            if (count_left > count_right)
            {
                return majority_left;
            }
            return majority_right;
        }

        private int CountTargetElement(int[] nums, int left, int right, int target)
        {
            int count = 0;
            for (int i = left; i <= right; i++)
            {
                if (nums[i] == target)
                {
                    count++;
                }
            }
            return count;
        }

        [Test]
        public void PositiveCaase1()
        {
            int[] nums1 = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var result = MajorityElement(nums1);
            Assert.AreEqual(2, result);
        }
    }
}
