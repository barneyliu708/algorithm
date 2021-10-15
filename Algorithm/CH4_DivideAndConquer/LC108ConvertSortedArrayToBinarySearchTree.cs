using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC108ConvertSortedArrayToBinarySearchTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public TreeNode SortedArrayToBST(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        public TreeNode SortedArrayToBST(int[] nums, int start_index, int end_index)
        {

            if (start_index > end_index)
            {
                return null;
            }

            if (start_index == end_index)
            {
                return new TreeNode(nums[start_index]);
            }

            int mid_index = (start_index + end_index) / 2;
            TreeNode parent = new TreeNode(nums[mid_index]);

            parent.left = SortedArrayToBST(nums, start_index, mid_index - 1);
            parent.right = SortedArrayToBST(nums, mid_index + 1, end_index);

            return parent;
        }

        [Test]
        public void PositiveCaase1()
        {
            int[] nums = new int[] { -10, -3, 0, 5, 9 };
            TreeNode root = SortedArrayToBST(nums);
        }
    }
}
