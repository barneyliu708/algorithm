using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC124BinaryTreeMaximumPathSum
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

        private int maxSum = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxSum(root);
            return maxSum;
        }

        private int MaxSum(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }

            int left = MaxSum(root.left);
            int right = MaxSum(root.right);

            maxSum = Math.Max(maxSum, left + right + root.val);

            return Math.Max(0, Math.Max(left + root.val, right + root.val));
        }

        public class SecondDone
        {
            private int maxSum = int.MinValue;
            public int MaxPathSum(TreeNode root)
            {
                MaxChildSum(root);
                return maxSum;
            }

            private int MaxChildSum(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                int left = MaxChildSum(root.left);
                int right = MaxChildSum(root.right);

                maxSum = Math.Max(maxSum, root.val + left + right);

                return Math.Max(0, root.val + Math.Max(left, right));
            }
        }
    }
}
