using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC145BinaryTreePostorderTraversal
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
        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }
            IList<int> results = new List<int>();
            TreeNode head = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Peek();
                if ((node.left == null && node.right == null) || node.left == head || node.right == head)
                {
                    results.Add(node.val);
                    stack.Pop();
                    head = node;
                }
                else
                {
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
            }
            return results;
        }
    }
}
