using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC040CombinationSumII
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);
            Combination(candidates, target, 0, comb, ans);
            return ans;
        }

        private void Combination(int[] candidates, int target, int start, List<int> comb, List<IList<int>> ans)
        {
            if (start > candidates.Length || target < 0)
            {
                return;
            }
            if (target == 0)
            {
                ans.Add(new List<int>(comb));
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1]) // avoid duplicate combination
                {
                    continue;
                }
                comb.Add(candidates[i]);
                Combination(candidates, target - candidates[i], i + 1, comb, ans); // i + 1 as each element can only be used once
                comb.Remove(candidates[i]);
            }
        }
    }
}
