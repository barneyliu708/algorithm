﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC718MaximumLengthOfRepeatedSubarray
    {
        public int FindLength(int[] nums1, int[] nums2)
        {
            int[,] dp = new int[nums1.Length + 1, nums2.Length + 1];
            int maxLen = 0;
            for (int i = 1; i < nums1.Length + 1; i++)
            {
                for (int j = 1; j < nums2.Length + 1; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                        maxLen = Math.Max(maxLen, dp[i, j]);
                    }
                }
            }
            return maxLen;
        }

        public class SecondDone
        {
            public int FindLength(int[] nums1, int[] nums2)
            {
                int n1 = nums1.Length;
                int n2 = nums2.Length;
                int[,] dp = new int[n1 + 1, n2 + 1];
                int ans = 0;
                for (int i = 1; i <= n1; i++)
                {
                    for (int j = 1; j <= n2; j++)
                    {
                        if (nums1[i - 1] == nums2[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                        ans = Math.Max(ans, dp[i, j]);
                    }
                }
                return ans;
            }
        }
    }
}
