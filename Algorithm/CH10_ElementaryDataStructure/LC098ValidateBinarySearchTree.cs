using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC098ValidateBinarySearchTree
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
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBSTUti(root, null, null);
        }

        private bool IsValidBSTUti(TreeNode curNode, TreeNode lower, TreeNode upper)
        {

            if (curNode == null)
            {
                return true;
            }

            if (lower != null && curNode.val <= lower.val ||
                upper != null && curNode.val >= upper.val)
            {
                return false;
            }

            return IsValidBSTUti(curNode.left, lower, curNode) &&
                   IsValidBSTUti(curNode.right, curNode, upper);
        }
    }
}
