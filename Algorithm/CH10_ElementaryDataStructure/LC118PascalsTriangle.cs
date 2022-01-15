using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC118PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {

            IList<IList<int>> ans = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                ans.Add(new List<int>());
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        ans[i].Add(1);
                    }
                    else
                    {
                        ans[i].Add(ans[i - 1][j - 1] + ans[i - 1][j]);
                    }
                }
            }

            return ans;
        }
    }
}
