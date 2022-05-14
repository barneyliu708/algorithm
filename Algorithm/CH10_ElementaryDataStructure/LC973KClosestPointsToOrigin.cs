using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC973KClosestPointsToOrigin
    {
        public int[][] KClosest(int[][] points, int k)
        {

            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            foreach (int[] point in points)
            {
                pq.Enqueue(point, -point[0] * point[0] - point[1] * point[1]);
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            int[][] ans = new int[k][];
            for (int i = 0; i < k; i++)
            {
                ans[i] = pq.Dequeue();
            }

            return ans;
        }

        public class SecondDone
        {
            public int[][] KClosest(int[][] points, int k)
            {
                PriorityQueue<int[], int[]> pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((x, y) => {
                    int xdist = x[0] * x[0] + x[1] * x[1];
                    int ydist = y[0] * y[0] + y[1] * y[1];
                    return ydist.CompareTo(xdist); // max-heap
                }));

                foreach (int[] point in points)
                {
                    pq.Enqueue(point, point);
                    if (pq.Count > k)
                    {
                        pq.Dequeue();
                    }
                }

                int[][] ans = new int[k][];
                for (int i = 0; i < k; i++)
                {
                    ans[i] = pq.Dequeue();
                }

                return ans;
            }
        }
    }
}
