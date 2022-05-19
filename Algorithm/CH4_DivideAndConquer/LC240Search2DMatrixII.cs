using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC240Search2DMatrixII
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {

            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }

            return SearchMatrix(matrix, target, 0, matrix[0].Length - 1, 0, matrix.Length - 1);
        }

        public bool SearchMatrix(int[][] matrix, int target, int l, int r, int u, int d)
        {

            if (l > r || u > d)
            {
                return false;
            }

            if (target < matrix[u][l] || target > matrix[d][r])
            {
                return false;
            }

            if (l == r && u == d)
            {
                return matrix[u][l] == target;
            }

            return SearchMatrix(matrix, target, l, (l + r) / 2, u, (u + d) / 2) ||
                   SearchMatrix(matrix, target, (l + r) / 2 + 1, r, u, (u + d) / 2) ||
                   SearchMatrix(matrix, target, l, (l + r) / 2, (u + d) / 2 + 1, d) ||
                   SearchMatrix(matrix, target, (l + r) / 2 + 1, r, (u + d) / 2 + 1, d);
        }

        public class SecondDone
        {
            public bool SearchMatrix(int[][] matrix, int target)
            {
                int m = matrix.Length;
                int n = matrix[0].Length;
                return SearchMatrix(matrix, target, 0, n - 1, 0, m - 1);
            }

            private bool SearchMatrix(int[][] matrix, int target, int l, int r, int u, int d)
            {
                if (l > r || u > d)
                {
                    return false;
                }

                if (target < matrix[u][l] || target > matrix[d][r])
                {
                    return false;
                }

                if (l == r && u == d)
                {
                    return target == matrix[u][l];
                }

                return SearchMatrix(matrix, target, l, (l + r) / 2, u, (u + d) / 2) ||
                       SearchMatrix(matrix, target, (l + r) / 2 + 1, r, u, (u + d) / 2) ||
                       SearchMatrix(matrix, target, l, (l + r) / 2, (u + d) / 2 + 1, d) ||
                       SearchMatrix(matrix, target, (l + r) / 2 + 1, r, (u + d) / 2 + 1, d);
            }
        }
    }
}
