using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC102BinaryTreeLevelOrderTraversal
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
        public IList<IList<int>> LevelOrder(TreeNode root)
        {

            if (root == null)
            {
                return new List<IList<int>>();
            }


            IList<IList<int>> ans = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {

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

                ans.Add(levelValues);
            }

            return ans;
        }

        public class RecursionApproach
        {
            public IList<IList<int>> LevelOrder(TreeNode root)
            {
                IList<IList<int>> ans = new List<IList<int>>();
                LevelOrder(root, 0, ans);
                return ans;
            }

            private void LevelOrder(TreeNode root, int level, IList<IList<int>> ans)
            {
                if (root == null)
                {
                    return;
                }
                if (level == ans.Count)
                {
                    ans.Add(new List<int>());
                }
                ans[level].Add(root.val);
                LevelOrder(root.left, level + 1, ans);
                LevelOrder(root.right, level + 1, ans);
            }
        }
    }
}
