using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC323NumberOfConnectedComponentsInAnUndirectedGraph
    {
        public int CountComponents(int n, int[][] edges)
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

            int count = 0;
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    count++;
                    Dft(adjacentList, visited, i);
                }
            }

            return count;
        }

        private void Dft(List<int>[] adjacentList, bool[] visited, int cur)
        {
            visited[cur] = true;

            foreach (int neighbor in adjacentList[cur])
            {
                if (!visited[neighbor])
                {
                    Dft(adjacentList, visited, neighbor);
                }
            }
        }

        public class BFTApproach
        {
            public int CountComponents(int n, int[][] edges)
            {
                // pre-process
                List<int>[] neighbors = new List<int>[n];
                for (int i = 0; i < n; i++)
                {
                    neighbors[i] = new List<int>();
                }
                foreach (int[] edge in edges)
                {
                    neighbors[edge[0]].Add(edge[1]);
                    neighbors[edge[1]].Add(edge[0]);
                }

                // scan the whole nodes
                bool[] visited = new bool[n];
                int total = 0;
                for (int i = 0; i < n; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }

                    total++;

                    // breadth-first traversal
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        int cur = queue.Dequeue();
                        if (visited[cur])
                        {
                            continue;
                        }
                        visited[cur] = true;

                        foreach (int neighbor in neighbors[cur])
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                return total;
            }
        }
    }
}
