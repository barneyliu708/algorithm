using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC048RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            ReverseOnDiagonal(matrix);
            ReverseHorizontal(matrix);

        }

        private void ReverseOnDiagonal(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private void ReverseHorizontal(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = temp;
                }
            }
        }
    }
}
