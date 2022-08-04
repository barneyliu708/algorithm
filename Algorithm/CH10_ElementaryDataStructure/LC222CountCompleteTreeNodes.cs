using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC222CountCompleteTreeNodes
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
        public int CountNodes(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }

            int d = GetDepth(root);
            if (d == 0)
            {
                return 1;
            }

            int start = 0, end = (int)Math.Pow(2, d) - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (IsExist(mid, d, root))
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return (int)Math.Pow(2, d) - 1 + start; // +start, not +end
        }

        public int GetDepth(TreeNode node)
        {
            int d = 0;
            while (node.left != null)
            {
                d++;
                node = node.left;
            }
            return d;
        }

        public bool IsExist(int index, int d, TreeNode node)
        {
            int start = 0;
            int end = (int)Math.Pow(2, d) - 1;
            for (int i = 0; i < d; i++)
            {
                int mid = start + (end - start) / 2;
                if (index <= mid) // here is <=, not <
                { 
                    node = node.left;
                    end = mid; // not mid - 1;
                }
                else
                {
                    node = node.right;
                    start = mid + 1;
                }
            }
            return node != null;
        }

        public class SecondDone
        {
            public int CountNodes(TreeNode root)
            {

                if (root == null)
                {
                    return 0;
                }

                int depth = GetDepth(root);

                int l = 1;
                int r = (int)Math.Pow(2, depth - 1);
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (IsExist(mid, root, depth))
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return (int)Math.Pow(2, depth - 1) - 1 + r;
            }

            private int GetDepth(TreeNode root)
            {
                int dep = 0;
                while (root != null)
                {
                    dep++;
                    root = root.left;
                }
                return dep;
            }

            private bool IsExist(int index, TreeNode root, int depth)
            {
                int total = (int)Math.Pow(2, depth - 1);
                while (depth > 1)
                {
                    total /= 2;
                    if (index > total)
                    {
                        index -= total;
                        root = root.right;
                    }
                    else
                    {
                        root = root.left;
                    }
                    depth--;
                }

                return root != null;
            }
        }
    }
}
