using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC863AllNodesDistanceKInBinaryTree
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
        public class ConvertToGraphApproach
        {
            public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
            {

                Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();
                MapParents(root, null, parents);

                Queue<TreeNode> queue = new Queue<TreeNode>();
                HashSet<TreeNode> visited = new HashSet<TreeNode>();

                // breadth-first traversal, start with the target node, and keep track of the distance from the target node
                queue.Enqueue(target);
                visited.Add(target);
                int dist = 0;
                while (queue.Count > 0)
                {
                    if (dist == k)
                    {
                        break;
                    }
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        TreeNode cur = queue.Dequeue();
                        if (cur.left != null && !visited.Contains(cur.left))
                        {
                            visited.Add(cur.left);
                            queue.Enqueue(cur.left);
                        }
                        if (cur.right != null && !visited.Contains(cur.right))
                        {
                            visited.Add(cur.right);
                            queue.Enqueue(cur.right);
                        }
                        if (parents[cur] != null && !visited.Contains(parents[cur]))
                        {
                            visited.Add(parents[cur]);
                            queue.Enqueue(parents[cur]);
                        }
                    }
                    dist++;
                }

                List<int> ans = new List<int>();
                foreach (TreeNode node in queue)
                {
                    ans.Add(node.val);
                }
                return ans;
            }

            private void MapParents(TreeNode cur, TreeNode parent, Dictionary<TreeNode, TreeNode> parents)
            {
                if (cur == null)
                {
                    return;
                }

                parents[cur] = parent;

                MapParents(cur.left, cur, parents);
                MapParents(cur.right, cur, parents);
            }
        }

        public class SecondDone
        {
            public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
            {
                Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();
                DftParents(root, null, parents);

                // breadth first traversal to get kth distance nodes
                Queue<TreeNode> queue = new Queue<TreeNode>();
                HashSet<TreeNode> visited = new HashSet<TreeNode>();
                queue.Enqueue(target);
                while (queue.Count > 0 && k > 0)
                {
                    int count = queue.Count();
                    for (int i = 0; i < count; i++)
                    {
                        TreeNode cur = queue.Dequeue();
                        visited.Add(cur);
                        if (cur.left != null && !visited.Contains(cur.left))
                        {
                            queue.Enqueue(cur.left);
                        }
                        if (cur.right != null && !visited.Contains(cur.right))
                        {
                            queue.Enqueue(cur.right);
                        }
                        if (parents[cur] != null && !visited.Contains(parents[cur]))
                        {
                            queue.Enqueue(parents[cur]);
                        }
                    }
                    k--;
                }

                return queue.ToList().Select(x => x.val).ToList();
            }

            private void DftParents(TreeNode cur, TreeNode par, Dictionary<TreeNode, TreeNode> parents)
            {
                if (cur == null)
                {
                    return;
                }
                parents[cur] = par;
                DftParents(cur.left, cur, parents);
                DftParents(cur.right, cur, parents);
            }
        }
    }
}
