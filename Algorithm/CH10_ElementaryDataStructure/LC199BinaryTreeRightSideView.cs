using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC199BinaryTreeRightSideView
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
        public IList<int> RightSideView(TreeNode root)
        {

            if (root == null)
            {
                return new List<int>();
            }

            IList<int> ans = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {

                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode curNode = queue.Dequeue();

                    if (i == count - 1)
                    { // the rightmost node in current level
                        ans.Add(curNode.val);
                    }

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }
            }

            return ans;
        }
    }
}
