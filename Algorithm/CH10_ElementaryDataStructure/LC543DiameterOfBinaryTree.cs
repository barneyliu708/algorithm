using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC543DiameterOfBinaryTree
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

        private int diameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            LongestPath(root);
            return diameter;
        }

        private int LongestPath(TreeNode root)
        {

            if (root == null)
            {
                return -1; // the path of the leaf is 0 rather than 1
            }

            int left = LongestPath(root.left);
            int right = LongestPath(root.right);

            diameter = Math.Max(diameter, left + right + 2);

            return Math.Max(left + 1, right + 1);
        }

        public class SecondDone
        {
            private int diameter = 0;

            public int DiameterOfBinaryTree(TreeNode root)
            {
                Depth(root);
                return diameter;
            }

            private int Depth(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                int left = Depth(root.left);
                int right = Depth(root.right);

                diameter = Math.Max(diameter, left + right);

                return 1 + Math.Max(left, right);
            }
        }
    }
}
