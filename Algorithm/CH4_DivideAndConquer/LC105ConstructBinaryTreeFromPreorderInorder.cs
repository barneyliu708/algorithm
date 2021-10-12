using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC105ConstructBinaryTreeFromPreorderInorder
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

        private static int preIndex = 0;
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            preIndex = 0;
            return BuildTree(preorder, inorder, 0, inorder.Length - 1);
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder, int inStart, int inEnd)
        {

            if (inStart > inEnd)
            {
                return null;
            }

            var newNode = new TreeNode(preorder[preIndex++]);

            if (inStart == inEnd)
            {
                return newNode;
            }

            int inIndex = Search(inorder, inStart, inEnd, newNode.val);
            TreeNode leftNode = BuildTree(preorder, inorder, inStart, inIndex - 1);
            TreeNode rightNode = BuildTree(preorder, inorder, inIndex + 1, inEnd);

            newNode.left = leftNode;
            newNode.right = rightNode;

            return newNode;
        }

        private int Search(int[] arr, int start, int end, int target)
        {

            for (int i = start; i <= end; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        [Test]
        public void PositiveCaase1()
        {
            int[] pre = new int[] { 3, 9, 20, 15, 7 };
            int[] ino = new int[] { 9, 3, 15, 20, 7 };
            int len = ino.Length;
            TreeNode root = BuildTree(pre, ino, 0, len - 1);
        }
        [Test]
        public void PositiveCaase2()
        {
            int[] pre = new int[] { -1 };
            int[] ino = new int[] { -1 };
            int len = ino.Length;
            TreeNode root = BuildTree(pre, ino, 0, len - 1);
        }
    }
}
