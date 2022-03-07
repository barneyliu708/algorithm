using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC386LexicographicalNumbers
    {
        public IList<int> LexicalOrder(int n)
        {
            List<int> ans = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                LexicalOrder(n, i, ans);
            }
            return ans;
        }

        private void LexicalOrder(int n, int cur, List<int> ans)
        {
            if (cur > n)
            {
                return;
            }
            ans.Add(cur);
            for (int i = 0; i <= 9; i++)
            {
                int next = cur * 10 + i;
                if (next > n)
                {
                    break;
                }
                LexicalOrder(n, next, ans);
            }
        }
    }
}
