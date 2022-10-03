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

        public class SecondDone_TwoStacks
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {

                Stack<TreeNode> stack1 = new Stack<TreeNode>();
                Stack<TreeNode> stack2 = new Stack<TreeNode>();
                stack1.Push(root);

                while (stack1.Count > 0)
                {
                    TreeNode cur = stack1.Pop();
                    stack2.Push(cur);

                    if (cur.left != null)
                    {
                        stack1.Push(cur.left);
                    }
                    if (cur.right != null)
                    {
                        stack1.Push(cur.right);
                    }
                }

                List<int> ans = new List<int>();
                while (stack2.Count > 0)
                {
                    ans.Add(stack2.Pop().val);
                }

                return ans;
            }
        }

        public class SecondDone_OneStack
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                if (root == null)
                {
                    return new List<int>();
                }

                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode head = root;
                stack.Push(root);

                List<int> ans = new List<int>();
                while (stack.Count > 0)
                {
                    TreeNode node = stack.Peek();
                    if ((node.left == null && node.right == null) ||
                        node.left == head || node.right == head)
                    {

                        ans.Add(node.val);
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

                return ans;
            }
        }

        public class ThirdDone
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                List<int> ans = new List<int>();
                if (root == null)
                {
                    return ans;
                }
                TreeNode pre = null;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    TreeNode cur = stack.Pop();
                    if (pre != null && (pre == cur.left || pre == cur.right || pre == cur))
                    {
                        ans.Add(cur.val);
                    }
                    else
                    {
                        stack.Push(cur);
                        if (cur.right != null)
                        {
                            stack.Push(cur.right);
                        }
                        if (cur.left != null)
                        {
                            stack.Push(cur.left);
                        }
                    }
                    pre = cur;
                }

                return ans;
            }
        }

        public class ThirdDone_v2
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                List<int> ans = new List<int>();
                if (root == null)
                {
                    return ans;
                }
                TreeNode pre = root; // instead of null
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    TreeNode cur = stack.Pop();
                    if ((cur.left == null && cur.right == null) || pre == cur.left || pre == cur.right)
                    {
                        ans.Add(cur.val);
                    }
                    else
                    {
                        stack.Push(cur);
                        if (cur.right != null)
                        {
                            stack.Push(cur.right);
                        }
                        if (cur.left != null)
                        {
                            stack.Push(cur.left);
                        }
                    }
                    pre = cur;
                }

                return ans;
            }
        }

        public class ForthDone
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                List<int> ans = new List<int>();
                if (root == null)
                {
                    return ans;
                }
                TreeNode cur = root;
                TreeNode pre = null;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (cur != null || stack.Count > 0)
                {
                    while (cur != null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }

                    root = stack.Peek();
                    if (root.right == null || root.right == pre)
                    {
                        cur = null;
                        pre = stack.Pop();
                        ans.Add(root.val);
                    }
                    else if (root.right != null)
                    {
                        cur = root.right;
                    }
                    else
                    {
                        pre = stack.Pop();
                        ans.Add(root.val);
                        cur = root.right;
                    }
                }

                return ans;
            }
        }
    }
}
