using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC2096StepByStepDirectionsFromABinaryTreeNodeToAnother
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

        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            string startpath = GetPath(root, startValue, new List<char>(), 'O');
            string destpath = GetPath(root, destValue, new List<char>(), 'O');

            int p = 0;
            // find the closest common parent node of the start and the destination node
            while (p < startpath.Length && p < destpath.Length && startpath[p] == destpath[p])
            {
                p++;
            }
            startpath = startpath.Substring(p);
            destpath = destpath.Substring(p);

            StringBuilder sb = new StringBuilder();
            sb.Append(new string('U', startpath.Length));
            sb.Append(destpath);

            return sb.ToString();
        }

        private string GetPath(TreeNode root, int target, List<char> path, char direction)
        {
            if (root == null)
            {
                return null;
            }
            path.Add(direction);
            if (root.val == target)
            {
                return string.Join("", path);
            }

            string leftpath = GetPath(root.left, target, path, 'L');
            if (leftpath != null)
            {
                return leftpath;
            }
            string rightpath = GetPath(root.right, target, path, 'R');
            if (rightpath != null)
            {
                return rightpath;
            }

            path.RemoveAt(path.Count - 1);
            return null;
        }
    }
}
