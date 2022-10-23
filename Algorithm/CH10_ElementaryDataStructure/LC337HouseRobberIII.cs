using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC337HouseRobberIII
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

        Dictionary<TreeNode, int> robResults = new Dictionary<TreeNode, int>();
        Dictionary<TreeNode, int> notRobResults = new Dictionary<TreeNode, int>();

        public int Rob(TreeNode root)
        {
            return Rob(root, false);
        }

        private int Rob(TreeNode root, bool isParentRobbed)
        {
            if (root == null)
            {
                return 0;
            }

            if (isParentRobbed)
            {
                if (robResults.ContainsKey(root))
                {
                    return robResults[root];
                }
                int result = Rob(root.left, false) + Rob(root.right, false);
                robResults[root] = result;
                return result;
            }
            else
            {
                if (notRobResults.ContainsKey(root))
                {
                    return notRobResults[root];
                }
                int rob = root.val + Rob(root.left, true) + Rob(root.right, true);
                int notRob = Rob(root.left, false) + Rob(root.right, false);
                int result = Math.Max(rob, notRob);
                notRobResults[root] = result;
                return result;
            }
        }

        public class SecondDone_BottonUp
        {
            Dictionary<TreeNode, int> robResults = new Dictionary<TreeNode, int>();
            Dictionary<TreeNode, int> notRobResults = new Dictionary<TreeNode, int>();

            public int Rob(TreeNode root)
            {

                if (root == null)
                {
                    return 0;
                }

                if (root.left == null && root.right == null)
                {
                    robResults[root] = root.val;
                    notRobResults[root] = 0;
                    // Console.WriteLine($"{root.val} rob: {root.val} notRob: {0}");
                    return robResults[root];
                }

                Rob(root.left);
                Rob(root.right);

                if (root.left == null && root.right != null)
                {
                    robResults[root] = root.val + notRobResults[root.right];
                    notRobResults[root] = Math.Max(robResults[root.right], notRobResults[root.right]);
                    // Console.WriteLine($"{root.val} rob: {robResults[root]} notRob: {notRobResults[root]}");
                    return Math.Max(robResults[root], notRobResults[root]);
                }

                if (root.left != null && root.right == null)
                {
                    robResults[root] = root.val + notRobResults[root.left];
                    notRobResults[root] = Math.Max(robResults[root.left], notRobResults[root.left]);
                    // Console.WriteLine($"{root.val} rob: {robResults[root]} notRob: {notRobResults[root]}");
                    return Math.Max(robResults[root], notRobResults[root]);
                }

                robResults[root] = root.val + notRobResults[root.left] + notRobResults[root.right];
                notRobResults[root] = robResults[root.left] + robResults[root.right];
                notRobResults[root] = Math.Max(notRobResults[root], robResults[root.left] + notRobResults[root.right]);
                notRobResults[root] = Math.Max(notRobResults[root], notRobResults[root.left] + robResults[root.right]);
                notRobResults[root] = Math.Max(notRobResults[root], notRobResults[root.left] + notRobResults[root.right]);
                // Console.WriteLine($"{root.val} rob: {robResults[root]} notRob: {notRobResults[root]}");
                return Math.Max(robResults[root], notRobResults[root]);
            }
        }

        public class ThirdDone
        {
            public int Rob(TreeNode root)
            {
                Dictionary<TreeNode, int> robResults = new Dictionary<TreeNode, int>();
                Dictionary<TreeNode, int> notRobResults = new Dictionary<TreeNode, int>();
                return Rob(root, false, robResults, notRobResults);
            }

            private int Rob(TreeNode root, bool isParentRobbed, Dictionary<TreeNode, int> robResults, Dictionary<TreeNode, int> notRobResults)
            {
                if (root == null)
                {
                    return 0;
                }

                if (!robResults.ContainsKey(root))
                {
                    robResults[root] = Rob(root.left, true, robResults, notRobResults) + Rob(root.right, true, robResults, notRobResults) + root.val;
                }
                if (!notRobResults.ContainsKey(root))
                {
                    notRobResults[root] = Rob(root.left, false, robResults, notRobResults) + Rob(root.right, false, robResults, notRobResults);
                }

                if (isParentRobbed)
                {
                    return notRobResults[root];
                }
                return Math.Max(robResults[root], notRobResults[root]);
            }
        }
    }
}
