﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC226InvertBinaryTree
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
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            TreeNode left = root.left;
            root.left = root.right;
            root.right = left;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }

        public class SecondDone
        {
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                {
                    return root;
                }

                InvertTree(root.left);
                InvertTree(root.right);

                TreeNode left = root.left;
                root.left = root.right;
                root.right = left;

                return root;
            }
        }

        public class ThirdDone
        {
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                {
                    return null;
                }
                TreeNode left = InvertTree(root.left);
                TreeNode right = InvertTree(root.right);
                root.left = right;
                root.right = left;

                return root;
            }
        }
    }
}
