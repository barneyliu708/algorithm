using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC144BinaryTreePreorderTraversal
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
        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> results = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode p = root;
            while (stack.Count != 0 || p != null)
            {
                if (p != null)
                {
                    stack.Push(p);
                    results.Add(p.val);
                    p = p.left;
                }
                else
                {
                    p = stack.Pop();
                    p = p.right;
                }
            }
            return results;
        }
    }
}
