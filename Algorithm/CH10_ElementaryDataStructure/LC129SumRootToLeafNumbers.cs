using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC129SumRootToLeafNumbers
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
        public class Solution
        {

            private int totalSum = 0;

            public int SumNumbers(TreeNode root)
            {

                totalSum = 0;
                Dft(root, 0);
                return totalSum;
            }

            private void Dft(TreeNode root, int curSum)
            {

                if (root == null)
                {
                    return;
                }

                curSum = curSum * 10 + root.val;

                if (root.left == null && root.right == null)
                { // this is a leaf
                    totalSum += curSum;
                    return;
                }

                if (root.left != null)
                {
                    Dft(root.left, curSum);
                }

                if (root.right != null)
                {
                    Dft(root.right, curSum);
                }

                return;
            }
        }
    }
}
