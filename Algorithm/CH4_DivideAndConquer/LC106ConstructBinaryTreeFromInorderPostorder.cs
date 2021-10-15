using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC106ConstructBinaryTreeFromInorderPostorder
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

        private static int postIndex = 0;
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            postIndex = postorder.Length - 1;
            return BuildTree(inorder, postorder, 0, inorder.Length - 1);
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder, int inStart, int inEnd)
        {

            if (inStart > inEnd)
            {
                return null;
            }

            var newNode = new TreeNode(postorder[postIndex--]);

            if (inStart == inEnd)
            {
                return newNode;
            }

            int inIndex = Search(inorder, inStart, inEnd, newNode.val);
            
            // need to build right first, then left, because the postIndex starts from right of the postOrder array and will loop through the right child first
            TreeNode rightNode = BuildTree(inorder, postorder, inIndex + 1, inEnd);
            TreeNode leftNode = BuildTree(inorder, postorder, inStart, inIndex - 1);

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
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };
            int[] postorder = new int[] { 9, 15, 7, 20, 3 };
            int len = inorder.Length;
            TreeNode root = BuildTree(inorder, postorder);
        }
    }
}
