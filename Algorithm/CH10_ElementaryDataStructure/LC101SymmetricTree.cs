using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC101SymmetricTree
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
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode p, TreeNode q)
        {

            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSymmetric(p.left, q.right) &&
                   IsSymmetric(p.right, q.left);
        }
    }
}
