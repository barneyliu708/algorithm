using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC269AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            // pre-process to build up the graph
            Dictionary<char, List<char>> adjacents = new Dictionary<char, List<char>>();
            Dictionary<char, int> inDegrees = new Dictionary<char, int>();
            foreach (string word in words)
            {
                foreach (char ch in word)
                {
                    inDegrees[ch] = 0;
                    adjacents[ch] = new List<char>();
                }
            }
            for (int i = 1; i < words.Length; i++)
            {
                string word1 = words[i - 1];
                string word2 = words[i];
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return "";
                }
                // find the first non-match character
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        char ch1 = word1[j];
                        char ch2 = word2[j];
                        adjacents[ch1].Add(ch2);
                        inDegrees[ch2]++;
                        break;
                    }
                }
            }

            // initiate with 0-indegree nodes
            StringBuilder sb = new StringBuilder();
            Queue<char> queue = new Queue<char>();
            foreach (char ch in inDegrees.Keys)
            {
                if (inDegrees[ch] == 0)
                {
                    queue.Enqueue(ch);
                }
            }
            while (queue.Count > 0)
            {
                char ch = queue.Dequeue();
                sb.Append(ch);
                foreach (char adj in adjacents[ch])
                {
                    inDegrees[adj]--;
                    if (inDegrees[adj] == 0)
                    {
                        queue.Enqueue(adj);
                    }
                }
            }

            if (sb.Length < inDegrees.Count)
            {
                return "";
            }
            return sb.ToString();
        }
    }
}
