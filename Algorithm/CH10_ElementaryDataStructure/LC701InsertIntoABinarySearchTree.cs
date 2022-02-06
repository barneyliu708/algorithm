using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC701InsertIntoABinarySearchTree
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

        public TreeNode InsertIntoBST(TreeNode root, int val)
        {

            if (root == null)
            {
                return new TreeNode(val);
            }

            if (val > root.val)
            {
                root.right = InsertIntoBST(root.right, val);
            }
            else
            {
                root.left = InsertIntoBST(root.left, val);
            }

            return root;
        }
    }
}
