using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1110DeleteNodesAndReturnForest
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

        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            HashSet<int> toDelete = new HashSet<int>(to_delete);

            HashSet<TreeNode> ans = new HashSet<TreeNode>();
            ans.Add(root);

            DelNodes(root, null, 0, toDelete, ans);

            return ans.ToList();
        }

        private void DelNodes(TreeNode cur, TreeNode par, int direction, HashSet<int> toDelete, HashSet<TreeNode> ans)
        {

            if (cur == null)
            {
                return;
            }

            TreeNode left = cur.left;
            TreeNode right = cur.right;
            if (toDelete.Contains(cur.val))
            {
                // if cur node is a root, need to remove it from the answer list 
                if (ans.Contains(cur))
                {
                    ans.Remove(cur);
                }
                if (left != null)
                {
                    ans.Add(left);
                }
                if (right != null)
                {
                    ans.Add(right);
                }

                // remove the parent reference
                if (direction == -1)
                {
                    par.left = null;
                }
                if (direction == 1)
                {
                    par.right = null;
                }

                // remove the current node reference
                cur.left = null;
                cur.right = null;
            }


            DelNodes(left, cur, -1, toDelete, ans);
            DelNodes(right, cur, 1, toDelete, ans);
        }
    }
}
