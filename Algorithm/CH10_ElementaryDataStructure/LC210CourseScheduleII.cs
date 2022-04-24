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

        public class SecondDone
        {
            public int[] FindOrder(int numCourses, int[][] prerequisites)
            {

                // pre-process to build the graph
                Dictionary<int, List<int>> outNodes = new Dictionary<int, List<int>>();
                int[] inDegrees = new int[numCourses];
                for (int course = 0; course < numCourses; course++)
                {
                    outNodes[course] = new List<int>();
                }
                foreach (int[] pre in prerequisites)
                {
                    int ai = pre[0];
                    int bi = pre[1];
                    // bi -> ai
                    outNodes[bi].Add(ai);
                    inDegrees[ai]++;
                }

                // initiate with 0-indegree nodes
                Queue<int> queue = new Queue<int>();
                for (int course = 0; course < numCourses; course++)
                {
                    if (inDegrees[course] == 0)
                    {
                        queue.Enqueue(course);
                    }
                }

                // breadth-first traversal
                List<int> ans = new List<int>();
                while (queue.Count > 0)
                {
                    int course = queue.Dequeue();
                    ans.Add(course);
                    foreach (int nextCourse in outNodes[course])
                    {
                        // update indegrees
                        inDegrees[nextCourse] -= 1;
                        if (inDegrees[nextCourse] == 0)
                        {
                            queue.Enqueue(nextCourse);
                        }
                    }
                }

                if (ans.Count == numCourses)
                {
                    return ans.ToArray();
                }

                return new int[0];
            }
        }
    }
}
