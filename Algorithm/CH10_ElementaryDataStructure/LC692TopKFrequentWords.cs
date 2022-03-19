using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC692TopKFrequentWords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!map.ContainsKey(word))
                {
                    map[word] = 0;
                }
                map[word]++;
            }

            PriorityQueue<string, (int count, string word)> pq
                = new PriorityQueue<string, (int count, string word)>(
                    Comparer<(int count, string word)>.Create((x, y) => 
                    {
                        if (x.count != y.count)
                        {
                            return x.count.CompareTo(y.count);
                        }
                        return y.word.CompareTo(x.word);
                    }));
            foreach (string word in map.Keys)
            {
                pq.Enqueue(word, (map[word], word));
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            List<string> ans = new List<string>();
            while (pq.Count > 0)
            {
                ans.Insert(0, pq.Dequeue());
            }

            return ans;
        }
    }
}
