using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC281ZigzagIterator
    {
        public class ZigzagIterator
        {

            private int i;
            private IList<int> v;

            public ZigzagIterator(IList<int> v1, IList<int> v2)
            {
                v = new List<int>();
                int p1 = 0;
                int p2 = 0;
                while (p1 < v1.Count && p2 < v2.Count)
                {
                    v.Add(v1[p1++]);
                    v.Add(v2[p2++]);
                }

                while (p1 < v1.Count)
                {
                    v.Add(v1[p1++]);
                }

                while (p2 < v2.Count)
                {
                    v.Add(v2[p2++]);
                }
            }

            public bool HasNext()
            {
                return i < v.Count;
            }

            public int Next()
            {
                return v[i++];
            }
        }

        public class SecondDone
        {
            public class ZigzagIterator
            {

                private Queue<(int ivec, int iele)> queue;
                private List<IList<int>> vectors;
                public ZigzagIterator(IList<int> v1, IList<int> v2)
                {
                    queue = new Queue<(int ivec, int iele)>();
                    vectors = new List<IList<int>>();
                    vectors.Add(v1);
                    vectors.Add(v2);
                    int i = 0;
                    foreach (IList<int> vec in vectors)
                    {
                        if (vec.Count > 0)
                        { // this is to avoid empty list
                            queue.Enqueue((i, 0));
                        }
                        i++;
                    }
                }

                public bool HasNext()
                {
                    return queue.Count > 0;
                }

                public int Next()
                {
                    (int ivec, int iele) cur = queue.Dequeue();
                    IList<int> vec = vectors[cur.ivec];
                    int ele = vec[cur.iele];
                    if (cur.iele + 1 < vec.Count)
                    {
                        queue.Enqueue((cur.ivec, cur.iele + 1));
                    }
                    return ele;
                }
            }
        }
    }
}
