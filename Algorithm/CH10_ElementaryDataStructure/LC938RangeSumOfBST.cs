﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC938RangeSumOfBST
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
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
            {
                return 0;
            }

            int sum = 0;
            if (root.val >= low && root.val <= high)
            {
                sum += root.val;
            }

            if (root.val > low)
            {
                sum += RangeSumBST(root.left, low, high);
            }


            if (root.val < high)
            {
                sum += RangeSumBST(root.right, low, high);
            }


            return sum;
        }

        public class SecondDone
        {
            public int RangeSumBST(TreeNode root, int low, int high)
            {
                if (root == null)
                {
                    return 0;
                }

                int sum = 0;
                if (root.val >= low && root.val <= high)
                {
                    sum += root.val;
                }

                sum += RangeSumBST(root.left, low, high);
                sum += RangeSumBST(root.right, low, high);

                return sum;
            }
        }
    }
}
