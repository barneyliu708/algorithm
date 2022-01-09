using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC112PathSum
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
        public bool HasPathSum(TreeNode root, int targetSum)
        {

            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null) // this is a leaf, which has no children
            {
                return root.val == targetSum;
            }

            bool hasPathSum = false;
            if (root.left != null)
            {
                hasPathSum = hasPathSum || HasPathSum(root.left, targetSum - root.val);
            }

            if (root.right != null)
            {
                hasPathSum = hasPathSum || HasPathSum(root.right, targetSum - root.val);
            }

            return hasPathSum;
        }
    }
}
