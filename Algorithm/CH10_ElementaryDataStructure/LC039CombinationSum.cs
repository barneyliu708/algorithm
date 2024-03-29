﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC039CombinationSum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {

            List<int> comb = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();

            Combination(candidates, target, 0, comb, ans);

            return ans;
        }

        public void Combination(int[] candidates, int target, int start, List<int> comb, List<IList<int>> ans)
        {
            if (start >= candidates.Length || target < 0)
            {
                return;
            }
            if (target == 0)
            {
                ans.Add(new List<int>(comb));
            }

            for (int i = start; i < candidates.Length; i++)
            {
                comb.Add(candidates[i]);
                Combination(candidates, target - candidates[i], i, comb, ans);
                comb.Remove(candidates[i]);
            }
        }

        public class SecondDone
        {
            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                Array.Sort(candidates);
                List<int> path = new List<int>();
                List<IList<int>> ans = new List<IList<int>>();
                Combination(candidates, 0, target, path, ans);
                return ans;
            }

            private void Combination(int[] candidates, int i, int target, List<int> path, List<IList<int>> ans)
            {
                if (target < 0)
                {
                    return;
                }
                if (target == 0)
                {
                    ans.Add(new List<int>(path));
                    return;
                }

                for (int j = i; j < candidates.Length; j++)
                {
                    path.Add(candidates[j]);
                    Combination(candidates, j, target - candidates[j], path, ans);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
