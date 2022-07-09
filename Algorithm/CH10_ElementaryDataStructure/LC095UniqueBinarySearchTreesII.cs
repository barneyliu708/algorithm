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

        public class SecondDone
        {
            public IList<TreeNode> GenerateTrees(int n)
            {
                return GenerateTrees(1, n);
            }

            private List<TreeNode> GenerateTrees(int left, int right)
            {
                List<TreeNode> ans = new List<TreeNode>();
                if (left > right)
                {
                    return ans;
                }
                if (left == right)
                {
                    ans.Add(new TreeNode(left));
                    return ans;
                }
                for (int i = left; i <= right; i++)
                {
                    List<TreeNode> leftChildren = GenerateTrees(left, i - 1);
                    List<TreeNode> rightChildren = GenerateTrees(i + 1, right);
                    if (leftChildren.Count == 0)
                    {
                        foreach (TreeNode rightChild in rightChildren)
                        {
                            TreeNode root = new TreeNode(i);
                            root.right = rightChild;
                            ans.Add(root);
                        }
                    }
                    else if (rightChildren.Count == 0)
                    {
                        foreach (TreeNode leftChild in leftChildren)
                        {
                            TreeNode root = new TreeNode(i);
                            root.left = leftChild;
                            ans.Add(root);
                        }
                    }
                    else
                    {
                        foreach (TreeNode leftChild in leftChildren)
                        {
                            foreach (TreeNode rightChild in rightChildren)
                            {
                                TreeNode root = new TreeNode(i);
                                root.left = leftChild;
                                root.right = rightChild;
                                ans.Add(root);
                            }
                        }
                    }
                }
                return ans;
            }
        }
    }
}
