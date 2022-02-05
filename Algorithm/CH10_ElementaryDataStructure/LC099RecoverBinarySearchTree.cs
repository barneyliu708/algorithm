using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC099RecoverBinarySearchTree
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
        public void RecoverTree(TreeNode root)
        {

            if (root == null)
            {
                return;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode x = null;
            TreeNode y = null;

            TreeNode pre = null;
            TreeNode cur = root;
            while (stack.Count != 0 || cur != null)
            {
                // find out the leftmost child node of the current node
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();

                if (pre != null && cur.val < pre.val) // the two swapped node may not be adjacent  e.g. [1, 5, 3, 4, 2], need to keep looping until find out 5 and 2
                {
                    y = cur;
                    if (x == null)
                    {
                        x = pre;
                    }
                    else
                    {
                        break;
                    }
                }

                pre = cur;
                cur = cur.right;
            }

            int curVal = y.val;
            y.val = x.val;
            x.val = curVal;
        }
    }
}
