using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC285InorderSuccessorInBST
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
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {

            TreeNode cur;
            TreeNode pre;

            if (p.right != null)
            { // if p has right substree, its successor should be the leftmost node in p's right substree
                cur = p.right;
                while (cur.left != null)
                {
                    cur = cur.left;
                }
                return cur;
            }

            cur = root;
            pre = null;
            while (cur.val != p.val)
            {
                if (cur.val < p.val)
                {
                    cur = cur.right;
                }
                else
                {
                    pre = cur; // only when the p is the left child of its parent node, p has the successor
                    cur = cur.left;
                }
            }

            return pre;
        }

        public class SecondDone
        {
            public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
            {

                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode cur = root;
                bool pfound = false;
                TreeNode ans;
                while (cur != null || stack.Count > 0)
                {
                    while (cur != null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }

                    cur = stack.Pop();
                    if (pfound)
                    {
                        return cur;
                    }
                    if (cur == p)
                    {
                        pfound = true;
                    }

                    cur = cur.right;
                }

                return null;
            }
        }
    }
}
