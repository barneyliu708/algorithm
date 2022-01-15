using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC119PascalsTriangleII
    {
        public IList<int> GetRow(int rowIndex)
        {
            int[] ans = new int[rowIndex + 1];

            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        ans[j] = 1;
                    }
                    else
                    {
                        ans[j] = ans[j - 1] + ans[j];
                    }
                }
            }

            return ans;
        }
    }
}
