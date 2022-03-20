using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC767ReorganizeString
    {
        public string ReorganizeString(string s)
        {

            Dictionary<char, int> map = new Dictionary<char, int>(); // char - count
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                {
                    map[c] = 0;
                }
                map[c]++;
            }

            PriorityQueue<char, int> maxheap = new PriorityQueue<char, int>(Comparer<int>.Create((x, y) => {
                return y.CompareTo(x); // descending order, the max element will be on the top of the heap
            }));
            foreach (char c in map.Keys)
            {
                if (map[c] > (s.Length + 1) / 2)
                {
                    return "";
                }
                maxheap.Enqueue(c, map[c]); // the count is the priority of characters
            }

            StringBuilder sb = new StringBuilder();
            while (maxheap.Count >= 2)
            {
                char ch1, ch2;
                int count1, count2;
                maxheap.TryDequeue(out ch1, out count1);
                maxheap.TryDequeue(out ch2, out count2);

                // build string
                sb.Append(ch1);
                sb.Append(ch2);

                // update maxheap
                if (--count1 > 0)
                {
                    maxheap.Enqueue(ch1, count1);
                }
                if (--count2 > 0)
                {
                    maxheap.Enqueue(ch2, count2);
                }
            }

            if (maxheap.Count > 0)
            {
                sb.Append(maxheap.Dequeue());
            }

            return sb.ToString();
        }
    }
}
