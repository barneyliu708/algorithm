using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC074SearchA2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {

            int start = 0;
            int end = matrix.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (matrix[mid][0] == target)
                {
                    return true;
                }
                else if (matrix[mid][0] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            if (end < 0) // meaning target is smaller than the first element of the matrix
            { 
                return false;
            }

            int row = end;
            start = 0;
            end = matrix[row].Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (matrix[row][mid] == target)
                {
                    return true;
                }
                else if (matrix[row][mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return false;
        }
    }
}
