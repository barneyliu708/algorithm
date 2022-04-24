using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC207CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>(); // prerequisite course - course
            foreach (int[] course in prerequisites)
            {
                if (!map.ContainsKey(course[1]))
                {
                    map[course[1]] = new List<int>();
                }
                map[course[1]].Add(course[0]);
            }

            bool[] visited = new bool[numCourses];
            bool[] checkes = new bool[numCourses];

            for (int curCourse = 0; curCourse < numCourses; curCourse++)
            {
                if (IsCycle(curCourse, map, visited, checkes))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsCycle(int curCourse, Dictionary<int, List<int>> map, bool[] visited, bool[] checkes)
        {

            if (checkes[curCourse])
            {
                return false;
            }

            if (visited[curCourse]) // cycle detected
            { 
                return true;
            }

            if (!map.ContainsKey(curCourse))
            {
                return false;
            }

            visited[curCourse] = true;

            bool ans = false;
            foreach (int adjCourse in map[curCourse])
            {
                ans = IsCycle(adjCourse, map, visited, checkes);
                if (ans)
                {
                    break;
                }
            }

            visited[curCourse] = false;
            checkes[curCourse] = true;
            return ans;
        }

        public class SecondDone_DFT
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {

                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>(); // prerequisite course - course
                foreach (int[] course in prerequisites)
                {
                    if (!map.ContainsKey(course[1]))
                    {
                        map[course[1]] = new List<int>();
                    }
                    map[course[1]].Add(course[0]);
                }

                bool[] path = new bool[numCourses];
                bool[] checkes = new bool[numCourses];

                for (int curCourse = 0; curCourse < numCourses; curCourse++)
                {
                    if (IsCycle(curCourse, map, checkes, path))
                    {
                        return false;
                    }
                }

                return true;
            }

            public bool IsCycle(int curCourse, Dictionary<int, List<int>> map, bool[] checkes, bool[] path)
            {

                if (checkes[curCourse])
                {
                    return false;
                }

                if (path[curCourse])
                { // cycle detected
                    return true;
                }

                if (!map.ContainsKey(curCourse))
                {
                    return false;
                }

                path[curCourse] = true; // mark in current path

                foreach (int adjCourse in map[curCourse])
                {
                    if (IsCycle(adjCourse, map, checkes, path))
                    {
                        return true;
                    }
                }

                path[curCourse] = false;
                checkes[curCourse] = true;
                return false;
            }
        }

        public class TopologicalSortApproach
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
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
                int removeEdges = 0;
                while (queue.Count > 0)
                {
                    int course = queue.Dequeue();

                    foreach (int nextCourse in outNodes[course])
                    {
                        // update indegrees
                        inDegrees[nextCourse] -= 1;
                        removeEdges += 1;
                        if (inDegrees[nextCourse] == 0)
                        {
                            queue.Enqueue(nextCourse);
                        }
                    }
                }

                return removeEdges == prerequisites.Length;
            }
        }
    }
}
