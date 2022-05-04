using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC235LowestCommonAncestorOfABinarySearchTree
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

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            if (p.val >= q.val)
            {
                return LowestCommonAncestor(root, q, p);
            }
            // where p.val <= q.val

            // root.val < p.val <= q.val
            if (root.val < p.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }

            // p.val <= q.val < root.val
            if (q.val < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }

            // root.val = p.val <= q.val || p.val <= q.val = root.val || p.val <= root.val <= q.val
            return root;
        }

        public class SecondDone
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                if (p.val >= q.val)
                {
                    return LowestCommonAncestor(root, q, p);
                }

                if (root.val < p.val)
                {
                    return LowestCommonAncestor(root.right, p, q);
                }
                if (root.val > q.val)
                {
                    return LowestCommonAncestor(root.left, p, q);
                }

                return root;
            }
        }

        public class SecondDone_2
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                if (p.val >= q.val)
                {
                    return LowestCommonAncestor(root, q, p);
                }

                // p.val < q.val
                if (root.val < p.val)
                {
                    return LowestCommonAncestor(root.right, p, q);
                }

                if (root.val > q.val)
                {
                    return LowestCommonAncestor(root.left, p, q);
                }

                return root;
            }
        }
    }
}
