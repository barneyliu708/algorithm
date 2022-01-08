using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC111MinimumDepthOfBinaryTree
    {
        public int MinDepth(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int minDepth = int.MaxValue;
            // we need to check null of left and right child because depth is counted for leave, 
            // when count depth, we don't want to count the root node as height = 1 if the root has only one child (left or right)
            if (root.left != null)
            {
                minDepth = Math.Min(minDepth, MinDepth(root.left));
            }
            if (root.right != null)
            {
                minDepth = Math.Min(minDepth, MinDepth(root.right));
            }

            return minDepth + 1;
        }
    }
}
