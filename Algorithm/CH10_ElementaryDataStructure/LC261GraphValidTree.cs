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

        public class SecondDone
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
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(0);

                while (queue.Count > 0)
                {
                    int cur = queue.Dequeue();

                    foreach (int neighbor in adjacentList[cur])
                    {
                        if (parent[cur] == neighbor)
                        {
                            continue;
                        }
                        if (parent.ContainsKey(neighbor))
                        { // cycle detected
                            return false;
                        }
                        queue.Enqueue(neighbor);
                        parent[neighbor] = cur;
                    }
                }

                return parent.Count == n;
            }
        }

        public class ThirdDone_TropologicalSort
        {
            public bool ValidTree(int n, int[][] edges)
            {
                if (edges.Length < n - 1)
                {
                    return false;
                }

                if (n == 1)
                {
                    return true;
                }

                List<int>[] adjNodes = new List<int>[n];
                for (int i = 0; i < n; i++)
                {
                    adjNodes[i] = new List<int>();
                }
                int[] indegrees = new int[n];

                foreach (int[] edge in edges)
                {
                    int a = edge[0];
                    int b = edge[1];
                    adjNodes[a].Add(b);
                    adjNodes[b].Add(a);
                    indegrees[a]++;
                    indegrees[b]++;
                }

                bool[] visited = new bool[n];
                int visitedCount = 0;
                Queue<int> queue = new Queue<int>();
                for (int i = 0; i < n; i++)
                {
                    if (indegrees[i] == 1)
                    {
                        queue.Enqueue(i);
                    }
                }

                while (queue.Count > 0)
                {
                    int cur = queue.Dequeue();
                    if (visited[cur])
                    {
                        continue;
                    }
                    visited[cur] = true;
                    visitedCount++;
                    indegrees[cur]--;
                    foreach (int neighbor in adjNodes[cur])
                    {
                        indegrees[neighbor]--;
                        if (indegrees[neighbor] == 1)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
                Console.WriteLine(visitedCount);
                return visitedCount == n;
            }
        }
    }
}
