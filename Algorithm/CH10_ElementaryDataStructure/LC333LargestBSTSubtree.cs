using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC333LargestBSTSubtree
    {
        public class NodeValue
        {
            public int MaxValue;
            public int MinValue;
            public int MaxSize;
            public NodeValue(int minValue, int maxValue, int maxSize)
            {
                MinValue = minValue;
                MaxValue = maxValue;
                MaxSize = maxSize;
            }
        }

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

        public int LargestBSTSubtree(TreeNode root)
        {
            return LargestBSTSubtreeUti(root).MaxSize;
        }

        public NodeValue LargestBSTSubtreeUti(TreeNode root)
        {

            if (root == null)
            {
                return new NodeValue(int.MaxValue, int.MinValue, 0);
            }

            NodeValue left = LargestBSTSubtreeUti(root.left);
            NodeValue right = LargestBSTSubtreeUti(root.right);

            if (left.MaxValue < root.val && root.val < right.MinValue)
            { // this is BST
                return new NodeValue(Math.Min(left.MinValue, root.val), Math.Max(right.MaxValue, root.val), left.MaxSize + right.MaxSize + 1);
            }

            return new NodeValue(int.MinValue, int.MaxValue, Math.Max(left.MaxSize, right.MaxSize));
        }

        public class SecondDone
        {
            public class NodeValue
            {
                public int MaxValue;
                public int MinValue;
                public int MaxSize;
                public NodeValue(int minValue, int maxValue, int maxSize)
                {
                    MinValue = minValue;
                    MaxValue = maxValue;
                    MaxSize = maxSize;
                }
            }

            public int LargestBSTSubtree(TreeNode root)
            {
                return Dft(root).MaxSize;
            }

            public NodeValue Dft(TreeNode root)
            {

                if (root == null)
                {
                    return new NodeValue(int.MaxValue, int.MinValue, 0);
                }

                NodeValue left = Dft(root.left);
                NodeValue right = Dft(root.right);

                if (left.MaxValue < root.val && root.val < right.MinValue)
                {
                    return new NodeValue(Math.Min(left.MinValue, root.val), Math.Max(root.val, right.MaxValue), left.MaxSize + 1 + right.MaxSize);
                }

                return new NodeValue(int.MinValue, int.MaxValue, Math.Max(left.MaxSize, right.MaxSize));
            }
        }
    }
}
