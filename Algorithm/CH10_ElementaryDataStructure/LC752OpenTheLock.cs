using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC752OpenTheLock
    {
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> visited = new HashSet<string>(deadends);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("0000");

            int turns = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    string wheels = queue.Dequeue();
                    if (visited.Contains(wheels))
                    {
                        continue;
                    }
                    visited.Add(wheels);

                    if (target == wheels)
                    {
                        return turns;
                    }

                    for (int w = 0; w < 4; w++)
                    {
                        foreach (int d in new int[] { -1, 1 })
                        {
                            char[] wheelsArr = wheels.ToCharArray();
                            int wv = (wheelsArr[w] - '0' + d + 10) % 10;
                            wheelsArr[w] = wv.ToString()[0];
                            string neibor = new string(wheelsArr);
                            if (!visited.Contains(neibor))
                            {
                                queue.Enqueue(neibor);
                            }
                        }
                    }
                }
                turns++;
            }

            return -1;
        }

        public class SecondDone
        {
            public int OpenLock(string[] deadends, string target)
            {
                // HashSet<string> deads = new HashSet<string>(deadends);
                HashSet<string> visited = new HashSet<string>(deadends);
                int ans = 0;
                Queue<string> queue = new Queue<string>();
                queue.Enqueue("0000");
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        string cur = queue.Dequeue();
                        if (cur == target)
                        {
                            return ans;
                        }
                        if (visited.Contains(cur))
                        {
                            continue;
                        }
                        visited.Add(cur);
                        foreach (string neighbor in GetNeighbors(cur))
                        {
                            if (!visited.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                            }
                        }
                    }
                    ans++;
                }
                return -1;
            }

            private List<string> GetNeighbors(string state)
            {
                List<string> neighbors = new List<string>();
                for (int i = 0; i < state.Length; i++)
                {
                    int digit = state[i] - '0';
                    string next = state.Substring(0, i) + ((digit + 1 + 10) % 10) + state.Substring(i + 1);
                    string prev = state.Substring(0, i) + ((digit - 1 + 10) % 10) + state.Substring(i + 1);
                    neighbors.Add(next);
                    neighbors.Add(prev);
                }
                return neighbors;
            }
        }
    }
}
