﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC213HouseRobberII
    {
        public int Rob(int[] nums)
        {

            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
        }

        private int Rob(int[] nums, int start, int end)
        {
            int t1 = 0;
            int t2 = 0;

            for (int i = start; i <= end; i++)
            {

                int temp = t1;
                int current = nums[i];
                t1 = Math.Max(current + t2, t1);
                t2 = temp;
            }

            return t1;
        }

        public class SecondDone
        {
            public int Rob(int[] nums)
            {
                if (nums.Length == 1)
                {
                    return nums[0];
                }

                // rob the 1st house and do not rob the last house
                int[] dp1 = new int[nums.Length + 1];
                dp1[1] = nums[0];
                for (int i = 2; i < nums.Length; i++)
                {
                    dp1[i] = Math.Max(dp1[i - 1], dp1[i - 2] + nums[i - 1]);
                }
                dp1[nums.Length] = Math.Max(dp1[nums.Length - 1], dp1[nums.Length - 2]);

                // do not rob the 1st house and potentially rob the last house
                int[] dp2 = new int[nums.Length + 1]; 
                for (int i = 2; i < nums.Length + 1; i++)
                {
                    dp2[i] = Math.Max(dp2[i - 1], dp2[i - 2] + nums[i - 1]);
                }

                return Math.Max(dp1[nums.Length], dp2[nums.Length]);
            }
        }

    }
}
