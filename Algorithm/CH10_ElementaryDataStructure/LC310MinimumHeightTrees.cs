using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC310MinimumHeightTrees
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {

            if (n < 2)
            {
                List<int> centroids = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    centroids.Add(i);
                }
                return centroids;
            }

            List<int>[] adjacentList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjacentList[i] = new List<int>();
            }

            foreach (int[] edge in edges)
            {
                adjacentList[edge[0]].Add(edge[1]);
                adjacentList[edge[1]].Add(edge[0]);
            }

            List<int> leaves = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (adjacentList[i].Count == 1)
                {
                    leaves.Add(i);
                }
            }

            int remainingNodes = n;
            while (remainingNodes > 2)
            {
                remainingNodes -= leaves.Count;

                List<int> newLeaves = new List<int>();
                foreach (int leaf in leaves)
                {
                    int neighbor = adjacentList[leaf].First();
                    adjacentList[neighbor].Remove(leaf);
                    if (adjacentList[neighbor].Count == 1)
                    {
                        newLeaves.Add(neighbor);
                    }
                }

                leaves = newLeaves;
            }

            return leaves;
        }

        public class SecondDone
        {
            public IList<int> FindMinHeightTrees(int n, int[][] edges)
            {
                if (n <= 1)
                {
                    return new List<int>() { 0 };
                }

                // pre-process to generate the graph
                Dictionary<int, List<int>> adjacents = new Dictionary<int, List<int>>();
                foreach (int[] edge in edges)
                {
                    if (!adjacents.ContainsKey(edge[0]))
                    {
                        adjacents[edge[0]] = new List<int>();
                    }
                    if (!adjacents.ContainsKey(edge[1]))
                    {
                        adjacents[edge[1]] = new List<int>();
                    }
                    adjacents[edge[0]].Add(edge[1]);
                    adjacents[edge[1]].Add(edge[0]);
                }

                // initiate with 1-adjacent nodes
                Queue<int> queue = new Queue<int>();
                foreach (int node in adjacents.Keys)
                {
                    if (adjacents[node].Count == 1)
                    {
                        queue.Enqueue(node);
                    }
                }

                // breadth-first traversal
                int remainNodes = n;
                while (remainNodes > 2)
                {
                    int count = queue.Count;
                    for (int cnt = 0; cnt < count; cnt++)
                    {
                        int cur = queue.Dequeue();
                        remainNodes--;
                        foreach (int adj in adjacents[cur])
                        {
                            adjacents[adj].Remove(cur);
                            if (adjacents[adj].Count == 1)
                            {
                                queue.Enqueue(adj);
                            }
                        }
                    }
                }

                return queue.ToList();
            }
        }
    }
}
