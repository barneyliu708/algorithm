using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC173BinarySearchTreeIterator
    {
        public class BSTIterator
        {

            private Stack<TreeNode> stack = new Stack<TreeNode>();

            public BSTIterator(TreeNode root)
            {
                LeftMostInorder(root);
            }

            public int Next()
            {

                TreeNode curnode = stack.Pop();
                if (curnode.right != null)
                {
                    LeftMostInorder(curnode.right);
                }
                return curnode.val;

            }

            public bool HasNext()
            {
                return stack.Count > 0;
            }

            private void LeftMostInorder(TreeNode root)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
            }
        }
    }
}
