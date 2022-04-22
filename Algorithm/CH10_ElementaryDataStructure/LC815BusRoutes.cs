using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC815BusRoutes
    {
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target)
            {
                return 0;
            }
            int N = routes.Length;

            // pre-process to build the graph
            List<int>[] graph = new List<int>[N]; // ith bus - connected buses
            for (int i = 0; i < N; i++)
            {
                Array.Sort(routes[i]);
                graph[i] = new List<int>();
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (Intersect(routes[i], routes[j]))
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }
            // breadth-first traversal
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> targets = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < N; i++)
            {
                if (routes[i].Contains(source))
                {
                    queue.Enqueue(i);
                }
                if (routes[i].Contains(target))
                {
                    targets.Add(i);
                }
            }
            int steps = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                steps++;
                for (int cnt = 0; cnt < count; cnt++)
                {
                    int cur = queue.Dequeue();
                    if (targets.Contains(cur))
                    {
                        return steps;
                    }
                    if (visited.Contains(cur))
                    {
                        continue;
                    }
                    visited.Add(cur);
                    foreach (int neighbor in graph[cur])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            return -1;
        }

        private bool Intersect(int[] x, int[] y)
        {
            int i = 0;
            int j = 0;
            while (i < x.Length && j < y.Length)
            {
                if (x[i] == y[j])
                {
                    return true;
                }
                if (x[i] < y[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return false;
        }
    }
}
