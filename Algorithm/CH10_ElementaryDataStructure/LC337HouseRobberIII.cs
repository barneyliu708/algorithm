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
    }
}
