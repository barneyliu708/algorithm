using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC378KthSmallestElementInASortedMatrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    pq.Enqueue(matrix[i][j], -matrix[i][j]);
                    if (pq.Count > k)
                    {
                        pq.Dequeue();
                    }
                }
            }
            return pq.Dequeue();
        }

        public class SecondDone
        {
            public int KthSmallest(int[][] matrix, int k)
            {
                PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((int x, int y) => {
                    return y.CompareTo(x); // max-heap
                }));
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        pq.Enqueue(matrix[i][j], matrix[i][j]);
                        if (pq.Count > k)
                        {
                            pq.Dequeue();
                        }
                    }
                }
                return pq.Dequeue();
            }
        }
    }
}
