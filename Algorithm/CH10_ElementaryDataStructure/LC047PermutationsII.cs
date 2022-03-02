using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC047PermutationsII
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            List<IList<int>> ans = new List<IList<int>>();
            List<int> comb = new List<int>();
            foreach (int num in nums)
            {
                if (!count.ContainsKey(num))
                {
                    count[num] = 0;
                }
                count[num]++;
            }

            Permute(count, comb, ans, nums.Length);
            return ans;
        }

        private void Permute(Dictionary<int, int> count, List<int> comb, List<IList<int>> ans, int n)
        {
            if (comb.Count == n)
            {
                ans.Add(new List<int>(comb));
                return;
            }

            foreach (int num in count.Keys)
            {
                if (count[num] == 0)
                {
                    continue;
                }
                comb.Add(num);
                count[num]--;
                Permute(count, comb, ans, n);
                count[num]++;
                comb.RemoveAt(comb.Count - 1); // should not call Remove(num) as it may contains duplicate element
            }
        }
    }
}
