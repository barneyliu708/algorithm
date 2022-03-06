using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC216CombinationSumIII
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            Combination(k, n, 1, 0, comb, ans);
            return ans;
        }

        public void Combination(int k, int target, int start, int cursum, List<int> comb, List<IList<int>> ans)
        {
            if (comb.Count == k)
            {
                if (cursum == target)
                {
                    ans.Add(new List<int>(comb));
                }
                return;
            }

            if (start > 9)
            {
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                comb.Add(i);
                Combination(k, target, i + 1, cursum + i, comb, ans);
                comb.Remove(i);
            }
        }
    }
}
