using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC304RangeSumQuery2DImmutable
    {
        public class NumMatrix
        {
            int m;
            int n;
            int[,] presum;

            public NumMatrix(int[][] matrix)
            {
                m = matrix.Length;
                n = matrix[0].Length;
                presum = new int[m + 1, n + 1];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        presum[i + 1, j + 1] = presum[i, j + 1] + presum[i + 1, j] - presum[i, j] + matrix[i][j];
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                return presum[row2 + 1, col2 + 1] - presum[row2 + 1, col1] - presum[row1, col2 + 1] + presum[row1, col1];
            }
        }
    }
}
