using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC077Combinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            Combine(n, k, 1, comb, ans);
            return ans;
        }

        public void Combine(int n, int k, int start, List<int> comb, List<IList<int>> ans)
        {
            if (comb.Count == k)
            {
                ans.Add(new List<int>(comb));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                comb.Add(i);
                Combine(n, k, i + 1, comb, ans);
                comb.Remove(i);
            }
        }

        public class SecondDone
        {
            public IList<IList<int>> Combine(int n, int k)
            {
                List<int> path = new List<int>();
                List<IList<int>> ans = new List<IList<int>>();
                Combine(n, k, 1, path, ans);
                return ans;
            }

            private void Combine(int n, int k, int start, List<int> path, List<IList<int>> ans)
            {
                if (path.Count == k)
                {
                    ans.Add(new List<int>(path));
                    return;
                }
                for (int i = start; i <= n; i++)
                {
                    path.Add(i);
                    Combine(n, k, i + 1, path, ans);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
