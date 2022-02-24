using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC314BinaryTreeVerticalOrderTraversal
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

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {

            if (root == null)
            {
                return new List<IList<int>>();
            }

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));

            while (queue.Count != 0)
            {

                TreeNode curNode = queue.Peek().Key;
                int curCol = queue.Peek().Value;

                queue.Dequeue();

                if (!map.ContainsKey(curCol))
                {
                    map[curCol] = new List<int>();
                }
                map[curCol].Add(curNode.val);

                if (curNode.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(curNode.left, curCol - 1));
                }

                if (curNode.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(curNode.right, curCol + 1));
                }
            }

            IList<IList<int>> ans = new List<IList<int>>();
            List<int> colList = map.Keys.ToList();
            colList.Sort();
            foreach (int col in colList)
            {
                ans.Add(map[col]);
            }

            return ans;
        }

        class DftApproach
        {
            public IList<IList<int>> VerticalOrder(TreeNode root)
            {

                Dictionary<int, List<KeyValuePair<int, int>>> map = new Dictionary<int, List<KeyValuePair<int, int>>>();
                DftUti(root, 0, 0, map);

                List<int> sortedIndexes = map.Keys.ToList();
                sortedIndexes.Sort();

                IList<IList<int>> ans = new List<IList<int>>();
                foreach (int index in sortedIndexes)
                {
                    List<KeyValuePair<int, int>> nodes = map[index];
                    ans.Add(nodes.OrderBy(n => n.Key).Select(n => n.Value).ToList()); // order by row, select the node value as an array
                }

                return ans;
            }

            private void DftUti(TreeNode root, int col, int row, Dictionary<int, List<KeyValuePair<int, int>>> map)
            { // map: index - value[]

                if (root == null)
                {
                    return;
                }

                if (!map.ContainsKey(col))
                {
                    map[col] = new List<KeyValuePair<int, int>>();
                }

                map[col].Add(new KeyValuePair<int, int>(row, root.val));
                DftUti(root.left, col - 1, row + 1, map);
                DftUti(root.right, col + 1, row + 1, map);
            }
        }
    }
}
