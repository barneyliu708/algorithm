using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC114FlatternBinaryTreeToLinkedList
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
        public void Flatten(TreeNode root)
        {
            FlatternUti(root);
        }

        private TreeNode FlatternUti(TreeNode root)
        {

            if (root == null)
            {
                return null;
            }

            if (root.left == null && root.right == null)
            {
                return root;
            }

            TreeNode leftTail = FlatternUti(root.left);
            TreeNode rightTail = FlatternUti(root.right);

            if (leftTail != null)
            {
                leftTail.right = root.right;
                root.right = root.left;
                root.left = null;
            }

            return rightTail == null ? leftTail : rightTail;
        }

        public class Pair<K, V>
        {
            K key;
            V value;
            public Pair(K a, V b)
            {
                this.key = a;
                this.value = b;
            }
            public K getKey()
            {
                return this.key;
            }
            public V getValue()
            {
                return this.value;
            }
        }

        public void FlattenV2(TreeNode root)
        {
            TreeNode tailNode = null;
            int START = 1;
            int END = 2;
            Stack<Pair<TreeNode, int>> stack = new Stack<Pair<TreeNode, int>>();
            stack.Push(new Pair<TreeNode, int>(root, START));

            while (stack.Count != 0)
            {
                Pair<TreeNode, int> pair = stack.Pop();
                TreeNode currentNode = pair.getKey();
                int currentState = pair.getValue();

                if (currentNode.left == null && currentNode.right == null)
                {
                    tailNode = currentNode;
                    continue;
                }

                if (currentState == START)
                {
                    if (currentNode.left != null)
                    {
                        stack.Push(new Pair<TreeNode, int>(currentNode, END));
                        stack.Push(new Pair<TreeNode, int>(currentNode.left, START));
                    }
                    else if (currentNode.right != null)
                    {
                        stack.Push(new Pair<TreeNode, int>(currentNode.right, START));
                    }
                }
                else
                {
                    TreeNode rightNode = currentNode.right;
                    if (tailNode != null)
                    {
                        tailNode.right = currentNode.right;
                        currentNode.right = currentNode.left;
                        currentNode.left = null;

                        rightNode = tailNode.right;
                    }

                    if (rightNode != null)
                    {
                        stack.Push(new Pair<TreeNode, int>(rightNode, START));
                    }
                }
            }
        }

        public class SecondDone
        {
            public void Flatten(TreeNode root)
            {
                FlattenUti(root);
            }

            public TreeNode FlattenUti(TreeNode root)
            { // return the tail node of list
                if (root == null)
                {
                    return null;
                }

                if (root.left == null && root.right == null)
                {
                    return root;
                }

                TreeNode leftTail;
                TreeNode rightTail;
                if (root.left != null && root.right == null)
                {
                    leftTail = FlattenUti(root.left);
                    root.right = root.left;
                    root.left = null;
                    return leftTail;
                }
                if (root.left == null && root.right != null)
                {
                    rightTail = FlattenUti(root.right);
                    return rightTail;
                }

                leftTail = FlattenUti(root.left);
                rightTail = FlattenUti(root.right);
                leftTail.right = root.right;
                root.right = root.left;
                root.left = null;
                return rightTail;
            }
        }
    }
}
