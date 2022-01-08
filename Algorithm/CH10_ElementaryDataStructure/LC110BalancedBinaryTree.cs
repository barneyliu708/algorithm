using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC110BalancedBinaryTree
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
        public bool IsBalanced(TreeNode root)
        {
            int height = 0;
            return IsBalanced(root, ref height);
        }

        // we would like to maintain both height and isBalanced at each node
        // so we use ref argument to return the height while return isBalanced while traversal
        private bool IsBalanced(TreeNode root, ref int height)
        {

            height = 0;
            if (root == null)
            {

                return true;
            }

            int heightLeft = 0;
            int heightRight = 0;
            bool isBalancedLeft = IsBalanced(root.left, ref heightLeft);
            bool isBalancedRight = IsBalanced(root.right, ref heightRight);

            height = Math.Max(heightLeft, heightRight) + 1;

            if (!isBalancedLeft || !isBalancedRight)
            {

                return false;
            }

            return Math.Abs(heightLeft - heightRight) < 2;
        }
    }
}
