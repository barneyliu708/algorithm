using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC105ConstructBinaryTreeFromPreorderInorder
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

        private static int preIndex = 0;
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            preIndex = 0;
            return BuildTree(preorder, inorder, 0, inorder.Length - 1);
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder, int inStart, int inEnd)
        {

            if (inStart > inEnd)
            {
                return null;
            }

            var newNode = new TreeNode(preorder[preIndex++]);

            if (inStart == inEnd)
            {
                return newNode;
            }

            int inIndex = Search(inorder, inStart, inEnd, newNode.val);
            TreeNode leftNode = BuildTree(preorder, inorder, inStart, inIndex - 1);
            TreeNode rightNode = BuildTree(preorder, inorder, inIndex + 1, inEnd);

            newNode.left = leftNode;
            newNode.right = rightNode;

            return newNode;
        }

        private int Search(int[] arr, int start, int end, int target)
        {

            for (int i = start; i <= end; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public class SecondDone
        {
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                if (preorder.Length == 0 || inorder.Length == 0)
                {
                    return null;
                }

                TreeNode root = new TreeNode(preorder[0]);
                int i = FindIndex(inorder, root.val);

                root.left = BuildTree(preorder.Skip(1).Take(i).ToArray(), inorder.Take(i).ToArray());
                root.right = BuildTree(preorder.Skip(1 + i).Take(preorder.Length - i - 1).ToArray(), inorder.Skip(1 + i).Take(inorder.Length - i - 1).ToArray());

                return root;
            }

            private int FindIndex(int[] array, int target)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == target)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public class ThirdDone
        {
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
            }

            private TreeNode BuildTree(int[] preorder, int pl, int pr, int[] inorder, int il, int ir)
            {
                if (pl > pr || il > ir)
                {
                    return null;
                }
                TreeNode root = new TreeNode(preorder[pl]);
                int imid = il;
                while (inorder[imid] != root.val)
                {
                    imid++;
                }
                int leftLen = imid - il;
                root.left = BuildTree(preorder, pl + 1, pl + leftLen, inorder, il, imid - 1);
                root.right = BuildTree(preorder, pl + leftLen + 1, pr, inorder, imid + 1, ir);
                return root;
            }
        }

        public class ForthDone
        {
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                return Utility(preorder, inorder, (0, preorder.Length - 1), (0, inorder.Length - 1));
            }

            private TreeNode Utility(int[] preorder, int[] inorder, (int l, int r) pre, (int l, int r) ino)
            {
                if (pre.l > pre.r)
                {
                    return null;
                }

                TreeNode root = new TreeNode(preorder[pre.l]);

                int i = ino.l;
                while (i <= ino.r)
                {
                    if (inorder[i] == root.val)
                    {
                        break;
                    }
                    i++;
                }

                root.left = Utility(preorder, inorder, (pre.l + 1, pre.l + i - ino.l), (ino.l, i - 1));
                root.right = Utility(preorder, inorder, (pre.l + i - ino.l + 1, pre.r), (i + 1, ino.r));

                return root;
            }
        }

        [Test]
        public void PositiveCaase1()
        {
            int[] pre = new int[] { 3, 9, 20, 15, 7 };
            int[] ino = new int[] { 9, 3, 15, 20, 7 };
            int len = ino.Length;
            TreeNode root = BuildTree(pre, ino);
        }
        [Test]
        public void PositiveCaase2()
        {
            int[] pre = new int[] { -1 };
            int[] ino = new int[] { -1 };
            int len = ino.Length;
            TreeNode root = BuildTree(pre, ino);
        }
    }
}
