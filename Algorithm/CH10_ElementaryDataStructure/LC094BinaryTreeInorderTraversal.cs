using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC094BinaryTreeInorderTraversal
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

        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                result.Add(current.val);
                current = current.right;
            }

            return result;
        }

        public class SecondDone
        {
            public IList<int> InorderTraversal(TreeNode root)
            {
                List<int> ans = new List<int>();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode cur = root;
                while (cur != null || stack.Count > 0)
                {
                    while (cur != null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }

                    // get current node from stack
                    cur = stack.Pop();
                    ans.Add(cur.val);

                    // traversal the right node, the left node has been visited
                    cur = cur.right;
                }

                return ans;
            }
        }

        public class ThirdDone
        {
            public IList<int> InorderTraversal(TreeNode root)
            {
                List<int> ans = new List<int>();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                while (stack.Count > 0)
                {
                    TreeNode cur = stack.Pop();
                    ans.Add(cur.val);

                    cur = cur.right;
                    while (cur != null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }
                }

                return ans;
            }
        }
    }
}
