using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure.Ch10_1_StacksAndQueues
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
    }
}
