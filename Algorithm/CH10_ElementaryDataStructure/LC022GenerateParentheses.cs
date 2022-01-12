using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC022GenerateParentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> ans = new List<string>();
            utility(n, n, "", ans);
            return ans;
        }

        private void utility(int left, int right, string output, IList<string> ans)
        {
            if (left > right)
            {
                return;
            }
            if (left == 0 && right == 0)
            {
                ans.Add(output);
                return;
            }

            if (left > 0)
            {
                utility(left - 1, right, output + "(", ans);
            }

            if (right > 0)
            {
                utility(left, right - 1, output + ")", ans);
            }
        }
    }
}
