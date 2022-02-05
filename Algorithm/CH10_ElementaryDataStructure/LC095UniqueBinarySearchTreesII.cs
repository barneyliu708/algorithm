using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC095UniqueBinarySearchTreesII
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
        public IList<TreeNode> GenerateTrees(int n)
        {
            return GenerateTrees(1, n);
        }

        public List<TreeNode> GenerateTrees(int start, int end)
        {
            List<TreeNode> ans = new List<TreeNode>();
            if (start > end)
            {
                ans.Add(null); // this is to cover the leaf node situation
                return ans;
            }

            for (int i = start; i <= end; i++)
            {
                List<TreeNode> lans = GenerateTrees(start, i - 1);
                List<TreeNode> rans = GenerateTrees(i + 1, end);

                foreach (TreeNode l in lans)
                {
                    foreach (TreeNode r in rans)
                    {
                        TreeNode root = new TreeNode(i);
                        root.left = l;
                        root.right = r;
                        ans.Add(root);
                    }
                }
            }

            return ans;
        }
    }
}
