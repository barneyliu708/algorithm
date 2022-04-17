using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC740DeleteAndEarn
    {
        public int DeleteAndEarn(int[] nums)
        {
            Dictionary<int, int> points = new Dictionary<int, int>(); // num - total points
            int maxNum = 0;
            foreach (int num in nums)
            {
                if (!points.ContainsKey(num))
                {
                    points[num] = 0;
                }
                points[num] += num;
                maxNum = Math.Max(maxNum, num);
            }

            // create dp based on the value of num
            int[] dp = new int[maxNum + 1];
            dp[1] = points.ContainsKey(1) ? points[1] : 0;
            for (int num = 2; num <= maxNum; num++)
            {
                int newPoints = points.ContainsKey(num) ? points[num] : 0;
                dp[num] = Math.Max(dp[num - 1], dp[num - 2] + newPoints);
            }

            return dp[maxNum];
        }
    }
}
