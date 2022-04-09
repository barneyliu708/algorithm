using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC572SubtreeOfAnotherTree
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
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {

            if (root == null && subRoot == null)
            {
                return true;
            }

            if (root == null || subRoot == null)
            {
                return false;
            }

            if (IsSame(root, subRoot))
            {
                return true;
            }

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        private bool IsSame(TreeNode r1, TreeNode r2)
        {

            if (r1 == null && r2 == null)
            {
                return true;
            }

            if (r1 == null || r2 == null)
            {
                return false;
            }

            if (r1.val != r2.val)
            {
                return false;
            }

            return IsSame(r1.left, r2.left) && IsSame(r1.right, r2.right);
        }

        public class SecondDone
        {
            public bool IsSubtree(TreeNode root, TreeNode subRoot)
            {
                if (root == null && subRoot == null)
                {
                    return true;
                }
                if (root == null || subRoot == null)
                {
                    return false;
                }
                if (IsEqual(root, subRoot))
                {
                    return true;
                }
                return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
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

                return root1.val == root2.val && IsEqual(root1.left, root2.left) && IsEqual(root1.right, root2.right);
            }
        }
    }
}
