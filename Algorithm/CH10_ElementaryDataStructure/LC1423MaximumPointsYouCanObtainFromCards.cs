using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1423MaximumPointsYouCanObtainFromCards
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            int n = cardPoints.Length;

            // leftsum[i] = cardPoints[0] + ... + cardPoints[i - 1], count = i
            int[] leftsum = new int[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                leftsum[i] = leftsum[i - 1] + cardPoints[i - 1];
                // Console.WriteLine(i + " " + leftsum[i]);
            }

            // Console.WriteLine("======");

            // rightsum[i] = cardPoints[i] + ... + cardPoints[n - 1], count = n - i
            int[] rightsum = new int[n + 1];
            for (int i = n - 1; i >= 0; i--)
            {
                rightsum[i] = rightsum[i + 1] + cardPoints[i];
                // Console.WriteLine(i + " " + rightsum[i]);
            }

            // Console.WriteLine("======");
            int max = 0;
            for (int i = 0; i <= k; i++)
            {
                // Console.WriteLine(i + " " + leftsum[i] + " " + (n - k + i) + " " + rightsum[n - k + i]);
                max = Math.Max(max, leftsum[i] + rightsum[n - k + i]);
            }

            return max;
        }
    }
}
