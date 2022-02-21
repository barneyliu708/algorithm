using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC373FindKPairsWithSmallestSums
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {

            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                pq.Enqueue(new int[] { i, 0 }, nums1[i] + nums2[0]);
            }

            IList<IList<int>> ans = new List<IList<int>>();
            while (pq.Count > 0 && ans.Count < k)
            {
                int[] pairIdx = pq.Dequeue();
                int i = pairIdx[0];
                int j = pairIdx[1];

                ans.Add(new List<int>() { nums1[i], nums2[j] });

                j++;
                if (j < nums2.Length)
                {
                    pq.Enqueue(new int[] { i, j }, nums1[i] + nums2[j]);
                }
            }
            return ans;
        }
    }
}
