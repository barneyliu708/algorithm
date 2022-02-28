using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC2013DetectSquares
    {
        public class DetectSquares
        {

            Dictionary<int, HashSet<int>> xtoy;
            Dictionary<int, HashSet<int>> ytox;
            int[,] count;

            public DetectSquares()
            {
                xtoy = new Dictionary<int, HashSet<int>>();
                ytox = new Dictionary<int, HashSet<int>>();
                count = new int[1001, 1001];
            }

            public void Add(int[] point)
            {
                int x = point[0];
                int y = point[1];
                count[x, y]++;
                if (!xtoy.ContainsKey(x))
                {
                    xtoy[x] = new HashSet<int>();
                }
                if (!ytox.ContainsKey(y))
                {
                    ytox[y] = new HashSet<int>();
                }
                xtoy[x].Add(y);
                ytox[y].Add(x);
            }

            public int Count(int[] point)
            {
                int x0 = point[0];
                int y0 = point[1];
                int ans = 0;
                if (!xtoy.ContainsKey(x0) || !ytox.ContainsKey(y0))
                {
                    return 0;
                }
                foreach (int x in ytox[y0])
                {
                    foreach (int y in xtoy[x0])
                    {
                        if (x != x0 && y != y0 && Math.Abs(x - x0) == Math.Abs(y - y0))
                        {
                            ans += count[x, y0] * count[x0, y] * count[x, y];
                        }
                    }
                }
                return ans;
            }
        }

    }
}
