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

        public class SecondDone
        {
            public IList<int> LexicalOrder(int n)
            {
                List<int> ans = new List<int>();
                Dft(n, 0, ans);
                return ans;
            }

            private void Dft(int n, int current, List<int> ans)
            {
                List<int> digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                if (current == 0)
                {
                    digits.RemoveAt(0);
                }
                foreach (int d in digits)
                {
                    if (current + d > n)
                    {
                        return;
                    }
                    ans.Add(current + d);
                    Dft(n, (current + d) * 10, ans);
                }
            }
        }
    }
}
