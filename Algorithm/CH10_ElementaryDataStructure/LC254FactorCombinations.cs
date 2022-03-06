using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC254FactorCombinations
    {
        public IList<IList<int>> GetFactors(int n)
        {
            List<int> comb = new List<int>(); // store the current combination
            List<IList<int>> ans = new List<IList<int>>(); // store the answer
            GetFactors(n, 2, comb, ans);
            return ans;
        }

        private void GetFactors(int n, int start, List<int> comb, List<IList<int>> ans)
        {

            for (int i = start; i <= Math.Sqrt(n); i++)
            {
                if (n % i != 0)
                {
                    continue;
                }
                List<int> newcomb = new List<int>(comb);
                newcomb.Add(i);
                GetFactors(n / i, i, newcomb, ans);
                newcomb.Add(n / i);
                ans.Add(newcomb);
            }
        }
    }
}
