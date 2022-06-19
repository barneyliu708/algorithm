using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC236LowestCommonAncestorOfABinaryTree
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

        private TreeNode ans;

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            DftUti(root, p, q);

            return ans;
        }

        private int DftUti(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return 0;
            }

            int left = DftUti(root.left, p, q);
            int right = DftUti(root.right, p, q);
            int mid = (root == p || root == q) ? 1 : 0;

            if (mid + left + right >= 2 && this.ans == null) // check ans == null to ensure ans is the first node which is greater than 2
            { 
                this.ans = root;
            }

            return mid + left + right;
        }

        public class IterativeApproach
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {

                // DFT iteratively to generate parents pointers
                Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();
                parents[root] = null;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    TreeNode cur = stack.Pop();
                    if (cur.right != null)
                    {
                        parents[cur.right] = cur;
                        stack.Push(cur.right);
                    }
                    if (cur.left != null)
                    {
                        parents[cur.left] = cur;
                        stack.Push(cur.left);
                    }
                }

                // find the ancestor by two pointers
                TreeNode pi = p;
                TreeNode qi = q;
                while (pi != qi)
                {
                    pi = pi == null ? q : parents[pi];
                    qi = qi == null ? p : parents[qi];
                }

                return pi;
            }
        }

        public class ThirdDone
        {
            public class Solution
            {
                private TreeNode ancestor;

                public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
                {
                    Dft(root, p, q);
                    return ancestor;
                }

                private int Dft(TreeNode root, TreeNode p, TreeNode q)
                {

                    if (root == null)
                    {
                        return 0;
                    }

                    int left = Dft(root.left, p, q);
                    int right = Dft(root.right, p, q);

                    int ans = left + right;
                    if (root == p || root == q)
                    {
                        ans += 1;
                    }

                    if (ans == 2 && ancestor == null)
                    {
                        ancestor = root;
                    }

                    return ans;
                }
            }
        }
    }
}
