using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC366FindLeavesOfBinaryTree
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
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            FindLeaves(root, ans);

            return ans;
        }

        public int FindLeaves(TreeNode root, IList<IList<int>> ans)
        { // return the distance from the leave

            if (root == null)
            {
                return -1;
            }

            int distLeft = FindLeaves(root.left, ans);
            int distRight = FindLeaves(root.right, ans);

            int dist = 1 + Math.Max(distLeft, distRight);

            while (dist >= ans.Count)
            {
                ans.Add(new List<int>());
            }
            ans[dist].Add(root.val);

            return dist;
        }
    }
}
