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

        public class SecondDone
        {
            public IList<string> TopKFrequent(string[] words, int k)
            {
                Dictionary<string, int> count = new Dictionary<string, int>();
                foreach (string word in words)
                {
                    if (!count.ContainsKey(word))
                    {
                        count[word] = 0;
                    }
                    count[word]++;
                }

                PriorityQueue<string, (int cnt, string word)> pq = new PriorityQueue<string, (int cnt, string word)>(
                    Comparer<(int cnt, string word)>.Create(((int cnt, string word) x, (int cnt, string word) y) => {
                        if (x.cnt != y.cnt)
                        {
                            return x.cnt.CompareTo(y.cnt);
                        }
                        return y.word.CompareTo(x.word);
                    })); // min-heap

                foreach (string word in count.Keys)
                {
                    pq.Enqueue(word, (count[word], word));
                    if (pq.Count > k)
                    {
                        pq.Dequeue();
                    }
                }

                List<string> ans = new List<string>();
                while (pq.Count > 0)
                {
                    ans.Add(pq.Dequeue());
                }
                ans.Reverse();

                return ans;
            }
        }
    }
}
