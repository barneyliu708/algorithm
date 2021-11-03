using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH7_QuickSort
{
    public class QuickSort
    {
        public static void Sort(int[] A)
        {
            Sort(A, 0, A.Length - 1);
        }

        private static void Sort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(A, p, r);
                Sort(A, p, q - 1);
                Sort(A, q + 1, r);
            }
        }

        private static int Partition(int[] A, int p, int r)
        {
            int x = A[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (A[j] < x)
                {
                    i++;
                    Swap(A, i, j);
                }
            }

            Swap(A, i + 1, r);
            return i + 1;
        }

        private static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
