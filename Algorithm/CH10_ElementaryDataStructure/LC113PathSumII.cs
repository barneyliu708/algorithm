using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC113PathSumII
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
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> results = new List<IList<int>>();
            IList<int> pathNodes = new List<int>();
            PathSumDFT(root, targetSum, pathNodes, results);
            return results;
        }

        private void PathSumDFT(TreeNode root, int targetSum, IList<int> pathNodes, IList<IList<int>> results)
        {

            if (root == null)
            {
                return;
            }

            pathNodes.Add(root.val);

            if (root.left == null && root.right == null)
            { // this is a leaf
                if (root.val == targetSum)
                {
                    results.Add(new List<int>(pathNodes));
                }
            }

            if (root.left != null)
            {
                PathSumDFT(root.left, targetSum - root.val, pathNodes, results);
            }

            if (root.right != null)
            {
                PathSumDFT(root.right, targetSum - root.val, pathNodes, results);
            }

            // remove element by index is safer
            pathNodes.RemoveAt(pathNodes.Count - 1);

            return;
        }
    }
}
