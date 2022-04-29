using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC051N_Queens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            HashSet<int> cols = new HashSet<int>();
            HashSet<int> diagonals = new HashSet<int>();
            HashSet<int> antidiagonals = new HashSet<int>();
            List<string> path = new List<string>();
            List<IList<string>> ans = new List<IList<string>>();
            Backtracking(n, 0, cols, diagonals, antidiagonals, path, ans);
            return ans;
        }

        private void Backtracking(int n, int row, HashSet<int> cols, HashSet<int> diagonals, HashSet<int> antidiagonals, List<string> path, List<IList<string>> ans)
        {
            if (row == n)
            {
                ans.Add(new List<string>(path));
                return;
            }
            for (int col = 0; col < n; col++)
            {
                if (cols.Contains(col))
                {
                    continue;
                }
                if (diagonals.Contains(row - col))
                {
                    continue;
                }
                if (antidiagonals.Contains(row + col))
                {
                    continue;
                }
                path.Add(new string('.', col) + 'Q' + new string('.', n - 1 - col));
                cols.Add(col);
                diagonals.Add(row - col);
                antidiagonals.Add(row + col);

                Backtracking(n, row + 1, cols, diagonals, antidiagonals, path, ans);

                path.RemoveAt(path.Count - 1);
                cols.Remove(col);
                diagonals.Remove(row - col);
                antidiagonals.Remove(row + col);
            }
        }
    }
}
