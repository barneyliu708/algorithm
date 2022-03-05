using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC526BeautifulArrangement
    {
        private int count;
        public int CountArrangement(int n)
        {
            bool[] visited = new bool[n + 1];
            Utility(n, 1, visited);
            return count;
        }

        private void Utility(int N, int pos, bool[] visited)
        {

            if (pos > N)
            {
                count++;
            }

            for (int i = 1; i <= N; i++)
            {
                if (!visited[i] && (pos % i == 0 || i % pos == 0))
                {
                    visited[i] = true;
                    Utility(N, pos + 1, visited);
                    visited[i] = false;
                }
            }
        }
    }
}
