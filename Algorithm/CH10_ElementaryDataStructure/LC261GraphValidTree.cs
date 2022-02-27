using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC261GraphValidTree
    {
        public bool ValidTree(int n, int[][] edges)
        {
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

            Dictionary<int, int> parent = new Dictionary<int, int>();
            parent[0] = -1;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int cur = stack.Pop();

                foreach (int neighbor in adjacentList[cur])
                {
                    if (parent[cur] == neighbor)
                    {
                        continue;
                    }
                    if (parent.ContainsKey(neighbor)) // cycle detected
                    { 
                        return false;
                    }
                    stack.Push(neighbor);
                    parent[neighbor] = cur;
                }
            }

            return parent.Count == n;
        }
    }
}
