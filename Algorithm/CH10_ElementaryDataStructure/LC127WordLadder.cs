using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC127WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int n = beginWord.Length;

            // pre-processing
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (string word in wordList)
            {
                for (int i = 0; i < n; i++)
                {
                    string pattern = word.Substring(0, i) + '*' + word.Substring(i + 1);
                    if (!map.ContainsKey(pattern))
                    {
                        map[pattern] = new List<string>();
                    }
                    map[pattern].Add(word);
                }
            }

            // bread-first traversal to find the shortest path
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            HashSet<string> visited = new HashSet<string>();
            int level = 1;
            while (queue.Count > 0)
            {
                int count = queue.Count; // the count of current level nodes

                // iterate through all the node of current level and add their neighbors to the queue
                for (int cnt = 0; cnt < count; cnt++)
                {
                    string word = queue.Dequeue();
                    if (visited.Contains(word))
                    {
                        continue;
                    }
                    visited.Add(word); // mark as visited

                    if (word == endWord)
                    {
                        return level;
                    }

                    // check its all possible patterns to get its all neighbors
                    for (int i = 0; i < n; i++)
                    {
                        string pattern = word.Substring(0, i) + '*' + word.Substring(i + 1);
                        if (map.ContainsKey(pattern))
                        {
                            foreach (string neighbor in map[pattern])
                            {
                                if (!visited.Contains(neighbor))
                                {
                                    queue.Enqueue(neighbor);
                                }
                            }
                        }
                    }
                }
                level++;
            }

            return 0;
        }
    }
}
