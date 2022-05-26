using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC156BinaryTreeUpsideDown
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
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {

            if (root == null)
            {
                return root;
            }

            if (root.left == null && root.right == null)
            {
                return root;
            }

            TreeNode left = root.left;
            TreeNode right = root.right;
            root.left = null;
            root.right = null;

            TreeNode newRoot = UpsideDownBinaryTree(left);
            left.left = right;
            left.right = root;

            return newRoot;
        }
    }
}
