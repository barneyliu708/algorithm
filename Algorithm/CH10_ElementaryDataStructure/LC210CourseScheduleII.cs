using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC210CourseScheduleII
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int[] indegress = new int[numCourses];
            foreach (int[] edge in prerequisites)
            {
                int src = edge[1];
                int dest = edge[0];
                if (!graph.ContainsKey(src))
                {
                    graph[src] = new List<int>();
                }
                graph[src].Add(dest);
                indegress[dest]++;
            }

            // We start from courses that have no prerequisites.
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegress[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int[] ans = new int[numCourses];
            int insert = 0;
            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();
                ans[insert++] = cur;

                if (graph.ContainsKey(cur))
                {
                    foreach (int neighbor in graph[cur])
                    {
                        indegress[neighbor]--;
                        if (indegress[neighbor] == 0)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            // if there are still some edges left, then there exist some cycles
            // Due to the dead-lock (dependencies), we cannot remove the cyclic edges
            if (insert == numCourses)
            {
                return ans;
            }

            return new int[0];
        }
    }
}
