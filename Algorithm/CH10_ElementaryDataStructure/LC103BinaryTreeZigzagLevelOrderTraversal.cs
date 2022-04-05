using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC103BinaryTreeZigzagLevelOrderTraversal
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
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }


            IList<IList<int>> ans = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;

            while (queue.Count != 0)
            {

                level++;
                int count = queue.Count;
                IList<int> levelValues = new List<int>();

                for (int i = 0; i < count; i++)
                {

                    TreeNode curNode = queue.Dequeue();
                    levelValues.Add(curNode.val);

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }
                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }

                if (level % 2 == 0)
                {
                    levelValues = levelValues.Reverse().ToList();
                }
                ans.Add(levelValues);
            }

            return ans;
        }

        public class SecondDone
        {
            public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
            {
                if (root == null)
                {
                    return new List<IList<int>>();
                }
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                IList<IList<int>> ans = new List<IList<int>>();
                int level = 0;
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    List<int> subAns = new List<int>();
                    for (int i = 0; i < count; i++)
                    {
                        TreeNode node = queue.Dequeue();
                        subAns.Add(node.val);
                        if (node.left != null)
                        {
                            queue.Enqueue(node.left);
                        }
                        if (node.right != null)
                        {
                            queue.Enqueue(node.right);
                        }
                    }
                    if (level % 2 == 1)
                    {
                        subAns.Reverse();
                    }
                    ans.Add(subAns);
                    level++;
                }
                return ans;
            }
        }

        public class SecondDone_QueueWithDelimiter
        {
            public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
            {
                if (root == null)
                {
                    return new List<IList<int>>();
                }
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                queue.Enqueue(null);
                IList<IList<int>> ans = new List<IList<int>>();
                List<int> subAns = new List<int>();
                bool isLeftDirection = true;
                while (queue.Count > 0)
                {
                    TreeNode node = queue.Dequeue();
                    if (node != null)
                    {
                        subAns.Add(node.val);
                        if (node.left != null)
                        {
                            queue.Enqueue(node.left);
                        }
                        if (node.right != null)
                        {
                            queue.Enqueue(node.right);
                        }
                    }
                    else
                    {
                        if (!isLeftDirection)
                        {
                            subAns.Reverse();
                        }
                        ans.Add(subAns);
                        subAns = new List<int>();
                        isLeftDirection = !isLeftDirection;
                        if (queue.Count > 0)
                        {
                            queue.Enqueue(null);
                        }
                    }
                }
                return ans;
            }
        }
    }
}
