using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC114FlatternBinaryTreeToLinkedList
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
        public void Flatten(TreeNode root)
        {
            FlatternUti(root);
        }

        private TreeNode FlatternUti(TreeNode root)
        {

            if (root == null)
            {
                return null;
            }

            if (root.left == null && root.right == null)
            {
                return root;
            }

            TreeNode leftTail = FlatternUti(root.left);
            TreeNode rightTail = FlatternUti(root.right);

            if (leftTail != null)
            {
                leftTail.right = root.right;
                root.right = root.left;
                root.left = null;
            }

            return rightTail == null ? leftTail : rightTail;
        }
    }
}
