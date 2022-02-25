using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC236LowestCommonAncestorOfABinaryTree
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

        private TreeNode ans;

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            DftUti(root, p, q);

            return ans;
        }

        private int DftUti(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return 0;
            }

            int left = DftUti(root.left, p, q);
            int right = DftUti(root.right, p, q);
            int mid = (root == p || root == q) ? 1 : 0;

            if (mid + left + right >= 2 && this.ans == null) // check ans == null to ensure ans is the first node which is greater than 2
            { 
                this.ans = root;
            }

            return mid + left + right;
        }
    }
}
