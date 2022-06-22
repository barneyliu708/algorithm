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

        public class ThirdDone
        {
            public class Solution
            {
                public int CountComponents(int n, int[][] edges)
                {
                    DSU dsu = new DSU(n);
                    foreach (int[] edge in edges)
                    {
                        int ai = edge[0];
                        int bi = edge[1];
                        dsu.Union(ai, bi);
                    }

                    HashSet<int> reps = new HashSet<int>();
                    for (int i = 0; i < n; i++)
                    {
                        reps.Add(dsu.GetRepresentative(i));
                    }

                    return reps.Count;
                }
            }

            class DSU
            {
                private int[] representatives;
                private int[] size;

                public DSU(int sz)
                {
                    representatives = new int[sz];
                    size = new int[sz];
                    for (int i = 0; i < sz; i++)
                    {
                        representatives[i] = i;
                        size[i] = 1;
                    }
                }

                public int GetRepresentative(int i)
                {
                    if (representatives[i] == i)
                    {
                        return i;
                    }
                    return representatives[i] = GetRepresentative(representatives[i]);
                }

                public void Union(int a, int b)
                {
                    int arep = GetRepresentative(a);
                    int brep = GetRepresentative(b);

                    // a and b already unioned
                    if (arep == brep)
                    {
                        return;
                    }

                    if (size[arep] >= size[brep])
                    {
                        size[arep] += size[brep];
                        representatives[brep] = arep;
                    }
                    else
                    {
                        size[brep] += size[arep];
                        representatives[arep] = brep;
                    }
                }
            }
        }
    }
}
