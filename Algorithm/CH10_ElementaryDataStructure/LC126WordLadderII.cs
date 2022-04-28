using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC126WordLadderII
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(beginWord))
            {
                wordList.Add(beginWord);
            }
            HashSet<string> wordDict = new HashSet<string>(wordList);

            // breadth-first traversal to generate directed-acyclic graph
            Dictionary<string, HashSet<string>> dag = new Dictionary<string, HashSet<string>>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            while (queue.Count > 0)
            {
                List<string> curVisited = new List<string>(); // only store the visited of current level
                while (queue.Count > 0)
                {
                    string cur = queue.Dequeue();
                    curVisited.Add(cur);
                }
                // remove the words of the current layers from the wordList
                foreach (string v in curVisited)
                {
                    if (wordDict.Contains(v))
                    {
                        wordDict.Remove(v);
                    }
                }
                foreach (string cur in curVisited)
                {
                    if (!dag.ContainsKey(cur))
                    {
                        dag[cur] = new HashSet<string>();
                    }

                    foreach (string neighbor in GetNeighbors(cur, wordDict))
                    {
                        queue.Enqueue(neighbor);
                        dag[cur].Add(neighbor);
                        // Console.WriteLine(cur + " - " + neighbor);
                    }
                }
            }

            List<IList<string>> ans = new List<IList<string>>();
            Backtracking(beginWord, endWord, dag, new List<string>() { beginWord }, ans);
            return ans;
        }

        private List<string> GetNeighbors(string word, HashSet<string> wordList)
        {
            List<string> neighbors = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    string neighbor = word.Substring(0, i) + ch + word.Substring(i + 1);
                    if (neighbor != word && wordList.Contains(neighbor))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }
            return neighbors;
        }

        private void Backtracking(string beginWord, string endWord, Dictionary<string, HashSet<string>> dag, List<string> path, List<IList<string>> ans)
        {
            if (beginWord == endWord)
            {
                ans.Add(new List<string>(path));
                return;
            }

            if (!dag.ContainsKey(beginWord))
            {
                return;
            }

            foreach (string nextWord in dag[beginWord])
            {
                if (path.Contains(nextWord))
                {
                    continue;
                }
                path.Add(nextWord);
                Backtracking(nextWord, endWord, dag, path, ans);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
