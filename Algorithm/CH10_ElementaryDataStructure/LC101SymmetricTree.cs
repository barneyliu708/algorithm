using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC101SymmetricTree
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
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode p, TreeNode q)
        {

            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSymmetric(p.left, q.right) &&
                   IsSymmetric(p.right, q.left);
        }
        
        public class SecondDone
        {
            public bool IsSymmetric(TreeNode root)
            {
                return IsEqual(root, root);
            }

            private bool IsEqual(TreeNode root1, TreeNode root2)
            {
                if (root1 == null && root2 == null)
                {
                    return true;
                }

                if (root1 == null || root2 == null)
                {
                    return false;
                }

                return root1.val == root2.val && IsEqual(root1.left, root2.right) && IsEqual(root1.right, root2.left);
            }
        }

        public class IterationApproach
        {
            public bool IsSymmetric(TreeNode root)
            {
                Queue<TreeNode> q1 = new Queue<TreeNode>();
                Queue<TreeNode> q2 = new Queue<TreeNode>();
                q1.Enqueue(root);
                q2.Enqueue(root);
                while (q1.Count > 0 && q2.Count > 0)
                {
                    TreeNode node1 = q1.Dequeue();
                    TreeNode node2 = q2.Dequeue();
                    if (node1 == null && node2 == null)
                    {
                        continue;
                    }
                    if (node1 == null || node2 == null || node1.val != node2.val)
                    {
                        return false;
                    }
                    q1.Enqueue(node1.left);
                    q1.Enqueue(node1.right);
                    q2.Enqueue(node2.right);
                    q2.Enqueue(node2.left);
                }

                return true;
            }
        }

        public class ThirdDone
        {
            public bool IsSymmetric(TreeNode root)
            {
                return IsEqual(root, root);
            }

            private bool IsEqual(TreeNode root1, TreeNode root2)
            {
                if (root1 == null && root2 == null)
                {
                    return true;
                }
                if (root1 == null || root2 == null)
                {
                    return false;
                }
                return root1.val == root2.val && IsEqual(root1.left, root2.right) && IsEqual(root1.right, root2.left);
            }
        }
    }
}
