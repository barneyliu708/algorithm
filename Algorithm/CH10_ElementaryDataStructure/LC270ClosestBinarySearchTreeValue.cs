using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC270ClosestBinarySearchTreeValue
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
        public int ClosestValue(TreeNode root, double target)
        {

            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode cur = root;
            int ans = root.val;
            while (cur != null || stack.Count != 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();

                // do the comparision
                if (Math.Abs(ans - target) > Math.Abs(cur.val - target))
                {
                    ans = cur.val;
                }

                // navigate to the next
                cur = cur.right;
            }

            return ans;
        }

        public class SecondDone
        {
            public int ClosestValue(TreeNode root, double target)
            {
                int ans = root.val;
                double diff = int.MaxValue;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    TreeNode cur = stack.Pop();
                    if (Math.Abs(cur.val - target) < diff)
                    {
                        diff = Math.Abs(cur.val - target);
                        ans = cur.val;
                    }

                    if (cur.val == target)
                    {
                        return cur.val;
                    }

                    if (cur.val < target && cur.right != null)
                    {
                        stack.Push(cur.right);
                    }

                    if (cur.val > target && cur.left != null)
                    {
                        stack.Push(cur.left);
                    }
                }

                return ans;
            }
        }

        public class ThirdDone
        {
            public int ClosestValue(TreeNode root, double target)
            {

                if (root.val == target)
                {
                    return root.val;
                }

                double diff = Math.Abs(root.val - target);
                if (root.val > target && root.left != null)
                {
                    int leftAns = ClosestValue(root.left, target);
                    if (diff > Math.Abs(leftAns - target))
                    {
                        return leftAns;
                    }
                    return root.val;
                }
                if (root.val < target && root.right != null)
                {
                    int rightAns = ClosestValue(root.right, target);
                    if (diff > Math.Abs(rightAns - target))
                    {
                        return rightAns;
                    }
                    return root.val;
                }

                return root.val;
            }
        }
    }
}
