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
    }
}
