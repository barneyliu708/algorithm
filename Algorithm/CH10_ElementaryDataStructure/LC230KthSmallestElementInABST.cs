using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC230KthSmallestElementInABST
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

        public int KthSmallest(TreeNode root, int k)
        {

            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);
            TreeNode cur = root;

            while (cur != null || stack.Count != 0)
            {

                // navigatet to the leftmost child of the current node
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                if (--k == 0)
                {
                    return cur.val;
                }
                cur = cur.right;
            }

            throw new Exception("Invalid k!");
        }

        public class SecondDone
        {
            public int KthSmallest(TreeNode root, int k)
            {

                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode cur = root;
                while (cur != null || stack.Count > 0)
                {
                    while (cur != null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }

                    cur = stack.Pop();
                    k--;
                    if (k == 0)
                    {
                        return cur.val;
                    }

                    cur = cur.right;
                }

                throw new Exception("Invalid K");
            }
        }
    }
}
