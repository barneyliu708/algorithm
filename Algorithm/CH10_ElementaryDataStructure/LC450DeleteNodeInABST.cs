using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC450DeleteNodeInABST
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
        public TreeNode Successor(TreeNode root)
        {
            if (root.right == null)
            {
                return null;
            }
            TreeNode cur = root.right;

            while (cur.left != null)
            {
                cur = cur.left;
            }

            return cur;
        }

        public TreeNode Predecessor(TreeNode root)
        {
            if (root.left == null)
            {
                return null;
            }
            TreeNode cur = root.left;

            while (cur.right != null)
            {
                cur = cur.right;
            }

            return cur;
        }

        public TreeNode DeleteNode(TreeNode root, int key)
        {

            if (root == null)
            {
                return null;
            }

            if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
            }
            else if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                else if (root.right != null)
                {
                    TreeNode successor = Successor(root);
                    root.val = successor.val;
                    root.right = DeleteNode(root.right, successor.val);
                }
                else
                {
                    TreeNode predecessor = Predecessor(root);
                    root.val = predecessor.val;
                    root.left = DeleteNode(root.left, predecessor.val);
                }
            }

            return root;
        }
    }
}
