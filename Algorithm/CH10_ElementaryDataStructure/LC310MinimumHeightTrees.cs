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
    }
}
