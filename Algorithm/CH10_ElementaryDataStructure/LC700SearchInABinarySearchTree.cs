using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC700SearchInABinarySearchTree
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

        public TreeNode SearchBST(TreeNode root, int val)
        {

            TreeNode cur = root;
            while (cur != null)
            {
                if (val > cur.val)
                {
                    cur = cur.right;
                }
                else if (val < cur.val)
                {
                    cur = cur.left;
                }
                else
                {
                    return cur;
                }
            }
            return null;
        }
    }
}
