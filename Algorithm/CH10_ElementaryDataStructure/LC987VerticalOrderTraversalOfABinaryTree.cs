using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC987VerticalOrderTraversalOfABinaryTree
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
        public class Node
        {
            public int row;
            public int col;
            public TreeNode node;
            public Node(int row, int col, TreeNode node)
            {
                this.row = row;
                this.col = col;
                this.node = node;
            }
        }
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {

            Dictionary<int, List<(int row, int val)>> map = new Dictionary<int, List<(int row, int val)>>();
            Queue<Node> queue = new Queue<Node>();

            // BFT
            queue.Enqueue(new Node(0, 0, root));
            while (queue.Count > 0)
            {
                Node cur = queue.Dequeue();

                if (!map.ContainsKey(cur.col))
                {
                    map[cur.col] = new List<(int row, int val)>();
                }
                map[cur.col].Add((cur.row, cur.node.val));

                if (cur.node.left != null)
                {
                    queue.Enqueue(new Node(cur.row + 1, cur.col - 1, cur.node.left));
                }

                if (cur.node.right != null)
                {
                    queue.Enqueue(new Node(cur.row + 1, cur.col + 1, cur.node.right));
                }
            }

            // prepare the answer
            List<IList<int>> ans = new List<IList<int>>();
            List<int> cols = map.Keys.ToList();
            cols.Sort();
            foreach (int col in cols)
            {
                map[col].Sort(((int row, int val) x, (int row, int val) y) => {
                    if (x.row != y.row)
                    {
                        return x.row.CompareTo(y.row);
                    }
                    return x.val.CompareTo(y.val);
                });
                ans.Add(map[col].Select(x => x.val).ToList());
            }

            return ans;
        }

        public class DftApproach
        {
            public IList<IList<int>> VerticalTraversal(TreeNode root)
            {
                Dictionary<int, List<(int row, int val)>> map = new Dictionary<int, List<(int row, int val)>>();
                Dft(root, 0, 0, map);

                // prepare the answer
                int[] cols = map.Keys.ToArray();
                Array.Sort(cols);
                List<IList<int>> ans = new List<IList<int>>();
                foreach (int col in cols)
                {
                    map[col].Sort(((int row, int val) x, (int row, int val) y) => {
                        if (x.row == y.row)
                        {
                            return x.val.CompareTo(y.val);
                        }
                        return x.row.CompareTo(y.row);
                    });
                    ans.Add(map[col].Select(x => x.val).ToList());
                }

                return ans;
            }

            private void Dft(TreeNode root, int col, int row, Dictionary<int, List<(int row, int val)>> map)
            {
                if (root == null)
                {
                    return;
                }
                if (!map.ContainsKey(col))
                {
                    map[col] = new List<(int row, int val)>();
                }
                map[col].Add((row, root.val));

                Dft(root.left, col - 1, row + 1, map);
                Dft(root.right, col + 1, row + 1, map);
            }
        }
    }
}
